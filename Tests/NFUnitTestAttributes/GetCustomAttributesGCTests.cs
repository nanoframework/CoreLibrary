// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Reflection;
using System.Threading;
using nanoFramework.TestFramework;

namespace NFUnitTestAttributes
{
    /// <summary>
    /// Regression tests for the intermittent <c>CLR_E_WRONG_TYPE</c> exception thrown from
    /// <c>CustomAttributesHelpers.GetCustomAttributesInternal</c> reported in
    /// https://github.com/nanoframework/Home/issues/1829.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The root cause was native: <c>CLR_RT_AttributeParser::Value::m_value</c> was neither
    /// zero initialised nor protected from the garbage collector, so a collection landing in the
    /// middle of decoding an attribute blob could reclaim or move the value being parsed. Fixed in
    /// nanoframework/nf-interpreter#3515.
    /// </para>
    ///
    /// <para>
    /// These tests are a port of the reproducing application supplied by the reporter at
    /// https://github.com/iSMA-Controlli/GetCustomAttributes, with two changes: the loops are
    /// bounded so they can run in CI, and the decoded attribute values are asserted rather than
    /// merely counted, so a silent value corruption fails the test instead of passing unnoticed.
    /// </para>
    ///
    /// <para>
    /// On the virtual device the managed heap is compiled in at 10 MB and cannot be reduced, so the
    /// low-memory condition of the original report cannot be reproduced here. What makes these
    /// tests meaningful instead is the <c>--forcegc</c> nanoclr runner argument configured in the
    /// repository .runsettings, which makes the execution engine collect on every context switch.
    /// That decouples collection frequency from heap pressure, which was the whole reason the
    /// available heap mattered on the reporter's device. Without it these tests are unlikely to
    /// fail even on an affected CLR.
    /// </para>
    ///
    /// <para>
    /// This remains a probabilistic test. It cannot prove the defect is absent, only catch a
    /// regression with reasonable probability.
    /// </para>
    /// </remarks>
    [TestClass]
    public class GetCustomAttributesGCTests
    {
        #region Attribute constructor arguments

        // Deliberately awkward values: wide exponents and long alternating bit patterns, so that a
        // partially overwritten or relocated value is very unlikely to compare equal by chance.
        public const double Double1Value = -5.34468764745428E-79;
        public const double Double2Value = -1.54947393917855E231;
        public const double Double3Value = 93939393939393;

        public const int Int1Value = 0x7AFAFAFA;
        public const int Int2Value = -2;
        public const int Int3Value = 0x03ADBEEF;

        public const ulong Ulong1Value = 0xDEADBEEFCAFEBABE;
        public const ulong Ulong2Value = 0xFEEDFACECAFEBEEF;
        public const ulong Ulong3Value = 0xABABABABABABABAB;

        #endregion

        #region Test tuning

        /// <summary>
        /// Number of passes over <see cref="DecoratedTypes"/>. Every pass re-decodes the attribute
        /// blob of every field of every type, which is the operation under test.
        /// </summary>
        private const int StressIterations = 250;

        /// <summary>
        /// Number of passes for the whole-assembly walk. Kept low because that walk is far more
        /// expensive per pass than the targeted one.
        /// </summary>
        private const int AssemblyWalkIterations = 20;

        private const int ProgressReportInterval = 25;

        /// <summary>Fingerprint reported for an attribute that takes no constructor argument.</summary>
        private const ulong NoParameterFingerprint = 0x4E4F5041524D5300;

        /// <summary>
        /// Fingerprint reported for an attribute type this test does not know how to read. Such an
        /// attribute still takes part in the attribute type comparison, only its value is not
        /// compared. This keeps the test from breaking if the compiler injects an attribute of its
        /// own onto one of the types below.
        /// </summary>
        private const ulong UnknownAttributeFingerprint = 0x554E4B4E4F574E00;

        private const BindingFlags AllInstanceFields =
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        private static readonly Type[] DecoratedTypes =
        {
            typeof(GcAbstractFields),
            typeof(GcDerivedFields),
            typeof(GcMixedFields),
            typeof(GcBooleanFields)
        };

        #endregion

        [TestMethod]
        public void GetCustomAttributes_DecodedValuesAreStableUnderGCPressure()
        {
            FieldInfo[] fields = GetDecoratedFields();

            OutputHelper.WriteLine($"Decoding attributes of {fields.Length} fields, {StressIterations} times.");

            // Capture what a single, unstressed pass produces and treat that as the expected result
            // for every subsequent pass. Comparing against a captured baseline rather than against
            // hard-coded expectations keeps the test honest about attribute shapes this CLR cannot
            // construct at all: GetCustomAttributesInternal silently skips an attribute whose
            // constructor it cannot resolve, and that is a separate concern from this defect.
            Type[][] baselineTypes;
            ulong[][] baselineFingerprints;

            ReadAttributes(fields, out baselineTypes, out baselineFingerprints);

            int baselineCount = 0;

            foreach (Type[] attributeTypes in baselineTypes)
            {
                baselineCount += attributeTypes.Length;
            }

            OutputHelper.WriteLine($"Baseline: {baselineCount} attributes decoded across {fields.Length} fields.");

            // Guard against the whole test silently degenerating into asserting that zero
            // attributes stay zero.
            Assert.IsTrue(
                baselineCount > 0,
                $"Expected the baseline pass to decode at least one attribute but it decoded {baselineCount}. The test types are no longer being seen as decorated.");

            // Also pin down a couple of values outright, so that a corruption which happened to be
            // present in the baseline pass as well does not go unnoticed.
            AssertKnownValues(baselineTypes, baselineFingerprints, fields);

            AllocationPressure pressure = new AllocationPressure();

            pressure.Start();

            try
            {
                for (int iteration = 1; iteration <= StressIterations; iteration++)
                {
                    Type[][] iterationTypes;
                    ulong[][] iterationFingerprints;

                    ReadAttributes(fields, out iterationTypes, out iterationFingerprints);

                    AssertMatchesBaseline(
                        fields,
                        baselineTypes,
                        baselineFingerprints,
                        iterationTypes,
                        iterationFingerprints,
                        iteration);

                    // Yield so the execution engine performs a context switch, which is what
                    // triggers a collection under --forcegc.
                    Thread.Sleep(0);

                    if (iteration % ProgressReportInterval == 0)
                    {
                        OutputHelper.WriteLine($"Completed iteration {iteration} of {StressIterations}.");
                    }
                }
            }
            finally
            {
                pressure.Stop();
            }
        }

        [TestMethod]
        public void GetCustomAttributes_OverWholeAssembly_DoesNotThrow()
        {
            // The shape of the original reproducing application: walk every type of the executing
            // assembly and read the attributes of every field. In this project that also covers all
            // the attribute types declared by the other test files, so it keeps picking up new
            // attribute shapes as they are added to this project without needing to be updated.
            //
            // Nothing is caught here on purpose. An exception escaping GetCustomAttributes is the
            // exact symptom reported in Home#1829 and must fail the test.
            Assembly assembly = Assembly.GetExecutingAssembly();

            int baselineAttributes = WalkAssembly(assembly);

            OutputHelper.WriteLine($"Baseline: {baselineAttributes} attributes decoded across the assembly.");

            Assert.IsTrue(
                baselineAttributes > 0,
                $"Expected the assembly walk to decode at least one attribute but it decoded {baselineAttributes}.");

            AllocationPressure pressure = new AllocationPressure();

            pressure.Start();

            try
            {
                for (int iteration = 1; iteration <= AssemblyWalkIterations; iteration++)
                {
                    int attributes = WalkAssembly(assembly);

                    Assert.AreEqual(
                        baselineAttributes,
                        attributes,
                        $"Iteration {iteration} decoded {attributes} attributes across the assembly but the baseline pass decoded {baselineAttributes}.");

                    Thread.Sleep(0);
                }
            }
            finally
            {
                pressure.Stop();
            }
        }

        #region Helpers

        private static FieldInfo[] GetDecoratedFields()
        {
            ArrayList fields = new ArrayList();

            foreach (Type type in DecoratedTypes)
            {
                foreach (FieldInfo field in type.GetFields(AllInstanceFields))
                {
                    fields.Add(field);
                }
            }

            return (FieldInfo[])fields.ToArray(typeof(FieldInfo));
        }

        /// <summary>
        /// Reads the custom attributes of every field, returning the attribute types and a value
        /// fingerprint for each, both indexed by field.
        /// </summary>
        private static void ReadAttributes(
            FieldInfo[] fields,
            out Type[][] attributeTypes,
            out ulong[][] fingerprints)
        {
            attributeTypes = new Type[fields.Length][];
            fingerprints = new ulong[fields.Length][];

            for (int i = 0; i < fields.Length; i++)
            {
                object[] attributes = fields[i].GetCustomAttributes(false);

                Type[] types = new Type[attributes.Length];
                ulong[] values = new ulong[attributes.Length];

                for (int a = 0; a < attributes.Length; a++)
                {
                    types[a] = attributes[a].GetType();
                    values[a] = Fingerprint(attributes[a]);
                }

                attributeTypes[i] = types;
                fingerprints[i] = values;
            }
        }

        /// <summary>
        /// Reduces an attribute instance to the exact bit pattern of its constructor argument, so
        /// that a comparison catches every altered bit - including a double whose mantissa was
        /// partially overwritten, which a tolerance-based comparison could miss.
        /// </summary>
        private static ulong Fingerprint(object attribute)
        {
            switch (attribute)
            {
                case GcNoParamAttribute _:
                    return NoParameterFingerprint;

                case GcDouble1Attribute double1:
                    return (ulong)BitConverter.DoubleToInt64Bits(double1.Value);

                case GcDouble2Attribute double2:
                    return (ulong)BitConverter.DoubleToInt64Bits(double2.Value);

                case GcDouble3Attribute double3:
                    return (ulong)BitConverter.DoubleToInt64Bits(double3.Value);

                case GcInt1Attribute int1:
                    return (uint)int1.Value;

                case GcInt2Attribute int2:
                    return (uint)int2.Value;

                case GcInt3Attribute int3:
                    return (uint)int3.Value;

                case GcUlong1Attribute ulong1:
                    return ulong1.Value;

                case GcUlong2Attribute ulong2:
                    return ulong2.Value;

                case GcUlong3Attribute ulong3:
                    return ulong3.Value;

                default:
                    return UnknownAttributeFingerprint;
            }
        }

        /// <summary>
        /// Compares one pass against the baseline. Deliberately allocation free while everything
        /// matches: the comparison runs tens of thousands of times, and building an assertion
        /// message for each one would generate more garbage than the code under test does, as well
        /// as dominating the test's runtime. Messages are built only on the failing comparison.
        /// </summary>
        private static void AssertMatchesBaseline(
            FieldInfo[] fields,
            Type[][] baselineTypes,
            ulong[][] baselineFingerprints,
            Type[][] iterationTypes,
            ulong[][] iterationFingerprints,
            int iteration)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                if (iterationTypes[i].Length != baselineTypes[i].Length)
                {
                    Assert.AreEqual(
                        baselineTypes[i].Length,
                        iterationTypes[i].Length,
                        $"Iteration {iteration}: field {Describe(fields[i])} returned {iterationTypes[i].Length} attributes but the baseline pass returned {baselineTypes[i].Length}.");
                }

                for (int a = 0; a < baselineTypes[i].Length; a++)
                {
                    // Reference comparison first: the runtime hands out a single Type instance per
                    // type, so this matches on the happy path without touching FullName, which
                    // builds a string on every call.
                    if (!ReferenceEquals(baselineTypes[i][a], iterationTypes[i][a])
                        && baselineTypes[i][a].FullName != iterationTypes[i][a].FullName)
                    {
                        Assert.AreEqual(
                            baselineTypes[i][a].FullName,
                            iterationTypes[i][a].FullName,
                            $"Iteration {iteration}: attribute {a} of field {Describe(fields[i])} is of type {iterationTypes[i][a].FullName} but the baseline pass returned {baselineTypes[i][a].FullName}.");
                    }

                    if (iterationFingerprints[i][a] != baselineFingerprints[i][a])
                    {
                        Assert.AreEqual(
                            baselineFingerprints[i][a],
                            iterationFingerprints[i][a],
                            $"Iteration {iteration}: attribute {a} ({baselineTypes[i][a].Name}) of field {Describe(fields[i])} decoded to 0x{iterationFingerprints[i][a].ToString("X16")} but the baseline pass decoded 0x{baselineFingerprints[i][a].ToString("X16")}.");
                    }
                }
            }
        }

        private static string Describe(FieldInfo field)
        {
            return $"{field.DeclaringType.FullName}.{field.Name}";
        }

        /// <summary>
        /// Asserts the decoded value of the single-argument double and int attributes on one known
        /// field. Only these two argument shapes are pinned down, because they mirror the
        /// single numeric constructor argument already exercised by <see cref="ConstructorTests"/>
        /// and are therefore known to be constructible on a healthy CLR. Everything else is left to
        /// the baseline comparison.
        /// </summary>
        private static void AssertKnownValues(
            Type[][] baselineTypes,
            ulong[][] baselineFingerprints,
            FieldInfo[] fields)
        {
            int index = IndexOfField(fields, typeof(GcMixedFields), nameof(GcMixedFields.KnownValues));

            Assert.IsTrue(
                index >= 0,
                $"Could not find field {nameof(GcMixedFields)}.{nameof(GcMixedFields.KnownValues)} among the decorated fields.");

            AssertKnownValue(
                baselineTypes[index],
                baselineFingerprints[index],
                typeof(GcDouble1Attribute),
                (ulong)BitConverter.DoubleToInt64Bits(Double1Value));

            AssertKnownValue(
                baselineTypes[index],
                baselineFingerprints[index],
                typeof(GcInt1Attribute),
                (uint)Int1Value);
        }

        private static void AssertKnownValue(
            Type[] attributeTypes,
            ulong[] fingerprints,
            Type attributeType,
            ulong expected)
        {
            for (int a = 0; a < attributeTypes.Length; a++)
            {
                if (attributeTypes[a].FullName == attributeType.FullName)
                {
                    Assert.AreEqual(
                        expected,
                        fingerprints[a],
                        $"{attributeType.Name} decoded to 0x{fingerprints[a].ToString("X16")} instead of the expected 0x{expected.ToString("X16")}.");

                    return;
                }
            }

            Assert.IsTrue(
                false,
                $"{attributeType.Name} was not returned for the field it is applied to. It could not be constructed by this CLR, so its value cannot be verified.");
        }

        private static int IndexOfField(FieldInfo[] fields, Type declaringType, string name)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].Name == name
                    && fields[i].DeclaringType.FullName == declaringType.FullName)
                {
                    return i;
                }
            }

            return -1;
        }

        private static int WalkAssembly(Assembly assembly)
        {
            int attributeCount = 0;

            foreach (Type type in assembly.GetTypes())
            {
                foreach (FieldInfo field in type.GetFields(AllInstanceFields))
                {
                    attributeCount += field.GetCustomAttributes(false).Length;
                }
            }

            return attributeCount;
        }

        /// <summary>
        /// Background thread that allocates and yields, so that the thread reading attributes is
        /// competing with another thread for the heap. Assertions are deliberately kept off this
        /// thread: the test framework only observes the thread running the test method, so an
        /// assertion failing here would be swallowed rather than failing the test.
        /// </summary>
        private sealed class AllocationPressure
        {
            private readonly Thread _thread;
            // 1 = running, 0 = stop requested.  Written by Stop() on one thread and read by
            // Churn() on another; Interlocked.Exchange guarantees the write is visible
            // cross-thread without needing volatile or a memory barrier.
            private int _running;

            public AllocationPressure()
            {
                _thread = new Thread(Churn);
            }

            public void Start()
            {
                Interlocked.Exchange(ref _running, 1);

                _thread.Start();
            }

            public void Stop()
            {
                Interlocked.Exchange(ref _running, 0);

                _thread.Join();
            }

            private void Churn()
            {
                int size = 16;

                while (Interlocked.CompareExchange(ref _running, 1, 1) == 1)
                {
                    // Discarded immediately: the point is to keep handing the collector work to do
                    // and to keep the heap from settling into a stable layout.
                    byte[] block = new byte[size];

                    block[0] = 1;

                    size = size >= 4096 ? 16 : size * 2;

                    // Sleep rather than spin: the forced collection happens on the context switch,
                    // not on the allocation, so yielding regularly is worth more here than raw
                    // allocation volume - and it keeps this thread from starving the test thread.
                    Thread.Sleep(1);
                }
            }
        }

        #endregion
    }

    #region Attributes under test

    // Ported from the reproducing application. Prefixed to keep them clear of the attribute types
    // declared by the other test files in this project.

    public class GcNoParamAttribute : Attribute
    {
    }

    public class GcDouble1Attribute : Attribute
    {
        public GcDouble1Attribute(double value)
        {
            Value = value;
        }

        public double Value { get; }
    }

    public class GcDouble2Attribute : Attribute
    {
        public GcDouble2Attribute(double value)
        {
            Value = value;
        }

        public double Value { get; }
    }

    public class GcDouble3Attribute : Attribute
    {
        public GcDouble3Attribute(double value)
        {
            Value = value;
        }

        public double Value { get; }
    }

    public class GcInt1Attribute : Attribute
    {
        public GcInt1Attribute(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public class GcInt2Attribute : Attribute
    {
        public GcInt2Attribute(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public class GcInt3Attribute : Attribute
    {
        public GcInt3Attribute(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public class GcUlong1Attribute : Attribute
    {
        public GcUlong1Attribute(ulong value)
        {
            Value = value;
        }

        public ulong Value { get; }
    }

    public class GcUlong2Attribute : Attribute
    {
        public GcUlong2Attribute(ulong value)
        {
            Value = value;
        }

        public ulong Value { get; }
    }

    public class GcUlong3Attribute : Attribute
    {
        public GcUlong3Attribute(ulong value)
        {
            Value = value;
        }

        public ulong Value { get; }
    }

    #endregion

    #region Types under test

    // Ported from the reproducing application, trimmed from ~60 decorated fields to ~30. The mix
    // matters more than the count: several attributes per field, several argument types, and an
    // inheritance chain so that the inherited-field walk is covered as well.

    public abstract class GcAbstractFields
    {
        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        public double D1 = 2137;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        public double D2 = 42;

        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        public string S = "";

        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        public bool Enabled = true;

        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        public double D3 = 31137;
    }

    public sealed class GcDerivedFields : GcAbstractFields
    {
        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public bool O = false;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public string S2 = "false";

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public string S3 = "true";

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public bool B = false;
    }

    public class GcMixedFields
    {
        /// <summary>
        /// The one field whose decoded values are asserted against hard-coded expectations rather
        /// than against a captured baseline. Do not change its attributes without updating
        /// <c>AssertKnownValues</c>.
        /// </summary>
        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value)]
        public double KnownValues = 0;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value), GcDouble3(GetCustomAttributesGCTests.Double3Value)]
        public double D1 = double.NaN;

        [GcNoParam]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        public double D2 = double.NaN;

        [GcNoParam]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public double D3 = double.NaN;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public double D4 = double.NaN;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public double D5 = double.NaN;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public double D6 = double.NaN;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public double D7 = double.NaN;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public double D8 = double.NaN;

        // Deliberately undecorated: the walk must cope with fields that carry no attributes at all.
        public double D9 = 0.0;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public double P = 0;
    }

    public class GcBooleanFields
    {
        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public bool B1 = false;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public bool B2 = false;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public bool B3 = false;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public bool B4 = false;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public bool B5 = false;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public bool B6 = false;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public bool B7 = false;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public bool B8 = false;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public bool B9 = false;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public bool B10 = false;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public bool B11 = false;

        [GcNoParam]
        [GcDouble1(GetCustomAttributesGCTests.Double1Value), GcDouble2(GetCustomAttributesGCTests.Double2Value)]
        [GcInt1(GetCustomAttributesGCTests.Int1Value), GcInt2(GetCustomAttributesGCTests.Int2Value), GcInt3(GetCustomAttributesGCTests.Int3Value)]
        [GcUlong1(GetCustomAttributesGCTests.Ulong1Value), GcUlong2(GetCustomAttributesGCTests.Ulong2Value), GcUlong3(GetCustomAttributesGCTests.Ulong3Value)]
        public double D1 = 0;
    }

    #endregion
}

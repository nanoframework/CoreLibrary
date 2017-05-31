//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#define ENABLE_CROSS_APPDOMAIN
namespace System.Globalization
{
    using System;
    using Collections;
    using Runtime.CompilerServices;
    using System.Resources;

    /// <summary>
    /// Provides information about a specific culture (called a locale for unmanaged code development). 
    /// The information includes the names for the culture, the writing system, the calendar used, the sort order of strings, and formatting for dates and numbers.
    /// </summary>
    public class CultureInfo /*: ICloneable , IFormatProvider*/
    {
        internal NumberFormatInfo _numInfo;
        internal DateTimeFormatInfo _dateTimeInfo;
        internal string _cultureInfoName;
        internal ResourceManager _cultureInfoResourceManager;
        [NonSerialized]
        private CultureInfo _parent;
        const string ResourceBase = "System.Globalization.Resources.CultureInfo";

        internal string EnsureStringResource(ref string str, Resources.CultureInfo.StringResources id)
        {
            if (str == null) str = (string)ResourceManager.GetObject(_cultureInfoResourceManager, id);

            return str;
        }

        internal string[] EnsureStringArrayResource(ref string[] strArray, Resources.CultureInfo.StringResources id)
        {
            if (strArray == null)
            {
                var str = (string)ResourceManager.GetObject(_cultureInfoResourceManager, id);
                strArray = str.Split('|');
            }

            return (string[])strArray.Clone();
        }

        /// <summary>
        /// Initializes a new instance of the CultureInfo class based on the culture specified by name.
        /// </summary>
        /// <param name="name">A predefined CultureInfo name, Name of an existing CultureInfo, or Windows-only culture name. name is not case-sensitive.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CultureInfo(string name)
        {
            if (name == null) throw new ArgumentNullException("name");

            _cultureInfoResourceManager = new ResourceManager(ResourceBase, typeof(CultureInfo).Assembly, name, true);
            _cultureInfoName = _cultureInfoResourceManager._cultureName;
        }

        internal CultureInfo(ResourceManager resourceManager)
        {
            _cultureInfoResourceManager = resourceManager;
            _cultureInfoName = resourceManager._cultureName;
        }

        /// <summary>
        /// Gets or sets the CultureInfo object that represents the current user interface culture used by the Resource Manager to look up culture-specific resources at run time.
        /// </summary>
        /// <value>The culture used by the Resource Manager to look up culture-specific resources at run time.</value>
        public static CultureInfo CurrentUICulture
        {
            get
            {
                //only one system-wide culture.  We do not currently support per-thread cultures
                var culture = CurrentUICultureInternal;
                if (culture == null)
                {
                    culture = new CultureInfo("");
                    CurrentUICultureInternal = culture;
                }

                return culture;
            }
        }

        private static extern CultureInfo CurrentUICultureInternal
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

        /// <summary>
        /// Gets the CultureInfo that represents the parent culture of the current CultureInfo.
        /// </summary>
        /// <value>The CultureInfo that represents the parent culture of the current CultureInfo.</value>
        public virtual CultureInfo Parent
        {
            get
            {
                if (_parent == null)
                {
                    if (_cultureInfoName == "") //Invariant culture
                    {
                        _parent = this;
                    }
                    else
                    {
                        var parentName = _cultureInfoName;
                        var iDash = _cultureInfoName.LastIndexOf('-');
                        parentName = iDash >= 0 ? parentName.Substring(0, iDash) : "";

                        _parent = new CultureInfo(parentName);
                    }
                }

                return _parent;
            }
        }

        /// <summary>
        /// Gets the list of supported cultures filtered by the specified CultureTypes parameter.
        /// </summary>
        /// <param name="types">A bitwise combination of the enumeration values that filter the cultures to retrieve.</param>
        /// <returns>An array that contains the cultures specified by the types parameter. The array of cultures is unsorted.</returns>
        public static CultureInfo[] GetCultures(CultureTypes types)
        {
            var listCultures = new ArrayList();
            //Look for all assemblies/satellite assemblies
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (var iAssembly = 0; iAssembly < assemblies.Length; iAssembly++)
            {
                var assembly = assemblies[iAssembly];
                var mscorlib = "mscorlib";
                var fullName = assembly.FullName;
                // consider adding startswith ?
                if (mscorlib.Length <= fullName.Length && fullName.Substring(0, mscorlib.Length) == mscorlib)
                {
                    var resources = assembly.GetManifestResourceNames();
                    for (var iResource = 0; iResource < resources.Length; iResource++)
                    {
                        var resource = resources[iResource];
                        if (ResourceBase.Length < resource.Length && resource.Substring(0, ResourceBase.Length) == ResourceBase)
                        {
                            //System.Globalization.Resources.CultureInfo.<culture>.tinyresources
                            var cultureName = resource.Substring(ResourceBase.Length, resource.Length - ResourceBase.Length - ResourceManager.FileExtension.Length);
                            // remove the leading "."
                            if (cultureName != "") cultureName = cultureName.Substring(1, cultureName.Length - 1);

                            // if GetManifestResourceNames() changes, we need to change this code to ensure the index is the same.
                            listCultures.Add(new CultureInfo(new ResourceManager(ResourceBase, cultureName, iResource, typeof(CultureInfo).Assembly, assembly)));
                        }
                    }
                }
            }

            return (CultureInfo[])listCultures.ToArray(typeof(CultureInfo));
        }

        /// <summary>
        /// Gets the culture name in the format languagecode2-country/regioncode2.
        /// </summary>
        /// <value>The culture name in the format languagecode2-country/regioncode2. languagecode2 is a lowercase two-letter code derived from ISO 639-1. 
        /// country/regioncode2 is derived from ISO 3166 and usually consists of two uppercase letters, or a BCP-47 language tag.</value>
        public virtual String Name
        {
            get
            {
                return _cultureInfoName;
            }
        }

        /// <summary>
        /// Returns a string containing the name of the current CultureInfo in the format languagecode2-country/regioncode2.
        /// </summary>
        /// <returns>A string containing the name of the current CultureInfo.</returns>
        public override String ToString()
        {
            return _cultureInfoName;
        }

        //        public virtual Object GetFormat(Type formatType) {
        //            if (formatType == typeof(NumberFormatInfo)) {
        //                return (NumberFormat);
        //            }
        //            if (formatType == typeof(DateTimeFormatInfo)) {
        //                return (DateTimeFormat);
        //            }
        //            return (null);
        //        }

        //        internal static void CheckNeutral(CultureInfo culture) {
        //            if (culture.IsNeutralCulture) {
        //                    BCLDebug.Assert(culture.m_name != null, "[CultureInfo.CheckNeutral]Always expect m_name to be set");
        //                    throw new NotSupportedException(
        //                                    Environment.GetResourceString("Argument_CultureInvalidFormat",
        //                                    culture.m_name));
        //            }
        //        }

        //        [System.Runtime.InteropServices.ComVisible(false)]
        //        public CultureTypes CultureTypes
        //        {
        //            get
        //            {
        //                CultureTypes types = 0;

        //                if (m_cultureTableRecord.IsNeutralCulture)
        //                    types |= CultureTypes.NeutralCultures;
        //                else 
        //                    types |= CultureTypes.SpecificCultures;

        //                if (m_cultureTableRecord.IsSynthetic)
        //                    types |= CultureTypes.WindowsOnlyCultures | CultureTypes.InstalledWin32Cultures; // Synthetic is installed culture too.
        //                else
        //                {
        //                  // Not Synthetic
        //                    if (CultureTable.IsInstalledLCID(cultureID)) 
        //                        types |= CultureTypes.InstalledWin32Cultures;

        //                    if (!m_cultureTableRecord.IsCustomCulture || m_cultureTableRecord.IsReplacementCulture)
        //                        types |= CultureTypes.FrameworkCultures;
        //                }

        //                if (m_cultureTableRecord.IsCustomCulture)
        //                {
        //                    types |= CultureTypes.UserCustomCulture;

        //                    if (m_cultureTableRecord.IsReplacementCulture)
        //                        types |= CultureTypes.ReplacementCultures;
        //                }

        //                return types;
        //            }
        //        }

        /// <summary>
        /// Gets or sets a NumberFormatInfo that defines the culturally appropriate format of displaying numbers, currency, and percentage.
        /// </summary>
        /// <value>A NumberFormatInfo that defines the culturally appropriate format of displaying numbers, currency, and percentage.</value>
        public virtual NumberFormatInfo NumberFormat
        {
            get
            {

                if (_numInfo == null) _numInfo = new NumberFormatInfo(this);

                return _numInfo;
            }
        }

        /// <summary>
        /// Gets or sets a DateTimeFormatInfo that defines the culturally appropriate format of displaying dates and times.
        /// </summary>
        /// <value>A DateTimeFormatInfo that defines the culturally appropriate format of displaying dates and times.</value>
        public virtual DateTimeFormatInfo DateTimeFormat
        {
            get
            {
                if (_dateTimeInfo == null) _dateTimeInfo = new DateTimeFormatInfo(this);

                return _dateTimeInfo;
            }
        }
    }
}

//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace System.Resources
{
    /// <summary>
    /// Represents a resource manager that provides convenient access to culture-specific resources at run time.
    /// </summary>
    public class ResourceManager
    {
        internal const string FileExtension = ".nanoresources";
        internal const string ResourcesExtension = ".resources";

        private int _resourceFileId;
        internal string _cultureName;
        private ResourceManager _rmFallback;

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern int FindResource(string baseName, Assembly assembly);

        /// <summary>
        /// Initializes a new instance of the ResourceManager class that looks up resources contained in files with the specified root name in the given assembly.
        /// </summary>
        /// <param name="baseName">The root name of the resource file without its extension but including any fully qualified namespace name. 
        /// For example, the root name for the resource file named MyApplication.MyResource.en-US.resources is MyApplication.MyResource.</param>
        /// <param name="assembly">The main assembly for the resources.</param>
        public ResourceManager(string baseName, Assembly assembly)
            : this(baseName, assembly, CultureInfo.CurrentUICulture.Name, true)
        {
        }

        internal ResourceManager(string baseName, Assembly assembly, string cultureName, bool fThrowOnFailure)
        {
            if (!Initialize(baseName, assembly, cultureName))
            {
                if (fThrowOnFailure) throw new ArgumentException();
            }
        }

        internal ResourceManager(string baseName, string cultureName, int iResourceFileId, Assembly assemblyBase, Assembly assemblyResource)
        {
            _cultureName = cultureName;
            _resourceFileId = iResourceFileId;
        }

        private bool IsValid
        {
            get { return _resourceFileId >= 0; }
        }

        private string GetParentCultureName(string cultureName)
        {
            var iDash = cultureName.LastIndexOf('-');
            cultureName = iDash < 0 ? "" : cultureName.Substring(0, iDash);

            return cultureName;
        }

        internal bool Initialize(string baseName, Assembly assembly, string cultureName)
        {
            var cultureNameSav = cultureName;
            var assemblySav = assembly;

            _resourceFileId = -1;  //set to invalid state

            var fTryBaseAssembly = false;

            while (true)
            {
                var fInvariantCulture = (cultureName == "");
                var splitName = assemblySav.FullName.Split(',');
                var assemblyName = splitName[0];

                if (!fInvariantCulture)
                {
                    assemblyName = assemblyName + "." + cultureName;
                }
                else if (!fTryBaseAssembly)
                {
                    assemblyName = assemblyName + ResourcesExtension;
                }

                // append version
                if (splitName.Length >= 1 && splitName[1] != null) assemblyName += ", " + splitName[1].Trim();

                assembly = Assembly.Load(assemblyName, false);

                if (assembly != null)
                {
                    if (Initialize(baseName, assemblySav, cultureNameSav, assembly)) return true;
                }

                if (!fInvariantCulture)
                {
                    cultureName = GetParentCultureName(cultureName);
                }
                else if (!fTryBaseAssembly)
                {
                    fTryBaseAssembly = true;
                }
                else
                {
                    break;
                }
            }

            return false;
        }

        internal bool Initialize(string baseName, Assembly assemblyBase, string cultureName, Assembly assemblyResource)
        {
            while (true)
            {
                var resourceName = baseName;
                var fInvariantCulture = (cultureName == "");

                if (!fInvariantCulture) resourceName = baseName + "." + cultureName;

                resourceName = resourceName + FileExtension;

                var iResourceFileId = FindResource(resourceName, assemblyResource);

                if (iResourceFileId >= 0)
                {
                    _cultureName = cultureName;
                    _resourceFileId = iResourceFileId;

                    break;
                }
                if (fInvariantCulture) break;

                cultureName = GetParentCultureName(cultureName);
            }

            return IsValid;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern object GetObject(ResourceManager rm, Enum id);
    }
}

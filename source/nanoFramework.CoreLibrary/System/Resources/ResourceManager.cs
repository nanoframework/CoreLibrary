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
        internal const string _fileExtension = ".nanoresources";
        internal const string _resourcesExtension = ".resources";

        private int _resourceFileId;
        private Assembly _assembly;
        private Assembly _baseAssembly;
        private string _baseName;
        internal string _cultureName;
        private ResourceManager _rmFallback;

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern private object GetObjectInternal(short id);

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern private object GetObjectInternal(short id, int offset, int length);

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
                if (fThrowOnFailure)
                {
                    throw new ArgumentException();
                }
            }
        }

        internal ResourceManager(string baseName, string cultureName, int iResourceFileId, Assembly assemblyBase, Assembly assemblyResource)
        {
            //found resource
            this._baseAssembly = assemblyBase;
            this._assembly = assemblyResource;
            this._baseName = baseName;
            this._cultureName = cultureName;
            this._resourceFileId = iResourceFileId;
        }

        private bool IsValid
        {
            get { return _resourceFileId >= 0; }
        }

        private string GetParentCultureName(string cultureName)
        {
            int iDash = cultureName.LastIndexOf('-');
            if (iDash < 0)
                cultureName = "";
            else
                cultureName = cultureName.Substring(0, iDash);

            return cultureName;
        }

        internal bool Initialize(string baseName, Assembly assembly, string cultureName)
        {
            string cultureNameSav = cultureName;
            Assembly assemblySav = assembly;

            _resourceFileId = -1;  //set to invalid state

            bool fTryBaseAssembly = false;

            while (true)
            {
                bool fInvariantCulture = (cultureName == "");

                string[] splitName = assemblySav.FullName.Split(',');

                string assemblyName = splitName[0];

                if (!fInvariantCulture)
                {
                    assemblyName = assemblyName + "." + cultureName;
                }
                else if (!fTryBaseAssembly)
                {
                    assemblyName = assemblyName + _resourcesExtension;
                }

                // append version
                if (splitName.Length >= 1 && splitName[1] != null)
                {
                    assemblyName += ", " + splitName[1].Trim();
                }

                assembly = Assembly.Load(assemblyName, false);

                if (assembly != null)
                {
                    if (Initialize(baseName, assemblySav, cultureNameSav, assembly))
                        return true;
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
                string resourceName = baseName;
                bool fInvariantCulture = (cultureName == "");

                if (!fInvariantCulture)
                {
                    resourceName = baseName + "." + cultureName;
                }

                resourceName = resourceName + _fileExtension;

                int iResourceFileId = FindResource(resourceName, assemblyResource);

                if (iResourceFileId >= 0)
                {
                    //found resource
                    this._baseAssembly = assemblyBase;
                    this._assembly = assemblyResource;
                    this._baseName = baseName;
                    this._cultureName = cultureName;
                    this._resourceFileId = iResourceFileId;

                    break;
                }
                else if (fInvariantCulture)
                {
                    break;
                }

                cultureName = GetParentCultureName(cultureName);
            }

            return this.IsValid;
        }

        private object GetObjectFromId(short id)
        {
            ResourceManager rm = this;

            while (rm != null)
            {
                object obj = rm.GetObjectInternal(id);

                if (obj != null)
                    return obj;

                if (rm._rmFallback == null)
                {
                    if (rm._cultureName != "")
                    {
                        string cultureNameParent = GetParentCultureName(rm._cultureName);
                        ResourceManager rmFallback = new ResourceManager(_baseName, _baseAssembly, cultureNameParent, false);

                        if (rmFallback.IsValid)
                            rm._rmFallback = rmFallback;
                    }
                }

                rm = rm._rmFallback;
            }

            throw new ArgumentException();
        }

        private object GetObjectChunkFromId(short id, int offset, int length)
        {
            ResourceManager rm = this;

            while (rm != null)
            {
                object obj = rm.GetObjectInternal(id, offset, length);

                if (obj != null)
                    return obj;

                if (rm._rmFallback == null)
                {
                    if (rm._cultureName != "")
                    {
                        string cultureNameParent = GetParentCultureName(rm._cultureName);
                        ResourceManager rmFallback = new ResourceManager(_baseName, _baseAssembly, cultureNameParent, false);

                        if (rmFallback.IsValid)
                            rm._rmFallback = rmFallback;
                    }
                }

                rm = rm._rmFallback;
            }

            throw new ArgumentException();
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern object GetObject(ResourceManager rm, Enum id);
    }
}

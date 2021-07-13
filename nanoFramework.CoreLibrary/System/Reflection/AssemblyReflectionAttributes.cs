//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Reflection
{
    using System;

    /// <summary>
    /// Defines a copyright custom attribute for an assembly manifest.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyCopyrightAttribute : Attribute
    {
        private readonly String _copyright;

        /// <summary>
        /// Initializes a new instance of the AssemblyCopyrightAttribute class.
        /// </summary>
        /// <param name="copyright">The copyright information.</param>
        public AssemblyCopyrightAttribute(String copyright)
        {
            _copyright = copyright;
        }

        /// <summary>
        /// Gets copyright information.
        /// </summary>
        /// <value>
        /// A string containing the copyright information.
        /// </value>
        public String Copyright
        {
            get { return _copyright; }
        }
    }

    /// <summary>
    /// Defines a trademark custom attribute for an assembly manifest.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyTrademarkAttribute : Attribute
    {
        private readonly String _trademark;

        /// <summary>
        /// Initializes a new instance of the AssemblyTrademarkAttribute class.
        /// </summary>
        /// <param name="trademark">The trademark information.</param>
        public AssemblyTrademarkAttribute(String trademark)
        {
            _trademark = trademark;
        }

        /// <summary>
        /// Gets trademark information.
        /// </summary>
        /// <value>
        /// A String containing trademark information.
        /// </value>
        public String Trademark
        {
            get { return _trademark; }
        }
    }

    /// <summary>
    /// Defines a product name custom attribute for an assembly manifest.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyProductAttribute : Attribute
    {
        private readonly String _product;

        /// <summary>
        /// Initializes a new instance of the AssemblyProductAttribute class.
        /// </summary>
        /// <param name="product">The product name information.</param>
        public AssemblyProductAttribute(String product)
        {
            _product = product;
        }

        /// <summary>
        /// Gets product name information.
        /// </summary>
        /// <value>
        /// A string containing the product name.
        /// </value>
        public String Product
        {
            get { return _product; }
        }
    }

    /// <summary>
    /// Defines a company name custom attribute for an assembly manifest.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyCompanyAttribute : Attribute
    {
        private readonly String _company;

        /// <summary>
        /// Initializes a new instance of the AssemblyCompanyAttribute class.
        /// </summary>
        /// <param name="company">The company name information.</param>
        public AssemblyCompanyAttribute(String company)
        {
            _company = company;
        }

        /// <summary>
        /// Gets company name information.
        /// </summary>
        /// <value>
        /// A string containing the company name.
        /// </value>
        public String Company
        {
            get { return _company; }
        }
    }

    /// <summary>
    /// Provides a text description for an assembly.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyDescriptionAttribute : Attribute
    {
        private readonly String _description;

        /// <summary>
        /// Initializes a new instance of the AssemblyDescriptionAttribute class.
        /// </summary>
        /// <param name="description">The assembly description.</param>
        public AssemblyDescriptionAttribute(String description)
        {
            _description = description;
        }

        /// <summary>
        /// Gets assembly description information.
        /// </summary>
        /// <value>
        /// A string containing the assembly description.
        /// </value>
        public String Description
        {
            get { return _description; }
        }
    }

    /// <summary>
    /// Specifies a description for an assembly.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyTitleAttribute : Attribute
    {
        private readonly String _title;

        /// <summary>
        /// Initializes a new instance of the AssemblyTitleAttribute class.
        /// </summary>
        /// <param name="title">The assembly title.</param>
        public AssemblyTitleAttribute(String title)
        {
            _title = title;
        }

        /// <summary>
        /// Gets assembly title information.
        /// </summary>
        /// <value>
        /// The assembly title.
        /// </value>
        public String Title
        {
            get { return _title; }
        }
    }

    /// <summary>
    /// Specifies the build configuration, such as retail or debug, for an assembly.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyConfigurationAttribute : Attribute
    {
        private readonly String _configuration;

        /// <summary>
        /// Initializes a new instance of the AssemblyConfigurationAttribute class.
        /// </summary>
        /// <param name="configuration">The assembly configuration.</param>
        public AssemblyConfigurationAttribute(String configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Gets assembly configuration information.
        /// </summary>
        /// <value>
        /// A string containing the assembly configuration information.
        /// </value>
        public String Configuration
        {
            get { return _configuration; }
        }
    }

    /// <summary>
    /// Defines a friendly default alias for an assembly manifest.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyDefaultAliasAttribute : Attribute
    {
        private readonly String _defaultAlias;

        /// <summary>
        /// Initializes a new instance of the AssemblyDefaultAliasAttribute class.
        /// </summary>
        /// <param name="defaultAlias">The assembly default alias information.</param>
        public AssemblyDefaultAliasAttribute(String defaultAlias)
        {
            _defaultAlias = defaultAlias;
        }

        /// <summary>
        /// Gets default alias information.
        /// </summary>
        /// <value>
        /// A string containing the default alias information.
        /// </value>
        public String DefaultAlias
        {
            get { return _defaultAlias; }
        }
    }

    /// <summary>
    /// Defines additional version information for an assembly manifest.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyInformationalVersionAttribute : Attribute
    {
        private readonly String _informationalVersion;

        /// <summary>
        /// Initializes a new instance of the AssemblyInformationalVersionAttribute class.
        /// </summary>
        /// <param name="informationalVersion">The assembly version information.</param>
        public AssemblyInformationalVersionAttribute(String informationalVersion)
        {
            _informationalVersion = informationalVersion;
        }

        /// <summary>
        /// Gets version information.
        /// </summary>
        /// <value>
        /// A string containing the version information.
        /// </value>
        public String InformationalVersion
        {
            get { return _informationalVersion; }
        }
    }
}

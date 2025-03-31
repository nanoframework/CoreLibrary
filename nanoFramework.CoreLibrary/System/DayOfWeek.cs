// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Specifies the day of the week.
    /// </summary>
    [Serializable]
    [ExcludeType]
    public enum DayOfWeek
    {
        /// <summary>
        /// Indicates Sunday
        /// </summary>
        Sunday = 0,
        /// <summary>
        /// Indicates Monday
        /// </summary>
        Monday = 1,
        /// <summary>
        /// Indicates Tuesday
        /// </summary>
        Tuesday = 2,
        /// <summary>
        /// Indicates Wednesday
        /// </summary>
        Wednesday = 3,
        /// <summary>
        /// Indicates Thursday
        /// </summary>
        Thursday = 4,
        /// <summary>
        /// Indicates Friday
        /// </summary>
        Friday = 5,
        /// <summary>
        /// Indicates Saturday
        /// </summary>
        Saturday = 6,
    }
}

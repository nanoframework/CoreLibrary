//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace Windows.Devices.Gpio
{
    /// <summary>
    /// Stores a relative timestap of a general-purpose I/O (GPIO) pin value change, and whether the pin transitioned from low to high or from high to low.
    /// </summary>
    public struct GpioChangeRecord
    {
        /// <summary>
        /// A <see cref="GpioPinEdge"/> object corresponding to the transition type.
        /// </summary>
        public GpioPinEdge Edge;

        /// <summary>
        /// A relative timestamp that can be used to determine the difference in time between two change records. This timestamp does not correspond to any absolute or system time.
        /// </summary>
        public TimeSpan RelativeTime;
    }
}

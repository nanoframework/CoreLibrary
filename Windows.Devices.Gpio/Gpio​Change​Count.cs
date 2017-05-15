//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace Windows.Devices.Gpio
{
    /// <summary>
    /// Represents a near-simultaneous sampling of the number of times a pin has changed value, and the time at which this count was sampled.
    /// This structure can be used to determine the number of pin value changes over a period of time.
    /// </summary>
    public struct GpioChangeCount
    {
        /// <summary>
        /// The number of times the transition of polarity specified by <see><cref>GpioChangeCounter.Polarity</cref></see> occured on the pin.
        /// </summary>
        public ulong Count;

        /// <summary>
        /// The time at which this count was sampled. The time is sampled close to (but not simultaneously with) the count.
        /// This timestamp can be used to determine the elapsed time between two GpioChangeCount records.
        /// It does not correspond to any absolute or system time.
        /// </summary>
        public TimeSpan RelativeTime;
    }
}

//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.Gpio
{
    /// <summary>
    /// Describes the possible types of change that can occur to the value of the general-purpose I/O (GPIO) pin for the GpioPin.ValueChanged event.
    /// </summary>
    public enum GpioPinEdge
    {
        /// <summary>
        /// The value of the GPIO pin changed from high to low.
        /// </summary>
        FallingEdge,
        /// <summary>
        /// The value of the GPIO pin changed from low to high.
        /// </summary>
        RisingEdge
    }
}

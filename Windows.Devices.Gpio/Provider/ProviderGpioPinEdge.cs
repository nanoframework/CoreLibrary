//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.Gpio
{
    /// <summary>
    /// Describes the possible types of change that can occur to the value of the general-purpose I/O (GPIO) pin.
    /// </summary>
    public enum ProviderGpioPinEdge
    {
        /// <summary>
        /// The falling edge, or when value goes from high to low.
        /// </summary>
        FallingEdge,
        /// <summary>
        /// The rising edge, or when value goes from low to high.
        /// </summary>
        RisingEdge,
    }
}

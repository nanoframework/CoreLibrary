//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.Gpio
{
    /// <summary>
    /// Describes whether a general-purpose I/O (GPIO) pin is configured as an input or an output, and how values are driven onto the pin.
    /// </summary>
    public enum ProviderGpioPinDriveMode
    {
        /// <summary>
        /// Configures the GPIO pin in floating mode, with high impedance.
        /// </summary>
        Input,
        /// <summary>
        /// Configures the GPIO pin as high impedance with a pull-down resistor to ground.
        /// </summary>
        InputPullDown,
        /// <summary>
        /// Configures the GPIO pin as high impedance with a pull-up resistor to the voltage charge connection (VCC).
        /// </summary>
        InputPullUp,
        /// <summary>
        /// Configures the GPIO pin in strong drive mode, with low impedance.
        /// </summary>
        Output,
        /// <summary>
        /// Configures the GPIO in open drain mode.
        /// </summary>
        OutputOpenDrain,
        /// <summary>
        /// Configures the GPIO pin in open drain mode with resistive pull-up mode.
        /// </summary>
        OutputOpenDrainPullUp,
        /// <summary>
        /// Configures the GPIO pin in open collector mode.
        /// </summary>
        OutputOpenSource,
        /// <summary>
        /// Configures the GPIO pin in open collector mode with resistive pull-down mode.
        /// </summary>
        OutputOpenSourcePullDown,
    }
}

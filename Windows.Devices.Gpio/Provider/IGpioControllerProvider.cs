//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.Gpio
{
    /// <summary>
    /// Represents the actions common to all general-purpose I/O (GPIO) controllers.
    /// </summary>
    public interface IGpioControllerProvider
    {
        /// <summary>
        /// Gets the number of general-purpose I/O (GPIO) pins available.
        /// </summary>
        /// <value>
        /// The number of GPIO pins available.
        /// </value>
        int PinCount { get; }

        /// <summary>
        /// Opens and returns the general-purpose I/O (GPIO) pin provider for a specific pin.
        /// </summary>
        /// <param name="pin">The desired GPIO pin number.</param>
        /// <param name="sharingMode">The sharing mode to open the pin as.</param>
        /// <returns>The GPIO pin provider for the specified pin.</returns>
        IGpioPinProvider OpenPinProvider(int pin, ProviderGpioSharingMode sharingMode);
    }
}

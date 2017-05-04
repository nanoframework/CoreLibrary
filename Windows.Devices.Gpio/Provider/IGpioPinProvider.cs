//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace Windows.Devices.Gpio
{
    /// <summary>
    /// Represents actions common to general-purpose I/O (GPIO) pin providers.
    /// </summary>
    public interface IGpioPinProvider
    {
        /// <summary>
        /// Gets or sets the debounce timeout for the general-purpose I/O (GPIO) pin, which is an interval during which changes to the value of the pin are filtered out and do not generate ValueChanged events.
        /// </summary>
        /// <value>
        /// The debounce timeout for the GPIO pin, which is an interval during which changes to the value of the pin are filtered out and do not generate ValueChanged events.
        /// If the length of this interval is 0, all changes to the value of the pin generate ValueChanged events.
        /// </value>
        TimeSpan DebounceTimeout { get; set; }

        /// <summary>
        /// Gets the pin number of the general-purpose I/O (GPIO) pin
        /// </summary>
        /// <value>
        /// The pin number of the GPIO pin.
        /// </value>
        int PinNumber { get; }

        /// <summary>
        /// Gets the sharing mode in which the general-purpose I/O (GPIO) pin is open.
        /// </summary>
        /// <value>
        /// The sharing mode in which the GPIO pin is open.
        /// </value>
        ProviderGpioSharingMode SharingMode { get; }

        /// <summary>
        /// Gets the pin's currently configured drive mode.
        /// </summary>
        /// <returns>The drive mode of the pin.</returns>
        ProviderGpioPinDriveMode GetDriveMode();

        /// <summary>
        /// Determines if a drive mode is supported for the pin.
        /// </summary>
        /// <param name="driveMode">The desired drive mode.</param>
        /// <returns>
        ///   True if the drive mode is supported; otherwise false.
        /// </returns>
        bool IsDriveModeSupported(ProviderGpioPinDriveMode driveMode);

        /// <summary>
        /// Reads the current value of the pin.
        /// </summary>
        /// <returns>The pin's value.</returns>
        ProviderGpioPinValue Read();

        /// <summary>
        /// Sets the pin's drive mode.
        /// </summary>
        /// <param name="value">The desired drive mode for the pin.</param>
        void SetDriveMode(ProviderGpioPinDriveMode value);

        /// <summary>
        /// Writes a value to the pin.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void Write(ProviderGpioPinValue value);
    }
}

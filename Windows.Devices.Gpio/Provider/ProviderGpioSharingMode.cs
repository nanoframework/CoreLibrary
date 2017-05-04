//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.Gpio
{
    /// <summary>
    /// Describes the modes in which you can open a general-purpose I/O (GPIO) pin.
    /// These modes determine whether other connections to the GPIO pin can be opened while you have the pin open.
    /// </summary>
    public enum ProviderGpioSharingMode
    {
        /// <summary>
        /// Opens the GPIO pin exclusively, so that no other connection to the pin can be opened.
        /// </summary>
        Exclusive,
        /// <summary>
        /// Opens the GPIO pin as shared, so that other connections in SharedReadOnly mode to the pin can be opened.
        /// Only operations that do not change the state of the pin can be performed.
        /// </summary>
        SharedReadOnly,
    }
}

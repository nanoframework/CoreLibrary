//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.Gpio
{
    /// <summary>
    /// Describes the possible results of opening a pin with the <see><cref>GpioPin.TryOpenPin</cref></see> method.
    /// </summary>
    public enum GpioOpenStatus
    {
        /// <summary>
        /// The pin is currently opened for a different function, such as I2C, SPI, or UART. Ensure the pin is not in use by another function.
        /// </summary>
        MuxingConflict,
        /// <summary>
        /// The GPIO pin was successfully opened.
        /// </summary>
        PinOpened,
        /// <summary>
        /// The pin is reserved by the system and is not available to apps that run in user mode.
        /// </summary>
        PinUnavailable,
        /// <summary>
        /// <para>The pin is currently open in an incompatible sharing mode. For example:</para>
        /// <list type="bullet">
        /// <item><term>The pin is already open in GpioSharingMode.Exclusive mode.</term></item>
        /// <item><term>The pin is already open in GpioSharingMode.SharedReadOnly mode when you request to open it in GpioSharingMode.Exclusive mode.</term></item>
        /// </list>
        /// </summary>
        SharingViolation,
        /// <summary>
        /// The pin could not be opened.
        /// </summary>
        UnknownError
    }
}

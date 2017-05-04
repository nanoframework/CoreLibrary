//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.Gpio
{
    /// <summary>
    /// Describes the modes in which you can open a general-purpose I/O (GPIO) pin.
    /// <para>These modes determine whether other connections to the GPIO pin can be opened while you have the pin open.</para>
    /// </summary>
    public enum GpioSharingMode
    {
        /// <summary>
        /// Opens the GPIO pin exclusively, so that no other connection to the pin can be opened.
        /// </summary>
        Exclusive,
        /// <summary>
        /// <para>Opens the GPIO pin as shared, so that other connections in SharedReadOnly mode to the pin can be opened.</para>
        /// <para>You can only perform operations that do not change the state of the GPIO pin in shared mode. Operations that you can perform on the GPIO pin in shared mode include:</para>
        /// <list type="bullet">
        /// <item><term>Calling the GpioPin.Read method.</term></item>
        /// <item><term>Calling the GpioPin.GetDriveMode method.</term></item>
        /// <item><term>Getting the values of properties, such as GpioPin.PinNumber and GpioPin.DebounceTimeout.</term></item>
        /// <item><term>Registering an event handler for the GpioPin.ValueChanged event.</term></item>
        /// </list>
        /// </summary>
        SharedReadOnly
    }
}

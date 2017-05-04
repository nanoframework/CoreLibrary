//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.Gpio
{
    /// <summary>
    /// Represents actions common to general-purpose I/O (GPIO) controller providers.
    /// </summary>
    public interface IGpioProvider
    {
        /// <summary>
        /// Gets the controllers available on the system.
        /// </summary>
        /// <returns>A list of values that represent the controllers available on the system.</returns>
        IGpioControllerProvider[] GetControllers();
    }
}

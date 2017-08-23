//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.I2c
{
    /// <summary>
    /// Describes the modes in which you can connect to an inter-integrated circuit (I2C) bus address. 
    /// These modes determine whether other connections to the I2C bus address can be opened while you are connected to the I2C bus address.
    /// </summary>
	public enum I2cSharingMode
    {
        /// <summary>
        /// Connects to the I2C bus address exclusively, so that no other connection to the I2C bus address can be made while you remain connected. This mode is the default mode.
        /// </summary>
        Exclusive,
        /// <summary>
        /// Connects to the I2C bus address in shared mode, so that other connections to the I2C bus address can be made while you remain connected.
        /// You can perform all operations on shared connections, but use such connections with care. When multiple client apps change the global state of the I2C device,
        /// race conditions can result.
        /// An example use case for using a shared connection is a sensor that obtains readings without changing the state of the device.
        /// </summary>
        Shared
    }
}

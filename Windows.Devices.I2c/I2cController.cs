//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Collections;

namespace Windows.Devices.I2c
{
    /// <summary>
    /// Represents the I2C controller for the system.
    /// </summary>
	public sealed class I2cController
    {
        internal static ArrayList DeviceCollection = new ArrayList();

        /// <summary>
        /// Gets the default I2C controller on the system.
        /// </summary>
        /// <returns>The default I2C controller on the system, or null if the system has no I2C controller.</returns>
        public static I2cController GetDefault()
        {
            return new I2cController();
        }

        /// <summary>
        /// Gets the I2C device with the specified settings.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns>The desired connection settings.</returns>
        public I2cDevice GetDevice(I2cConnectionSettings settings)
        {
            //TODO: fix return value. Should return an existing device (if any)
            return new I2cDevice(String.Empty, settings);
        }
    }
}

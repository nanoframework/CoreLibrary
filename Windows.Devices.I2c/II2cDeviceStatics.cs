//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace Windows.Devices.I2c
{
    /// <summary>
    /// Provides ways to open a communications channel to a device on an inter-integrated circuit (I2C) bus.
    /// </summary>
	public interface II2cDeviceStatics
    {
        /// <summary>
        /// Retrieves an I2cDevice object asynchronously for the inter-integrated circuit (I2C) bus controller that has the specified plug and play device identifier,
        /// using the specified connection settings.
        /// </summary>
        /// <param name="deviceId">The plug and play device identifier of the I2C bus controller for which you want to create an I2cDevice object.</param>
        /// <param name="settings">The connection settings to use for communication with the I2C bus controller that deviceId specifies.</param>
        /// <returns>An operation that returns the I2cDevice object.</returns>
        I2cDevice FromId(String deviceId, I2cConnectionSettings settings);

        /// <summary>
        /// Retrieves an Advanced Query Syntax (AQS) string for all of the inter-integrated circuit (I2C) bus controllers on the system. You can use this string with the 
        /// DeviceInformation.FindAllAsync method to get DeviceInformation objects for those bus controllers.
        /// </summary>
        /// <returns>An AQS string for all of the I2C bus controllers on the system, which you can use with the DeviceInformation.FindAll method to get DeviceInformation 
        /// objects for those bus controllers.</returns>
        string GetDeviceSelector();

        /// <summary>
        /// Retrieves an Advanced Query Syntax (AQS) string for the inter-integrated circuit (I2C) bus that has the specified friendly name. You can use this string with the 
        /// DeviceInformation.FindAll method to get a DeviceInformation object for that bus.
        /// </summary>
        /// <param name="friendlyName">A friendly name for the particular I2C bus on a particular hardware platform for which you want to get the AQS string.</param>
        /// <returns>An AQS string for the I2C bus that friendlyName specifies, which you can use with the DeviceInformation.FindAll method to get a DeviceInformation object for that bus.</returns>
        string GetDeviceSelector(String friendlyName);
    }
}

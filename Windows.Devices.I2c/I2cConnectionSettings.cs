//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace Windows.Devices.I2c
{
    /// <summary>
    /// Represents the connection settings you want to use for an inter-integrated circuit (I2C) device.
    /// </summary>
	public sealed class I2cConnectionSettings
    {
        private Int32 _slaveAddress;
        private I2cBusSpeed _busSpeed;
        private I2cSharingMode _sharingMode;

        /// <summary>
        /// Creates and initializes a new instance of the I2cConnectionSettings class for inter-integrated circuit (I2C) device with specified bus address,
        /// using the default settings of the standard mode for the bus speed and exclusive sharing mode.
        /// </summary>
        /// <param name="slaveAddress">The bus address of the inter-integrated circuit (I2C) device to which the settings of the I2cConnectionSettings should apply.
        /// Only 7-bit addressing is supported, so the range of values that are valid is from 8 to 119.</param>
        public I2cConnectionSettings(Int32 slaveAddress)
        {
            _slaveAddress = slaveAddress;
        }

        /// <summary>
        /// Initializes a copy of a <see cref="I2cConnectionSettings"/> object.
        /// </summary>
        /// <param name="settings">Object to copy from.</param>
        internal I2cConnectionSettings(I2cConnectionSettings settings)
        {
            _slaveAddress = settings.SlaveAddress;
            _busSpeed = settings.BusSpeed;
            _sharingMode = settings.SharingMode;
        }

        /// <summary>
        /// Gets or sets the bus speed to use for connecting to an inter-integrated circuit (I2C) device. The bus speed is the frequency at which to clock the I2C bus when accessing the device.
        /// </summary>
        /// <value>
        /// The bus speed to use for connecting to anI2C device.
        /// </value>
        public I2cBusSpeed BusSpeed
        {
            get { return _busSpeed; }
            set { _busSpeed = value; }
        }

        /// <summary>
        /// Gets or sets the sharing mode to use to connect to the inter-integrated circuit (I2C) bus address. This mode determines whether other connections to the I2C bus address can be opened
        /// while you are connect to the I2C bus address.
        /// </summary>
        /// <value>
        /// The sharing mode to use to connect to the I2C bus address.
        /// </value>
        public I2cSharingMode SharingMode
        {
            get { return _sharingMode; }
            set { _sharingMode = value; }
        }

        /// <summary>
        /// Gets or sets the bus address of the inter-integrated circuit (I2C) device.
        /// </summary>
        /// <value>
        /// The bus address of the I2C device. Only 7-bit addressing is supported, so the range of values that are valid is from 8 to 119.
        /// </value>
        public int SlaveAddress
        {
            get { return _slaveAddress; }
            set { _slaveAddress = value; }
        }
    }
}

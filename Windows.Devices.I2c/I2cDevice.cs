//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace Windows.Devices.I2c
{
    /// <summary>
    /// Represents a communications channel to a device on an inter-integrated circuit (I2C) bus.
    /// </summary>
	public sealed class I2cDevice : IDisposable
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeInit();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void DisposeNative();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern int NativeTransmit(byte[] writeBuffer, uint nbWritten, byte[] readBuffer, uint nbRead);
        
        // this is used as the lock object 
        // a lock is required because multiple threads can access the SPI bus
        private object _syncLock = new object();
        private readonly int _deviceId;
        private readonly I2cConnectionSettings _connectionSettings;
        private readonly string _i2cBus;

        internal I2cDevice(string i2cBus, I2cConnectionSettings settings)
        {
            // generate a unique ID for the device by joining the I2C bus ID and the slave address, should be pretty unique
            // the encoding is (I2C bus number x 1000 + slave address)
            // i2cBus is an ASCII string with the bus name in format 'I2Cn'
            // need to grab 'n' from the string and convert that to the integer value from the ASCII code (do this by subtracting 48 from the char value)
            var deviceId = (i2cBus[3] - 48) * 1000 + settings.SlaveAddress;

            // check if this device ID already exists
            if (!I2cController.s_deviceCollection.Contains(deviceId))
            {
                _i2cBus = i2cBus;
                _connectionSettings = new I2cConnectionSettings(settings.SlaveAddress)
                {
                    BusSpeed = settings.BusSpeed,
                    SharingMode = settings.SharingMode
                };

                // save device ID
                _deviceId = deviceId;

                NativeInit();

                // add to device collection
                I2cController.s_deviceCollection.Add(deviceId, this);
            }
            /*
            else
            {
                // this device already exists throw an exception
                throw new ArgumentException();
            }
            */
        }

        /// <summary>
        /// Gets the connection settings used for communication with the inter-integrated circuit (I2C) device.
        /// </summary>
        /// <value>
        /// The connection settings used for communication with the inter-integrated circuit (I2C) device.
        /// </value>
        public I2cConnectionSettings ConnectionSettings
        {
            get
            {
                lock (_syncLock)
                {
                    // check if device has been disposed
                    if (!_disposedValue)
                    {
                        // need to return a copy so that the caller doesn't change the settings
                        return new I2cConnectionSettings(_connectionSettings);
                    }

                    throw new ObjectDisposedException();
                }
            }
        }

        /// <summary>
        /// Gets the plug and play device identifier of the inter-integrated circuit (I2C) bus controller for the device.
        /// </summary>
        /// <value>
        /// The plug and play device identifier of the inter-integrated circuit (I2C) bus controller for the device.
        /// </value>
        public string DeviceId
        {
            get
            {
                lock (_syncLock)
                {
                    // check if device has been disposed
                    if (!_disposedValue) { return _deviceId.ToString(); }

                    throw new ObjectDisposedException();
                }
            }
        }

        /// <summary>
        /// Retrieves an I2cDevice object asynchronously for the inter-integrated circuit (I2C) bus controller that has the specified plug and play device identifier, using the specified connection settings.
        /// </summary>
        /// <param name="i2cBus">The plug and play device identifier of the I2C bus controller for which you want to create an I2cDevice object.</param>
        /// <param name="settings">The connection settings to use for communication with the I2C bus controller that deviceId specifies.</param>
        /// <returns>An operation that returns the I2cDevice object.</returns>
        public static I2cDevice FromId(String i2cBus, I2cConnectionSettings settings)
        {
            return new I2cDevice(i2cBus, settings);
        }

        /// <summary>
        /// Retrieves an Advanced Query Syntax (AQS) string for all of the inter-integrated circuit (I2C) bus controllers on the system. You can use this string with the DeviceInformation.FindAll
        /// method to get DeviceInformation objects for those bus controllers.
        /// </summary>
        /// <returns>An AQS string for all of the I2C bus controllers on the system, which you can use with the DeviceInformation.FindAllAsync method to get DeviceInformation 
        /// objects for those bus controllers.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string GetDeviceSelector();

        /// <summary>
        /// Retrieves an Advanced Query Syntax (AQS) string for the inter-integrated circuit (I2C) bus that has the specified friendly name. You can use this string with the DeviceInformation.FindAll
        /// method to get a DeviceInformation object for that bus.
        /// </summary>
        /// <param name="friendlyName">A friendly name for the particular I2C bus on a particular hardware platform for which you want to get the AQS string.</param>
        /// <returns>An AQS string for the I2C bus that friendlyName specifies, which you can use with the DeviceInformation.FindAllAsync method to get a DeviceInformation object for that bus.</returns>
        public static string GetDeviceSelector(String friendlyName)
        {
            return GetDeviceSelector();
        }

        /// <summary>
        /// Reads data from the inter-integrated circuit (I2C) bus on which the device is connected into the specified buffer.
        /// </summary>
        /// <param name="buffer">The buffer to which you want to read the data from the I2C bus. The length of the buffer determines how much data to request from the device.</param>
        public void Read(Byte[] buffer)
        {
            ReadPartial(buffer);
        }

        /// <summary>
        /// Reads data from the inter-integrated circuit (I2C) bus on which the device is connected into the specified buffer, and returns information about the success of the 
        /// operation that you can use for error handling.
        /// </summary>
        /// <param name="buffer">The buffer to which you want to read the data from the I2C bus. The length of the buffer determines how much data to request from the device.</param>
        /// <returns>A structure that contains information about the success of the read operation and the actual number of bytes that the operation read into the buffer.</returns>
        public I2cTransferResult ReadPartial(Byte[] buffer)
        {
            lock (_syncLock)
            {
                // check if device has been disposed
                if (_disposedValue) throw new ObjectDisposedException();
                var nbRead = (UInt32)buffer.Length;
                var status = NativeTransmit(null, 0, buffer, nbRead);

                return new I2cTransferResult { BytesTransferred = nbRead, Status = (I2cTransferStatus)status };
            }
        }

        /// <summary>
        /// Writes data to the inter-integrated circuit (I2C) bus on which the device is connected, based on the bus address specified in the I2cConnectionSetting s object
        /// that you used to create the I2cDevice object.
        /// </summary>
        /// <param name="buffer">A buffer that contains the data that you want to write to the I2C device. This data should not include the bus address.</param>
        public void Write(Byte[] buffer)
        {
            WritePartial(buffer);
        }

        /// <summary>
        /// Writes data to the inter-integrated circuit (I2C) bus on which the device is connected, and returns information about the success of the operation that you can use for error handling.
        /// </summary>
        /// <param name="buffer">A buffer that contains the data that you want to write to the I2C device. This data should not include the bus address.</param>
        /// <returns>A structure that contains information about the success of the write operation and the actual number of bytes that the operation wrote into the buffer.</returns>
        public I2cTransferResult WritePartial(Byte[] buffer)
        {
            lock (_syncLock)
            {
                // check if device has been disposed
                if (_disposedValue) throw new ObjectDisposedException();
                var nbWritten = (UInt32) buffer.Length;
                var status = NativeTransmit(buffer, nbWritten, null, 0);

                return new I2cTransferResult { BytesTransferred = nbWritten, Status = (I2cTransferStatus)status };
            }
        }

        /// <summary>
        /// Performs an atomic operation to write data to and then read data from the inter-integrated circuit (I2C) bus on which the device is connected, and sends a restart
        /// condition between the write and read operations.
        /// </summary>
        /// <param name="writeBuffer">A buffer that contains the data that you want to write to the I2C device. This data should not include the bus address.</param>
        /// <param name="readBuffer">The buffer to which you want to read the data from the I2C bus. The length of the buffer determines how much data to request from the device.</param>
        public void WriteRead(Byte[] writeBuffer, Byte[] readBuffer)
        {
            WriteReadPartial(writeBuffer, readBuffer);
        }

        /// <summary>
        /// Performs an atomic operation to write data to and then read data from the inter-integrated circuit (I2C) bus on which the device is connected, and returns information about the
        /// success of the operation that you can use for error handling.
        /// </summary>
        /// <param name="writeBuffer">A buffer that contains the data that you want to write to the I2C device. This data should not include the bus address.</param>
        /// <param name="readBuffer">The buffer to which you want to read the data from the I2C bus. The length of the buffer determines how much data to request from the device.</param>
        /// <returns>A structure that contains information about whether both the read and write parts of the operation succeeded and the sum of the actual number of bytes that the
        /// operation wrote and the actual number of bytes that the operation read.</returns>
        public I2cTransferResult WriteReadPartial(Byte[] writeBuffer, Byte[] readBuffer)
        {
            lock (_syncLock)
            {
                // check if device has been disposed
                if (_disposedValue) throw new ObjectDisposedException();
                var nbWritten = (UInt32)writeBuffer.Length;
                var nbRead = (UInt32)readBuffer.Length;
                var status = NativeTransmit(writeBuffer, nbWritten, readBuffer, nbRead);

                return new I2cTransferResult { BytesTransferred = nbRead + nbWritten, Status = (I2cTransferStatus)status };
            }
        }

        #region IDisposable Support

        private bool _disposedValue;

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // remove from device collection
                    I2cController.s_deviceCollection.Remove(_deviceId);
                }

                DisposeNative();

                _disposedValue = true;
            }
        }

        #pragma warning disable 1591
        ~I2cDevice()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            lock (_syncLock)
            {
                if (!_disposedValue)
                {
                    Dispose(true);

                    GC.SuppressFinalize(this);
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// Exception thrown when a check in driver's constructor finds a device that already exists with the same settings (I2C bus AND slave address)
    /// </summary>
    [Serializable]
    public class I2cDeviceAlreadyInUseException : Exception
    {
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() { return base.Message; }
    }
}

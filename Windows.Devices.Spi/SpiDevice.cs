//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace Windows.Devices.Spi
{
    /// <summary>
    /// Represents a device connected through the SPI bus.
    /// </summary>
    public sealed class SpiDevice : IDisposable
    {
        // this is used as the lock object 
        // a lock is required because multiple threads can access the GpioPin
        private object _syncLock = new object();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeTransfer(string spiBus, byte[] writeBuffer, byte[] readBuffer, bool fullDuplex);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeTransfer(string spiBus, ushort[] writeBuffer, ushort[] readBuffer, bool fullDuplex);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeInit();

        private readonly string _spiBus;
        private readonly string _deviceId;
        private readonly Spi​Connection​Settings _connectionSettings;

        internal SpiDevice(string spiBus, Spi​Connection​Settings settings)
        {
            _spiBus = spiBus;
            _connectionSettings = new SpiConnectionSettings(settings);
            
            // generate a unique ID for the device by joining the SPI bus ID and the chip select line, should be pretty unique
            //var uniqueId = (spiBus + settings.ChipSelectLine.ToString()).GetHashCode().ToString();
            // because this field is readonly it has to be set in a single operation using the var above
            // using the initialization to load the field breaks the execution at the native end
            // TODO: there is an issue with initing the above when executing on native
            _deviceId = "SPIID";

            NativeInit();
        }

        /// <summary>
        /// Gets the connection settings for the device.
        /// </summary>
        /// <value>
        /// The connection settings.
        /// </value>
        public Spi​Connection​Settings ConnectionSettings
        {
            get
            {
                lock (_syncLock)
                {
                    // check if device has been disposed
                    if (!_disposedValue)
                    {
                        // need to return a copy so that the caller doesn't change the settings
                        return new Spi​Connection​Settings(_connectionSettings);
                    }

                    throw new ObjectDisposedException();
                }
            }
        }

        /// <summary>
        /// Gets the unique ID associated with the device.
        /// </summary>
        /// <value>
        /// The ID.
        /// </value>
        public string DeviceId
        {
            get
            {
                lock (_syncLock)
                {
                    // check if device has been disposed
                    if (!_disposedValue) { return _deviceId; }

                    throw new ObjectDisposedException();
                }
            }
        }

        /// <summary>
        /// Opens a device with the connection settings provided.
        /// </summary>
        /// <param name="busId">The id of the bus.</param>
        /// <param name="settings">The connection settings.</param>
        /// <returns>The SPI device requested.</returns>
        /// <remarks>For ChibiOS port, busID is SPID1 to SPIDx</remarks>
        public static SpiDevice FromId(string busId, Spi​Connection​Settings settings)
        {
            //TODO: some sanity checks on busId
            return new SpiDevice(busId, settings);
        }

        /// <summary>
        /// Retrieves the info about a certain bus.
        /// </summary>
        /// <param name="busId">The id of the bus.</param>
        /// <returns>The bus info requested.</returns>
        public static SpiBusInfo GetBusInfo(string busId)
        {
            return new SpiBusInfo(busId);
        }

        /// <summary>
        /// Gets all the SPI buses found on the system.
        /// </summary>
        /// <returns>String containing all the buses found on the system.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string GetDeviceSelector();

        /// <summary>
        /// Gets all the SPI buses found on the system that match the input parameter.
        /// </summary>
        /// <param name="friendlyName">Input parameter specifying an identifying name for the desired bus. This usually corresponds to a name on the schematic.</param>
        /// <returns>String containing all the buses that have the input in the name.</returns>
        public static string GetDeviceSelector(string friendlyName)
        {
            // At the moment, ignore the friendly name.
            return GetDeviceSelector();
        }

        /// <summary>
        /// Reads from the connected device.
        /// </summary>
        /// <param name="buffer">Array containing data read from the device.</param>
        public void Read(byte[] buffer)
        {
            NativeTransfer(_spiBus, null,buffer, false);
        }

        /// <summary>
        /// Reads from the connected device.
        /// </summary>
        /// <param name="buffer">Array containing data read from the device.</param>
        public void Read(ushort[] buffer)
        {
            NativeTransfer(_spiBus, null, buffer, false);
        }

        /// <summary>
        /// Transfer data using a full duplex communication system. Full duplex allows both the master and the slave to communicate simultaneously.
        /// </summary>
        /// <param name="writeBuffer">Array containing data to write to the device.</param>
        /// <param name="readBuffer">Array containing data read from the device.</param>
        public void TransferFullDuplex(byte[] writeBuffer, byte[] readBuffer)
        {
            NativeTransfer(_spiBus, writeBuffer, readBuffer, true);
        }

        /// <summary>
        /// Transfer data using a full duplex communication system. Full duplex allows both the master and the slave to communicate simultaneously.
        /// </summary>
        /// <param name="writeBuffer">Array containing data to write to the device.</param>
        /// <param name="readBuffer">Array containing data read from the device.</param>
        public void TransferFullDuplex(ushort[] writeBuffer, ushort[] readBuffer)
        {
            NativeTransfer(_spiBus, writeBuffer, readBuffer, true);
        }

        /// <summary>
        /// Transfer data sequentially to the device.
        /// </summary>
        /// <param name="writeBuffer">Array containing data to write to the device.</param>
        /// <param name="readBuffer">Array containing data read from the device.</param>
        public void TransferSequential(byte[] writeBuffer, byte[] readBuffer)
        {
            NativeTransfer(_spiBus, writeBuffer, readBuffer, false);
        }

        /// <summary>
        /// Transfer data sequentially to the device.
        /// </summary>
        /// <param name="writeBuffer">Array containing data to write to the device.</param>
        /// <param name="readBuffer">Array containing data read from the device.</param>
        public void TransferSequential(ushort[] writeBuffer, ushort[] readBuffer)
        {
            NativeTransfer(_spiBus, writeBuffer, readBuffer, false);
        }

        /// <summary>
        /// Writes to the connected device.
        /// </summary>
        /// <param name="buffer">Array containing the data to write to the device.</param>
        public void Write(byte[] buffer)
        {
            NativeTransfer(_spiBus, buffer, null, false);
        }

        /// <summary>
        /// Writes to the connected device.
        /// </summary>
        /// <param name="buffer">Array containing the data to write to the device.</param>
        public void Write(ushort[] buffer)
        {
            NativeTransfer(_spiBus, buffer, null, false);
        }

        #region IDisposable Support

        private bool _disposedValue; // To detect redundant calls

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    DisposeNative();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void DisposeNative();

        /// <summary>
        /// Finalizes the instance of the <see cref="Gpio​Pin"/> class.
        /// </summary>
        ~SpiDevice()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            lock (_syncLock)
            {
                // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }

        #endregion

    }
}

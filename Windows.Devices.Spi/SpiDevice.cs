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
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeTransfer(string spiBus, byte[] writeBuffer, byte[] readBuffer, bool fullDuplex);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeTransfer(string spiBus, ushort[] writeBuffer, ushort[] readBuffer, bool fullDuplex);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeInit(string spiBus, int chipSelect, int dataBitLength, int mode);

        private readonly string _spiBus;
        private readonly string _deviceId;
        private static readonly Random Rnd = new Random();

        internal SpiDevice(string spiBus, Spi​Connection​Settings settings)
        {
            _spiBus = spiBus;
            ConnectionSettings = settings;
            _deviceId = Rnd.Next().ToString();
            NativeInit(spiBus, settings.ChipSelectLine, settings.DataBitLength, (int)settings.Mode);
        }

        private Spi​Connection​Settings _ConnectionSettings;
        /// <summary>
        /// Gets the connection settings for the device.
        /// </summary>
        /// <value>
        /// The connection settings.
        /// </value>
        public Spi​Connection​Settings ConnectionSettings
        {
            get { return _ConnectionSettings; }
            set { _ConnectionSettings = value; }
        }

        /// <summary>
        /// Gets the unique ID associated with the device.
        /// </summary>
        /// <value>
        /// The ID.
        /// </value>
        public string DeviceId
        {
            get { return _deviceId; }
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

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}

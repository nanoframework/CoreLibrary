//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System.Collections;

namespace Windows.Devices.Spi
{
    /// <summary>
    /// Represents the SPI controller on the system.
    /// </summary>
    public sealed class SpiController
    {
        // we can have only one instance of the SpiController
        private static SpiController s_instance = new SpiController();

        internal static Hashtable s_deviceCollection = new Hashtable();

        /// <summary>
        /// Gets the default SPI controller on the system.
        /// </summary>
        /// <returns>The default SPI controller on the system, or null if the system has no SPI controller.</returns>
        public static SpiController GetDefault()
        {
            return s_instance;
        }

        /// <summary>
        /// Gets the SPI device with the specified settings.
        /// </summary>
        /// <param name="settings">The desired connection settings.</param>
        /// <returns>The SPI device.</returns>
        public SpiDevice GetDevice(Spi​Connection​Settings settings)
        {
            //TODO: fix return value. Should return an existing device (if any)
            return new SpiDevice(string.Empty, settings);
        }
    }
}

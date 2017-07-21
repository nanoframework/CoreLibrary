//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.Spi
{
    /// <summary>
    /// Represents the SPI controller on the system.
    /// </summary>
    public sealed class SpiController
    {
        /// <summary>
        /// Gets the default SPI controller on the system.
        /// </summary>
        /// <returns>The default SPI controller on the system, or null if the system has no SPI controller.</returns>
        public static SpiController GetDefault()
        {
            return new SpiController();
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

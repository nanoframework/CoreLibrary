//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.Spi
{
    /// <summary>
    /// Defines the sharing mode for the SPI bus.
    /// </summary>
    public enum SpiSharingMode
    {
        /// <summary>
        /// SPI bus segment is not shared.
        /// </summary>
        Exclusive,
        /// <summary>
        /// SPI bus is shared.
        /// </summary>
        Shared
    }
}

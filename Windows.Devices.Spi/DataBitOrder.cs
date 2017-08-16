//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.Spi
{
    /// <summary>
    /// Defines the bit order of the data in the buffer to be transmited/received to/from the SPI bus.
    /// </summary>
    /// <remarks>This enum is specific to nanoFramework. Doesn't have correspondence in the UWP API.</remarks>
    public enum DataBitOrder
    {
        /// <summary>
        /// Data is in MSB (most significant bit) order.
        /// </summary>
        MSB = 0,
        /// <summary>
        /// Data is in LSB (least significant bit) order.
        /// </summary>
        LSB
    }
}

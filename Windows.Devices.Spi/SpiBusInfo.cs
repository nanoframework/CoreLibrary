//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace Windows.Devices.Spi
{
    /// <summary>
    /// Represents the info about a SPI bus.
    /// </summary>
    public sealed class SpiBusInfo
    {
        internal SpiBusInfo(string spiBus)
        {
            ChipSelectLineCount = 1;
        }

        private int _ChipSelectLineCount;
        /// <summary>
        /// Gets the number of chip select lines available on the bus.
        /// </summary>
        /// <value>
        /// Number of chip select lines.
        /// </value>
        public int ChipSelectLineCount
        {
            get { return _ChipSelectLineCount; }
            set { _ChipSelectLineCount = value; }
        }

        /// <summary>
        /// Maximum clock cycle frequency of the bus.
        /// </summary>
        /// <value>
        /// The clock cycle in Hz.
        /// </value>
        public extern int MaxClockFrequency
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Minimum clock cycle frequency of the bus.
        /// </summary>
        /// <value>
        /// The clock cycle in Hz.
        /// </value>
        public extern int MinClockFrequency
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the bit lengths that can be used on the bus for transmitting data.
        /// </summary>
        /// <value>
        /// The supported data lengths.
        /// </value>
        public int[] SupportedDataBitLengths
        {
            get
            {
                return new[] {8, 16};
            }
        }
    }
}

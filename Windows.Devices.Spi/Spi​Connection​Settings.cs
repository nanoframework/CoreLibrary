//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.Spi
{
    /// <summary>
    /// Represents the settings for the connection with a device.
    /// </summary>
    public sealed class Spi​Connection​Settings
    {
        private int _csLine;
        private int _clockFrequency;
        private int _databitLength;
        private SpiMode _spiMode;
        private SpiSharingMode _spiSharingMode;

        /// <summary>
        /// Initializes new instance of SpiConnectionSettings.
        /// </summary>
        /// <param name="chipSelectLine">The chip select line on which the connection will be made.</param>
        public Spi​Connection​Settings(int chipSelectLine)
        {
            _csLine = chipSelectLine;
        }

        /// <summary>
        /// Initializes a copy of a <see cref="SpiConnectionSettings"/> object.
        /// </summary>
        /// <param name="value">Object to copy from.</param>
        internal Spi​Connection​Settings(Spi​Connection​Settings value)
        {
            _csLine = value._csLine;
            _clockFrequency = value._clockFrequency;
            _databitLength = value._databitLength;
            _spiMode = value._spiMode;
            _spiSharingMode = value._spiSharingMode;
        }

        /// <summary>
        /// Gets or sets the chip select line for the connection to the SPI device.
        /// </summary>
        /// <value>
        /// The chip select line.
        /// </value>
        public int ChipSelectLine
        {
            get { return _csLine; }
            set { _csLine = value; }
        }

        /// <summary>
        /// Gets or sets the clock frequency for the connection.
        /// </summary>
        /// <value>
        /// Value of the clock frequency in Hz.
        /// </value>
        public int ClockFrequency
        {
            get { return _clockFrequency; }
            set { _clockFrequency = value; }
        }

        /// <summary>
        /// Gets or sets the bit length for data on this connection.
        /// </summary>
        /// <value>
        /// The data bit length.
        /// </value>
        public int DataBitLength
        {
            get { return _databitLength; }
            set { _databitLength = value; }
        }

        /// <summary>
        /// Gets or sets the SpiMode for this connection.
        /// </summary>
        /// <value>
        /// The communication mode.
        /// </value>
        public SpiMode Mode
        {
            get { return _spiMode; }
            set { _spiMode = value; }
        }

        /// <summary>
        /// Gets or sets the sharing mode for the SPI connection.
        /// </summary>
        /// <value>
        /// The sharing mode.
        /// </value>
        public SpiSharingMode SharingMode
        {
            get { return _spiSharingMode; }
            set { _spiSharingMode = value; }
        }
    }
}

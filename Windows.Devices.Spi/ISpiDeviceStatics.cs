//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.Spi
{
    /// <summary>
    /// Represents SPI device statistics common to SPI devices.
    /// </summary>
    public interface ISpiDeviceStatics
    {
        /// <summary>
        /// Opens a device with the connection settings provided.
        /// </summary>
        /// <param name="busId">The id of the bus.</param>
        /// <param name="settings">The connection settings.</param>
        /// <returns>The SPI device.</returns>
        SpiDevice FromId (string busId, Spi​Connection​Settings settings);

        /// <summary>
        /// Retrieves the info about a certain bus.
        /// </summary>
        /// <param name="busId">The id of the bus.</param>
        /// <returns>The bus info requested.</returns>
        SpiBusInfo GetBusInfo(string busId);

        /// <summary>
        /// Gets all the SPI buses found on the system.
        /// </summary>
        /// <returns>String containing all the buses found on the system.</returns>
        string GetDeviceSelector();

        /// <summary>
        /// Gets all the SPI buses found on the system that match the input parameter.
        /// </summary>
        /// <param name="friendlyName">Input parameter specifying an identifying name for the desired bus. This usually corresponds to a name on the schematic.</param>
        /// <returns>String containing all the buses that have the input in the name.</returns>
        string GetDeviceSelector(string friendlyName);
    }
}

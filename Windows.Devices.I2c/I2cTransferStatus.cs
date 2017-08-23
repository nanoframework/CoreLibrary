//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.I2c
{
    /// <summary>
    /// Describes whether the data transfers that the ReadPartial, WritePartial, or WriteReadPartial method performed succeeded, or provides the reason that the transfers did not succeed.
    /// </summary>
	public enum I2cTransferStatus
    {
        /// <summary>
        /// The data was entirely transferred. For WriteReadPartial, the data for both the write and the read operations was entirely transferred.
        /// For this status code, the value of the I2cTransferResult.BytesTransferred member that the method returns is the same as the size of the buffer
        /// you specified when you called the method, or is equal to the sum of the sizes of two buffers that you specified for WriteReadPartial.
        /// </summary>
        FullTransfer = 0,
        /// <summary>
        /// The transfer failed due to the clock being stretched for too long. Ensure the clock line is not being held low.
        /// </summary>
        ClockStretchTimeout,
        /// <summary>
        /// The I2C device negatively acknowledged the data transfer before all of the data was transferred.
        /// For this status code, the value of the I2cTransferResult.BytesTransferred member that the method returns is the number of bytes actually transferred.
        /// For WriteReadPartial, the value is the sum of the number of bytes that the operation wrote and the number of bytes that the operation read.
        /// </summary>
        PartialTransfer,
        /// <summary>
        /// The bus address was not acknowledged. For this status code, the value of the I2cTransferResult.BytesTransferred member that the method returns of the method is 0.
        /// </summary>
        SlaveAddressNotAcknowledged,
        /// <summary>
        /// The transfer failed for an unknown reason.
        /// </summary>
        UnknownError
    }
}

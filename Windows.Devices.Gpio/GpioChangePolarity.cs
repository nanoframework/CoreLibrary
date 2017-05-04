//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.Gpio
{
    /// <summary>
    /// Represents the polarity of changes that are relevant to the associated action.
    /// </summary>
    public enum GpioChangePolarity
    {
        /// <summary>
        /// Transitions from both low to high and high to low should trigger the associated action.
        /// </summary>
        Both,
        /// <summary>
        /// Transitions from high to low should trigger the associated action.
        /// </summary>
        Falling,
        /// <summary>
        /// Transitions from low to high should trigger the associated action.
        /// </summary>
        Rising
    }
}

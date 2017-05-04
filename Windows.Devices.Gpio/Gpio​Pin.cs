//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace Windows.Devices.Gpio
{
    /// <summary>
    /// Represents a general-purpose I/O (GPIO) pin.
    /// </summary>
    public sealed class Gpio​Pin : IDisposable
    {
        /// <summary>
        /// Gets or sets the debounce timeout for the general-purpose I/O (GPIO) pin, which is an interval during which changes to the value of the pin are filtered out and do not generate ValueChanged events.
        /// </summary>
        /// <value>
        /// The debounce timeout for the GPIO pin, which is an interval during which changes to the value of the pin are filtered out and do not generate ValueChanged events.
        /// If the length of this interval is 0, all changes to the value of the pin generate ValueChanged events.
        /// </value>
        extern public TimeSpan DebounceTimeout {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;

            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            set;
        }

        private int _pinNumber = 1;
        /// <summary>
        /// Gets the pin number of the general-purpose I/O (GPIO) pin.
        /// </summary>
        /// <value>
        /// The pin number of the GPIO pin.
        /// </value>
        public int PinNumber {
            get
            {
                // check if pin has been disposed
                if (!disposedValue)
                {
                    return _pinNumber;
                }

                throw new ObjectDisposedException();
            }
        }

        /// <summary>
        /// Gets the sharing mode in which the general-purpose I/O (GPIO) pin is open.
        /// </summary>
        /// <value>
        /// The sharing mode in which the GPIO pin is open.
        /// </value>
        public GpioSharingMode SharingMode { get; }

        /// <summary>
        /// Gets the current drive mode for the general-purpose I/O (GPIO) pin. The drive mode specifies whether the pin is configured as an input or an output, and determines how values are driven onto the pin.
        /// </summary>
        /// <returns>An enumeration value that indicates the current drive mode for the GPIO pin.
        /// The drive mode specifies whether the pin is configured as an input or an output, and determines how values are driven onto the pin.</returns>
        public GpioPinDriveMode GetDriveMode()
        {
            return new GpioPinDriveMode();
        }

        /// <summary>
        /// Gets whether the general-purpose I/O (GPIO) pin supports the specified drive mode.
        /// </summary>
        /// <param name="driveMode">The drive mode that you want to check for support.</param>
        /// <returns>
        ///   True if the GPIO pin supports the drive mode that driveMode specifies; otherwise false. 
        /// If you specify a drive mode for which this method returns false when you call <see cref="SetDriveMode"/>, <see cref="SetDriveMode"/> generates an exception.
        /// </returns>
        public bool IsDriveModeSupported(GpioPinDriveMode driveMode)
        {
            return true;
        }

        /// <summary>
        /// Reads the current value of the general-purpose I/O (GPIO) pin.
        /// </summary>
        /// <returns>The current value of the GPIO pin. If the pin is configured as an output, this value is the last value written to the pin.</returns>
        public GpioPinValue Read()
        {
            return new GpioPinValue();
        }

        /// <summary>
        /// Sets the drive mode of the general-purpose I/O (GPIO) pin. 
        /// The drive mode specifies whether the pin is configured as an input or an output, and determines how values are driven onto the pin.
        /// </summary>
        /// <param name="value">An enumeration value that specifies drive mode to use for the GPIO pin.
        /// The drive mode specifies whether the pin is configured as an input or an output, and determines how values are driven onto the pin.</param>
        /// <remarks>The following exceptions can be thrown by this method:
        /// <list type="bullet">
        /// <item><term>E_INVALIDARG : The GPIO pin does not support the specified drive mode.</term></item>
        /// <item><term>E_ACCESSDENIED : The pin is open in shared read-only mode.Close the pin and reopen it in exclusive mode to change the drive mode of the pin.</term></item>
        /// </list>
        /// </remarks>
        public void SetDriveMode(GpioPinDriveMode value)
        {
            
        }

        /// <summary>
        /// Drives the specified value onto the general purpose I/O (GPIO) pin according to the current drive mode for the pin 
        /// if the pin is configured as an output, or updates the latched output value for the pin if the pin is configured as an input.
        /// </summary>
        /// <param name="value">The enumeration value to write to the GPIO pin.
        /// <para>If the GPIO pin is configured as an output, the method drives the specified value onto the pin according to the current drive mode for the pin.</para>
        /// <para>If the GPIO pin is configured as an input, the method updates the latched output value for the pin. The latched output value is driven onto the pin when the configuration for the pin changes to output.</para>
        /// </param>
        /// <remarks>The following exceptions can be thrown by this method:
        /// <list type="bullet">
        /// <item><term>E_ACCESSDENIED : The GPIO pin is open in shared read-only mode. To write to the pin, close the pin and reopen the pin in exclusive mode.</term></item>
        /// </list>
        /// </remarks>
        public void Write(GpioPinValue value)
        {
            
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DisposeNative();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern private void DisposeNative();

        ~GpioPin()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

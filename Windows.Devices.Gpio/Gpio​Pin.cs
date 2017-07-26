//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace Windows.Devices.Gpio
{
    // This should be a TypedEventHandler "EventHandler<GpioPinValueChangedEventArgs>"
    #pragma warning disable 1591
    public delegate void GpioPinValueChangedEventHandler(
        Object sender,
        GpioPinValueChangedEventArgs e);


    /// <summary>
    /// Represents a general-purpose I/O (GPIO) pin.
    /// </summary>
    public sealed class Gpio​Pin : IDisposable
    {
        // this is used as the lock object 
        // a lock is required because multiple threads can access the GpioPin
        private object _syncLock = new object();

        private readonly int _pinNumber;
        private GpioPinDriveMode _driveMode = GpioPinDriveMode.Input;
        private GpioPinValueChangedEventHandler _callbacks = null;

        private static GpioPinEventListener s_eventListener = new GpioPinEventListener();

        internal Gpio​Pin(int pinNumber)
        {
            _pinNumber = pinNumber;
        }

        internal bool Init()
        {
            if(NativeInit(_pinNumber))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets or sets the debounce timeout for the general-purpose I/O (GPIO) pin, which is an interval during which changes to the value of the pin are filtered out and do not generate ValueChanged events.
        /// </summary>
        /// <value>
        /// The debounce timeout for the GPIO pin, which is an interval during which changes to the value of the pin are filtered out and do not generate ValueChanged events.
        /// If the length of this interval is 0, all changes to the value of the pin generate ValueChanged events.
        /// </value>
        public extern TimeSpan DebounceTimeout
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

        
        /// <summary>
        /// Gets the pin number of the general-purpose I/O (GPIO) pin.
        /// </summary>
        /// <value>
        /// The pin number of the GPIO pin.
        /// </value>
        public int PinNumber {
            get
            {
                lock (_syncLock)
                {
                    // check if pin has been disposed
                    if (!_disposedValue) { return _pinNumber; }

                    throw new ObjectDisposedException();
                }
            }
        }

        /// <summary>
        /// Gets the sharing mode in which the general-purpose I/O (GPIO) pin is open.
        /// </summary>
        /// <value>
        /// The sharing mode in which the GPIO pin is open.
        /// </value>
        public GpioSharingMode SharingMode
        {
            get
            {
                // at this time pins can't be shared, use is exclusive exclusive (pun intended!) 
                return GpioSharingMode.Exclusive;
            }
        }

        /// <summary>
        /// Gets the current drive mode for the general-purpose I/O (GPIO) pin. The drive mode specifies whether the pin is configured as an input or an output, and determines how values are driven onto the pin.
        /// </summary>
        /// <returns>An enumeration value that indicates the current drive mode for the GPIO pin.
        /// The drive mode specifies whether the pin is configured as an input or an output, and determines how values are driven onto the pin.</returns>
        public GpioPinDriveMode GetDriveMode()
        {
            lock (_syncLock)
            {
                // check if pin has been disposed
                if (!_disposedValue) { return _driveMode; }

                throw new ObjectDisposedException();
            }
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
            lock (_syncLock)
            {
                // check if pin has been disposed
                if (!_disposedValue) { return NativeIsDriveModeSupported(driveMode); }

                throw new ObjectDisposedException();
            }
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
            lock (_syncLock)
            {
                // check if pin has been disposed
                if (_disposedValue) { throw new ObjectDisposedException(); }

                if (_driveMode == value) return;

                // check if the request drive mode is supported
                // need to call the native method directly because we are already inside a lock
                if (NativeIsDriveModeSupported(value))
                {
                    NativeSetDriveMode(value);
                    _driveMode = value;
                }
            }
        }

        /// <summary>
        /// Reads the current value of the general-purpose I/O (GPIO) pin.
        /// </summary>
        /// <returns>The current value of the GPIO pin. If the pin is configured as an output, this value is the last value written to the pin.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern GpioPinValue Read();

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
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void Write(GpioPinValue value);

        /// <summary>
        /// Occurs when the value of the general-purpose I/O (GPIO) pin changes, either because of an external stimulus when the pin is configured as an input, or when a value is written to the pin when the pin in configured as an output.
        /// </summary>
        public event GpioPinValueChangedEventHandler ValueChanged
        {
            add
            {
                lock (_syncLock)
                {
                    if (_disposedValue)
                    {
                        throw new ObjectDisposedException();
                    }

                    var callbacksOld = _callbacks;
                    var callbacksNew = (GpioPinValueChangedEventHandler)Delegate.Combine(callbacksOld, value);

                    try
                    {
                        _callbacks = callbacksNew;
                        NativeSetDriveMode(_driveMode);
                    }
                    catch
                    {
                        _callbacks = callbacksOld;
                        throw;
                    }
                }
            }

            remove
            {
                lock (_syncLock)
                {
                    if (_disposedValue)
                    {
                        throw new ObjectDisposedException();
                    }

                    var callbacksOld = _callbacks;
                    var callbacksNew = (GpioPinValueChangedEventHandler)Delegate.Remove(callbacksOld, value);

                    try
                    {
                        _callbacks = callbacksNew;
                        NativeSetDriveMode(_driveMode);
                    }
                    catch
                    {
                        _callbacks = callbacksOld;
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Handles internal events and re-dispatches them to the publicly subsribed delegates.
        /// </summary>
        /// <param name="edge">The state transition for this event.</param>
        internal void OnPinChangedInternal(GpioPinEdge edge)
        {
            GpioPinValueChangedEventHandler callbacks = null;

            lock (_syncLock)
            {
                if (!_disposedValue)
                {
                    callbacks = _callbacks;
                }
            }

            callbacks?.Invoke(this, new GpioPinValueChangedEventArgs(edge));
        }

        #region IDisposable Support

        private bool _disposedValue; // To detect redundant calls

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    DisposeNative();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void DisposeNative();

        /// <summary>
        /// Finalizes the instance of the <see cref="Gpio​Pin"/> class.
        /// </summary>
        ~Gpio​Pin()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            lock (_syncLock)
            {
                // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }

        #endregion

        #region extenal calls to native implementations

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern bool NativeIsDriveModeSupported(GpioPinDriveMode driveMode);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeSetDriveMode(GpioPinDriveMode driveMode);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern bool NativeInit(int pinNumber);

        #endregion
    }
}

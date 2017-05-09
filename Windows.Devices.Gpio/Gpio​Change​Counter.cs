//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.Gpio
{
    /// <summary>
    /// Counts changes of a specified polarity on a general-purpose I/O (GPIO) pin.
    /// </summary>
    /// <remarks>
    /// <para>When the pin is an input, interrupts are used to detect pin changes. Interrupts for the pin are enabled for the specified polarity, and the count is incremented when an interrupt occurs.</para>
    /// <para>When the pin is an output, the count will increment whenever the specified transition occurs on the pin.For example, if the pin is configured as an output and counting is enabled for rising edges, writing a 0 and then a 1 will cause the count to be incremented.</para></remarks>
    public sealed class Gpio​Change​Counter
    {
        // property backing fields
        private GpioChangePolarity _Polarity = GpioChangePolarity.Falling;


        /// <summary>
        /// Initializes a new instance of the <see cref="Gpio​Change​Counter"/> class associated with the specified pin.
        /// Only a single <see cref="Gpio​Change​Counter"/> may be associated with a pin at any given time.
        /// </summary>
        /// <param name="pin">The pin on which to count changes.
        /// This pin must have been opened in Exclusive mode, and cannot be associated with another GpioChangeCounter.
        /// </param>
        /// <remarks>The following exceptions can be thrown by this method:
        /// <para>E_POINTER - The pin passed in is null.</para>
        /// <para>HRESULT_FROM_WIN32(ERROR_SHARING_VIOLATION) - The pin is already associated with a change counter.That change counter must be disposed before the pin can be associated with a new change counter.</para>
        /// <para>E_ACCESSDENIED - The pin is not opened in Exclusive mode.</para></remarks>
        public Gpio​Change​Counter(Gpio​Pin pin)
        {
            
        }

        /// <summary>
        /// Gets whether pin change counting is currently active.
        /// </summary>
        /// <returns><c>TRUE</c> if this pin change counting is active and <c>FALSE</c> otherwise.</returns>
        public bool IsStarted
        {
            get
            {
                // pin counting is not currently implemented
                return false;
            }
        }


        /// <summary>
        /// Gets or sets the polarity of transitions that will be counted. The polarity may only be changed when pin counting is not started.
        /// </summary>
        /// <remarks><para>The default polarity value is Falling. See <see cref="GpioChangePolarity"></see> for more information on polarity values. Counting a single edge can be considerably more efficient than counting both edges.</para>
        /// <para>The following exceptions can be thrown when setting the polarity:</para>
        /// <para>E_INVALIDARG - value is not a valid GpioChangePolarity value.</para>
        /// <para>HRESULT_FROM_WIN32(ERROR_BAD_COMMAND) - change counting is currently active.Polarity can only be set before calling Start() or after calling Stop().</para>
        /// </remarks>
        public GpioChangePolarity Polarity
        {
            get
            {
                return _Polarity;
            }

            set
            {
                // TODO implement validation logic as described in the documentation
                _Polarity = value;
            }
        }

        /// <summary>
        /// Reads the current count of polarity changes. Before counting has been started, this will return 0.
        /// </summary>
        /// <returns>A <see cref="GpioChangeCount" /> structure containing a count and an associated timestamp.</returns>
        /// <remarks><para>The following exception can be thrown by this method:</para>
        /// <para>HRESULT_FROM_WIN32(ERROR_INVALID_HANDLE) - the change counter or the associated pin has been disposed.</para></remarks>
        public GpioChangeCount Read()
        {
            return new GpioChangeCount();
        }

        /// <summary>
        /// Resets the count to 0 and returns the previous count.
        /// </summary>
        /// <returns>A <see cref="GpioChangeCount" /> structure containing a count and an associated timestamp.</returns>
        /// <remarks><para>The following exception can be thrown by this method:</para>
        /// <para>HRESULT_FROM_WIN32(ERROR_INVALID_HANDLE) - the change counter or the associated pin has been disposed.</para></remarks>
        public GpioChangeCount Reset()
        {
            return new GpioChangeCount();
        }

        /// <summary>
        /// Starts counting changes in pin polarity. This method may only be called when change counting is not already active.
        /// </summary>
        /// <remarks>
        /// <para>Calling Start() may enable or reconfigure interrupts for the pin.</para>
        /// <para>The following exceptions can be thrown by this method:</para>
        /// <para>HRESULT_FROM_WIN32(ERROR_BAD_COMMAND) - change counting has already been started.</para>
        /// <para>HRESULT_FROM_WIN32(ERROR_INVALID_HANDLE) - the change counter or the associated pin has been disposed.</para></remarks>
        public void Start()
        {
            
        }

        /// <summary>
        /// Stop counting changes in pin polarity. This method may only be called when change counting is currently active.
        /// </summary>
        /// <remarks>
        /// <para>Calling Stop() may enable or reconfigure interrupts for the pin.</para>
        /// <para>The following exceptions can be thrown by this method:</para>
        /// <para>HRESULT_FROM_WIN32(ERROR_BAD_COMMAND) - change counting has already been started.</para>
        /// <para>HRESULT_FROM_WIN32(ERROR_INVALID_HANDLE) - the change counter or the associated pin has been disposed.</para></remarks>
        public void Stop()
        {
            
        }
    }
}

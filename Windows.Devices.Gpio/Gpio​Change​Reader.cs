//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace Windows.Devices.Gpio
{
    /// <summary>
    /// Represents a shared circular buffer between kernel mode and user mode into which high-resolution timestamps are placed when a general-purpose I/O (GPIO) pin changes value.
    /// <remarks><para>Kernel mode places a timestamp into the buffer when a pin changes value, and user mode removes items from the buffer.
    /// An overflow occurs when there is no longer sufficient room in the buffer to place additional timestamps.
    /// Upon overflow, further events are not recorded, and the IsOverflowed property will return true.</para>
    /// <para>This class is not thread-safe.Calling functions of this class concurrently from multiple threads will have unpredictable results.</para></remarks>
    /// </summary>
    public sealed class Gpio​Change​Reader
    {
        // property backing fields
        private int _capacity;
        private bool _isOverflowed;
        private bool _isStarted;
        private int _length;
        private GpioChangePolarity _polarity = GpioChangePolarity.Falling;

        /// <summary>
        /// Creates a new GpioChangeReader associated with the specified pin. Only a single GpioChangeReader may be associated with a pin at any given time.
        /// </summary>
        /// <param name="pin">The pin on which to read changes. The pin must have been opened in Exclusive mode, and cannot be associated with another change reader.</param>
        /// <remarks>The following exceptions can be thrown by this method:
        /// <list type="bullet">
        /// <item><term>E_POINTER - The pin passed in is null.</term></item>
        /// <item><term>HRESULT_FROM_WIN32(ERROR_SHARING_VIOLATION) - The pin is already associated with a change reader.That change reader must be disposed before the pin can be associated with a new change reader.</term></item>
        /// <item><term>E_ACCESSDENIED - The pin is not opened in Exclusive mode.</term></item>
        /// </list>
        /// </remarks>
        public Gpio​Change​Reader(Gpio​Pin pin)
        {

        }

        /// <summary>
        /// Creates a new GpioChangeReader associated with the specified pin. Only a single GpioChangeReader may be associated with a pin at any given time.
        /// </summary>
        /// <param name="pin">The pin on which to read changes. The pin must have been opened in Exclusive mode, and cannot be associated with another change reader.</param>
        /// <param name="minCapacity">The minimum number of change records that the reader must be able to hold.</param>
        /// <remarks>The following exceptions can be thrown by this method:
        /// <list type="bullet">
        /// <item><term>E_POINTER - The pin passed in is null.</term></item>
        /// <item><term>HRESULT_FROM_WIN32(ERROR_SHARING_VIOLATION) - The pin is already associated with a change reader.That change reader must be disposed before the pin can be associated with a new change reader.</term></item>
        /// <item><term>E_ACCESSDENIED - The pin is not opened in Exclusive mode.</term></item>
        /// </list>
        /// </remarks>
        public Gpio​Change​Reader(Gpio​Pin pin, Int32 minCapacity)
        {

        }

        /// <summary>
        /// Gets the maximum number of change records that the GpioChangeReader can store at one time.
        /// </summary>
        /// <value>
        /// The maximum number of change records.
        /// </value>
        /// <remarks>When this maximum number of records is met, further changes will not be recorded and the IsOverflowed property will return true.</remarks>
        public int Capacity
        {
            get
            {
                return _capacity;
            }
        }

        /// <summary>
        /// Gets whether there are currently zero change records in the reader.
        /// </summary>
        /// <value>
        ///   Returns true if there are zero change items in the reader, and false otherwise
        /// </value>
        public bool IsEmpty
        {
            get
            {
                return (Length == 0);
            }
        }

        /// <summary>
        /// Gets whether an attempt to place a change record into the reader's buffer has failed due to the buffer being full.
        /// </summary>
        /// <value>
        ///   Returns true if an attempt at placement has been unsuccessful, and false otherwise.
        /// </value>
        /// <remarks>Removing an item from the buffer will cause IsOverflowed to reset to false.</remarks>
        public bool IsOverflowed
        {
            get
            {
                return _isOverflowed;
            }
        }

        /// <summary>
        /// Gets whether pin change recording is currently active.
        /// </summary>
        /// <value>
        ///   Returns true if pin changes are currently being recorded, and false otherwise.
        /// </value>
        public bool IsStarted
        {
            get
            {
                return _isStarted;
            }
        }

        /// <summary>
        /// Gets the number of records currently in the change reader.
        /// </summary>
        /// <value>
        /// The current number of change records.
        /// </value>
        public int Length
        {
            get
            {
                return _length;
            }
        }

        /// <summary>
        /// Gets or sets the polarity of transitions that will be recorded. The polarity may only be changed when pin change recording is not started.
        /// </summary>
        /// <value>
        /// Rising or Falling. The default polarity value is Falling.
        /// </value>
        /// <remarks>
        /// <para>Listening to a single edge (Falling or Rising) can be considerably more efficient than listening to both edges.</para>
        /// <para>The following exceptions can be thrown when setting the polarity:
        /// <list type="bullet">
        /// <item><term>E_INVALIDARG - value is not a valid GpioChangePolarity value.</term></item>
        /// <item><term>HRESULT_FROM_WIN32(ERROR_BAD_COMMAND) - change recording is currently active.Polarity can only be set before calling Start() or after calling Stop().</term></item>
        /// </list>
        /// </para>
        /// </remarks>
        public GpioChangePolarity Polarity
        {
            get
            {
                return _polarity;
            }

            set
            {
                // TODO implement validation logic as described in the documentation
                _polarity = value;
            }
        }

        /// <summary>
        /// Discards all change records from the reader's buffer.
        /// </summary>
        /// <remarks>This will also reset an active overflow condition, causing the IsOverflowed property to return false.</remarks>
        public void Clear()
        {

        }

        /// <summary>
        /// Removes and returns all items current in the reader's buffer.
        /// </summary>
        /// <returns>The returned vector enables random access to all the change records removed from the buffer.</returns>
        /// <remarks>This will also reset an active overflow condition, causing the IsOverflowed property to return false.</remarks>
        public GpioChangeRecord[] GetAllItems()
        {
            return new GpioChangeRecord[1];
        }

        /// <summary>
        /// Retrieves and removes the earliest inserted change record from the reader's buffer.
        /// </summary>
        /// <returns>A <see cref="GpioChangeRecord"/> structure containing the timestamp and polarity (rising or falling) of the change.</returns>
        /// <remarks>This will also reset an active overflow condition, causing the IsOverflowed property to return false.
        /// <para>The following exception can be thrown by this method:</para>
        /// <list type="bullet">
        /// <item><term>HRESULT_FROM_WIN32(ERROR_NO_MORE_ITEMS) - the reader's buffer is empty.</term></item>
        /// </list>
        /// </remarks>
        public GpioChangeRecord GetNextItem()
        {
            return new GpioChangeRecord();
        }

        /// <summary>
        /// Retrieves the earlier inserted change record from the reader's buffer, without removing it.
        /// </summary>
        /// <returns>A <see cref="GpioChangeRecord"/> structure containing the timestamp and polarity (rising or falling) of the change.</returns>
        /// <remarks>This will also reset an active overflow condition, causing the IsOverflowed property to return false.
        /// <para>The following exception can be thrown by this method:</para>
        /// <list type="bullet">
        /// <item><term>HRESULT_FROM_WIN32(ERROR_NO_MORE_ITEMS) - the reader's buffer is empty.</term></item>
        /// </list>
        /// </remarks>
        public GpioChangeRecord PeekNextItem()
        {
            return new GpioChangeRecord();
        }

        /// <summary>
        /// Starts recording changes in pin polarity. This method may only be called when change recording is not already active.
        /// </summary>
        /// <remarks>Calling Start() may enable or reconfigure interrupts for the pin.
        /// <para>The following exceptions can be thrown by this method:</para>
        /// <list type="bullet">
        /// <item><term>HRESULT_FROM_WIN32(ERROR_BAD_COMMAND) - change reading is not currently active.</term></item>
        /// <item><term>HRESULT_FROM_WIN32(ERROR_INVALID_HANDLE) - the change reader or the associated pin has been disposed.</term></item>
        /// </list>
        /// </remarks>
        public void Start()
        {

        }

        /// <summary>
        /// Stop recording changes in pin polarity. This method may only be called when change recording is currently active.
        /// </summary>
        /// <remarks>Calling Stop() may enable or reconfigure interrupts for the pin.
        /// <para>The following exceptions can be thrown by this method:</para>
        /// <list type="bullet">
        /// <item><term>HRESULT_FROM_WIN32(ERROR_BAD_COMMAND) - change reading is not currently active.</term></item>
        /// <item><term>HRESULT_FROM_WIN32(ERROR_INVALID_HANDLE) - the change reader or the associated pin has been disposed.</term></item>
        /// </list>
        /// </remarks>
        public void Stop()
        {

        }

        /// <summary>
        /// Waits for the buffer to fill with at least count number of items, at which point the async action will complete. This action is cancelable.
        /// </summary>
        /// <param name="count">The number of items with which the buffer must fill before the async operation completes.</param>
        /// <remarks>If the pin or change reader is closed while a wait is in progress, the async operation will be cancelled.
        /// <para>The following exceptions can be thrown by this method:</para>
        /// <list type="bullet">
        /// <item><term>E_INVALIDARG - count is 0, or count is greater than the buffer's capacity.</term></item>
        /// <item><term>HRESULT_FROM_WIN32(ERROR_INVALID_HANDLE) - The change reader was disposed of the associated pin was closed.</term></item>
        /// </list>
        /// </remarks>
        public void WaitForItems(Int32 count)
        {

        }
    }
}

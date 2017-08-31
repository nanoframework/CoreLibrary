//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Runtime.Events;
using System;
using System.Collections;
using System.Text;

namespace Windows.Devices.Gpio
{
    internal class GpioPinEventListener : IEventProcessor, IEventListener
    {
        // Map of pin numbers to GpioPin objects.
        private Hashtable _pinMap = new Hashtable();

        public GpioPinEventListener()
        {
            EventSink.AddEventProcessor(EventCategory.Gpio, this);
            EventSink.AddEventListener(EventCategory.Gpio, this);
        }

        public BaseEvent ProcessEvent(uint data1, uint data2, DateTime time)
        {
            return new GpioPinEvent
            {
                // Data1 is packed by PostManagedEvent, so we need to unpack the high word.
                PinNumber = (int)(data1 >> 16),
                Edge = (data2 == 0) ? GpioPinEdge.FallingEdge : GpioPinEdge.RisingEdge,
            };
        }

        public void InitializeForEventSource()
        {
        }

        public bool OnEvent(BaseEvent ev)
        {
            var pinEvent = (GpioPinEvent)ev;
            GpioPin pin = null;

            lock (_pinMap)
            {
                if (_pinMap.Contains(pinEvent.PinNumber))
                {
                    pin = (GpioPin)_pinMap[pinEvent.PinNumber];
                }
            }

            // Avoid calling this under a lock to prevent a potential lock inversion.
            if (pin != null)
            {
                pin.OnPinChangedInternal(pinEvent.Edge);
            }

            return true;
        }

        public void AddPin(int pinNumber, GpioPin pin)
        {
            lock (_pinMap)
            {
                _pinMap[pin.PinNumber] = pin;
            }
        }

        public void RemovePin(int pinNumber)
        {
            lock (_pinMap)
            {
                if (_pinMap.Contains(pinNumber))
                {
                    _pinMap.Remove(pinNumber);
                }
            }
        }
    }
}

//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace nanoFramework.Runtime.Events
{
    /// <summary>
    /// Provides a dispatcher for handling events.
    /// </summary>
    public class EventSink : NativeEventDispatcher
    {
        private static EventSink s_eventSink = null;
        private static Hashtable s_eventInfoTable = null;

        private class EventInfo
        {
            public EventInfo()
            {
                EventListener = null;
                EventFilter = null;
            }

            public IEventListener EventListener;
            public IEventListener EventFilter;
            public IEventProcessor EventProcessor;
            public EventCategory Category;
        }

        static EventSink()
        {
            s_eventSink = new EventSink();
            s_eventSink.OnInterrupt += new NativeEventHandler(s_eventSink.EventDispatchCallback);
        }

        // Pass the name to the base so it connects to driver
        private EventSink()
            : base("EventSink", 0)
        {
        }

        private void ProcessEvent(EventInfo eventInfo, BaseEvent ev)
        {
            if (eventInfo == null)
                return;

            if (eventInfo.EventFilter != null)
            {
                if (!eventInfo.EventFilter.OnEvent(ev))
                    return;
            }

            if (eventInfo.EventListener != null)
            {
                eventInfo.EventListener.OnEvent(ev);
            }
        }

        private void EventDispatchCallback(uint data1, uint data2, DateTime time)
        {
            EventInfo eventInfo = null;
            BaseEvent ev = null;

            GetEvent(data1, data2, time, ref eventInfo, ref ev);

            ProcessEvent(eventInfo, ev);
        }

        // Developer notes from original code
        // Add/RemoveEventFilter/Listener/Processor today supports only one listener and one filter
        // to reduce complexity, but this will certainly be not the case in future when
        // multiple parties will want to listent or filter same EventCategory. This was
        // one of the request from SideShow team, we will have to look into that.
        //

        /// <summary>
        /// Adds a listener for particular types of events.
        /// </summary>
        /// <param name="eventCategory">Selects the event category.</param>
        /// <param name="eventListener">Specifies the event listener.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void AddEventListener(EventCategory eventCategory, IEventListener eventListener)
        {
            EventInfo eventInfo = GetEventInfo(eventCategory);
            eventInfo.EventListener = eventListener;
            eventListener.InitializeForEventSource();
        }

        /// <summary>
        /// Adds an event filter to the dispatcher.
        /// </summary>
        /// <param name="eventCategory">Selects the event category.</param>
        /// <param name="eventFilter">Specifies the event filter.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void AddEventFilter(EventCategory eventCategory, IEventListener eventFilter)
        {
            EventInfo eventInfo = GetEventInfo(eventCategory);
            eventInfo.EventFilter = eventFilter;
            eventFilter.InitializeForEventSource();

        }

        /// <summary>
        /// Adds an event processing routine.
        /// </summary>
        /// <param name="eventCategory">Selects the event category.</param>
        /// <param name="eventProcessor">Specifies the event processor.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void AddEventProcessor(EventCategory eventCategory, IEventProcessor eventProcessor)
        {
            EventInfo eventInfo = GetEventInfo(eventCategory);
            eventInfo.EventProcessor = eventProcessor;
        }

        /// <summary>
        /// Removes an event listener.
        /// </summary>
        /// <param name="eventCategory">Selects an event category.</param>
        /// <param name="eventListener">Specifies the event listener to be removed.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void RemoveEventListener(EventCategory eventCategory, IEventListener eventListener)
        {
            EventInfo eventInfo = GetEventInfo(eventCategory);

            if (eventInfo.EventListener == eventListener)
            {
                eventInfo.EventListener = null;
            }
        }

        /// <summary>
        /// Removes an event filter.
        /// </summary>
        /// <param name="eventCategory">Selects an event category.</param>
        /// <param name="eventFilter">Specifies the event filter to be removed.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void RemoveEventFilter(EventCategory eventCategory, IEventListener eventFilter)
        {
            EventInfo eventInfo = GetEventInfo(eventCategory);

            if (eventInfo.EventFilter == eventFilter)
            {
                eventInfo.EventFilter = null;
            }
        }

        /// <summary>
        /// Removes an event processor.
        /// </summary>
        /// <param name="eventCategory">Selects an event category.</param>
        /// <param name="eventProcessor">Specifies the event processor to be removed.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void RemoveEventProcessor(EventCategory eventCategory, IEventProcessor eventProcessor)
        {
            EventInfo eventInfo = GetEventInfo(eventCategory);

            if (eventInfo.EventProcessor == eventProcessor)
            {
                eventInfo.EventProcessor = null;
            }
        }

        /// <summary>
        /// Processes event information.
        /// </summary>
        /// <param name="category">The event category.</param>
        /// <param name="subCategory">The event subcategory.</param>
        /// <param name="data1">Data related to the event.</param>
        /// <param name="data2">Data related to the event.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void PostManagedEvent(byte category, byte subCategory, ushort data1, uint data2)
        {
            if (s_eventSink != null)
            {
                uint d = (uint)(((uint)data1 << 16) | ((uint)category << 8) | subCategory);
                DateTime time = DateTime.UtcNow;
                s_eventSink.EventDispatchCallback(d, data2, time);
            }
        }

        private static EventInfo GetEventInfo(EventCategory category)
        {
            // because of lack of constructors in native code we need to check if this field has been initialized
            if (s_eventInfoTable == null)
            {
                s_eventInfoTable = new Hashtable();
            }

            if (s_eventInfoTable.Contains(category))
            {
                // event already registered
                return (EventInfo)s_eventInfoTable[category];
            }
            else
            {
                // create a new EventInfo...
                EventInfo eventInfo = new EventInfo()
                {
                    Category = category
                };

                // ... and add it to the events table
                s_eventInfoTable.Add(category, eventInfo);

                return eventInfo;
            }
        }

        private static void GetEvent(uint data1, uint data2, DateTime time, ref EventInfo eventInfo, ref BaseEvent ev)
        {
            byte category = (byte)((data1 >> 8) & 0xFF);

            eventInfo = GetEventInfo((EventCategory)category);
            if (eventInfo.EventProcessor != null)
            {
                ev = eventInfo.EventProcessor.ProcessEvent(data1, data2, time);
            }
            else
            {
                GenericEvent genericEvent = new GenericEvent()
                {
                    Time = time,
                    Message = (byte)(data1 & 0xFF),
                    Category = category,
                    Data = (data1 >> 16) & 0xFFFF
                };
                ev = genericEvent;
            }
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void EventConfig();
    }
}

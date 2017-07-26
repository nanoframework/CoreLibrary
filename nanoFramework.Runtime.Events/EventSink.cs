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
        private static EventSink _eventSink = null;
        private static ArrayList _eventInfoTable = new ArrayList();

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
            _eventSink = new EventSink();
            _eventSink.OnInterrupt += new NativeEventHandler(_eventSink.EventDispatchCallback);
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

        private void EventDispatchCallback(uint data1, uint data2, object tag, DateTime time)
        {
            EventInfo eventInfo = null;
            BaseEvent ev = null;

            GetEvent(data1, data2, tag, time, ref eventInfo, ref ev);

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

        // doesnt' seem to be used anywhere
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //public static void PostManagerEvent(byte category, byte subCategory, ushort data, object tag)
        //{
        //    if (_eventSink != null)
        //    {
        //        uint d = (uint)(((uint)data << 16) | ((uint)category << 8) | subCategory);
        //        DateTime time = DateTime.UtcNow;
        //        _eventSink.EventDispatchCallback(d, tag, time);
        //    }
        //}

        private static EventInfo GetEventInfo(EventCategory category)
        {

            // What we need here is hashtable. Until we get one, we have this implementation where we browse through
            // registered eventInfos and attempt retrieving matchine one.

            EventInfo eventInfo = null;
            for (int i = 0; i < _eventInfoTable.Count; i++)
            {
                if (((EventInfo)_eventInfoTable[i]).Category == category)
                {
                    eventInfo = (EventInfo)_eventInfoTable[i];
                    break;
                }
            }

            if (eventInfo == null)
            {
                eventInfo = new EventInfo()
                {
                    Category = category
                };
                _eventInfoTable.Add(eventInfo);
            }

            return eventInfo;
        }

        private static void GetEvent(uint data1, uint data2, object tag, DateTime time, ref EventInfo eventInfo, ref BaseEvent ev)
        {
            byte category = (byte)((data1 >> 8) & 0xFF);

            eventInfo = GetEventInfo((EventCategory)category);
            if (eventInfo.EventProcessor != null)
            {
                ev = eventInfo.EventProcessor.ProcessEvent(data1, data2, tag, time);
            }
            else
            {
                GenericEvent genericEvent = new GenericEvent()
                {
                    Time = time,
                    Message = (byte)(data1 & 0xFF),
                    Category = category,
                    Data = (data1 >> 16) & 0xFFFF,
                    Tag = tag
                };
                ev = genericEvent;
            }
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void EventConfig();
    }
}

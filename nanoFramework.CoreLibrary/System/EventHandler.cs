﻿//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// Represents the method that will handle an event that has no event data.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An object that contains no event data.</param>
    public delegate void EventHandler(object sender, EventArgs e);

    /// <summary>
    /// Represents the method that will handle an event when the event provides data.
    /// </summary>
    /// <typeparam name="TEventArgs">The type of the event data generated by the event.</typeparam>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An object that contains the event data.</param>
#pragma warning disable S3246 // This is nanoFramework implementation of the EventHandler. It's meant to be this way.
    public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
#pragma warning restore S3246 // Generic type parameters should be co/contravariant when possible
}

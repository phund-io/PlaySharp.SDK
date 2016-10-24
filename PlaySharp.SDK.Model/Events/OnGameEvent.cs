// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnGameEvent.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.Events
{
    using System;
    using System.Security;

    using JetBrains.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public class OnGameEvent
    {
        public OnGameEvent(int id, [NotNull] string eventName, int sender, string senderName = null)
        {
            if (eventName == null)
            {
                throw new ArgumentNullException(nameof(eventName));
            }

            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            if (sender < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sender));
            }

            this.Id = id;
            this.EventName = eventName;
            this.Sender = sender;
            this.SenderName = senderName;
        }

        public string EventName { [NotNull] get; }

        public int Id { get; }

        public int Sender { [NotNull] get; }

        public string SenderName { [CanBeNull] get; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnGameChat.cs" company="PlaySharp">
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
    public class OnGameChat
    {
        public OnGameChat([NotNull] string sender, [NotNull] string message)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            this.Sender = sender;
            this.Message = message;
        }

        public string Message { [NotNull] get; }

        public bool Process { get; set; }

        public string Sender { [NotNull] get; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnIssueOrder.cs" company="PlaySharp">
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
    public class OnIssueOrder
    {
        public OnIssueOrder(int sender, int target, int orderType, bool process = true)
        {
            if (sender < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sender));
            }

            if (target < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(target));
            }

            if (orderType < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderType));
            }

            this.Sender = sender;
            this.Target = target;
            this.OrderType = orderType;
            this.Process = process;
        }

        public int OrderType { get; }

        public bool Process { get; set; }

        public int Sender { get; }

        public int Target { get; }
    }
}
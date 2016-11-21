// <copyright file="AttackObject.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Trackers
{
    using System;
    using System.Security;

    using Ensage;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public class AttackObject : IAttackObject
    {
        public AttackObject(Unit instance, NetworkActivity state = NetworkActivity.Idle, long tick = 0)
        {
            this.Instance = instance;
            this.State = state;
            this.Created = tick > 0 ? tick : Environment.TickCount;
        }

        public long Created { get; }

        public Unit Instance { get; }

        public NetworkActivity State { get; }
    }
}
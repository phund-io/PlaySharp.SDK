// <copyright file="AttackObject.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Trackers
{
    using System.Security;

    using Ensage;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public class AttackObject : IAttackObject
    {
        public AttackObject(string id, Unit instance, NetworkActivity state = NetworkActivity.Idle)
        {
            this.Id = id;
            this.Instance = instance;
            this.State = state;
        }

        public string Id { get; }

        public Unit Instance { get; }

        public NetworkActivity State { get; }
    }
}
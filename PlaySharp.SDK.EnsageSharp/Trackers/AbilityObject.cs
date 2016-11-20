// <copyright file="AbilityObject.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Trackers
{
    using System.Collections.Generic;
    using System.Security;

    using Ensage;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public class AbilityObject : IAbilityObject
    {
        public AbilityObject(string id, Unit instance, params ParticleEffect[] particles)
        {
            this.Id = id;
            this.Instance = instance;
            this.Particles = particles;
        }

        public string Id { get; }

        public Unit Instance { get; }

        public IReadOnlyList<ParticleEffect> Particles { get; }
    }
}
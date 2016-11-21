// <copyright file="IAbilityObject.cs" company="PlaySharp">
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
    public interface IAbilityObject : IAbilityObject<Ability>
    {
        IReadOnlyList<ParticleEffect> Particles { get; }
    }
}
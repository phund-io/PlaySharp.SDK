// <copyright file="IObjectManager.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Objects
{
    using System.Collections.Generic;
    using System.Security;

    using Ensage;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IObjectManager : IObjectManagerProvider<Entity, uint, Hero>
    {
        IEnumerable<LinearProjectile> LinearProjectiles { [SecuritySafeCritical] get; }

        IEnumerable<ParticleEffect> ParticleEffects { [SecuritySafeCritical] get; }

        Player Player { [SecuritySafeCritical] get; }

        IEnumerable<Projectile> Projectiles { [SecuritySafeCritical] get; }

        IEnumerable<TrackingProjectile> TrackingProjectiles { [SecuritySafeCritical] get; }
    }
}
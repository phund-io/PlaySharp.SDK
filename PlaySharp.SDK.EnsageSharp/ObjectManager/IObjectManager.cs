// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IObjectManager.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.ObjectManager
{
    using System.Collections.Generic;
    using System.Security;

    using Ensage;

    using JetBrains.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IObjectManager : IObjectManager<Entity, uint, Hero>
    {
        IEnumerable<LinearProjectile> LinearProjectiles { [SecuritySafeCritical] get; }

        Player Player { [SecuritySafeCritical] get; }

        IEnumerable<ParticleEffect> ParticleEffects { [SecuritySafeCritical] get; }

        IEnumerable<Projectile> Projectiles { [SecuritySafeCritical] get; }

        IEnumerable<TrackingProjectile> TrackingProjectiles { [SecuritySafeCritical] get; }
    }
}
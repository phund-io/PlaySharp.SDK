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
        IEnumerable<LinearProjectile> LinearProjectiles { [ItemNotNull] get; }

        IEnumerable<ParticleEffect> ParticleEffects { [ItemNotNull] get; }

        Player Player { [NotNull] get; }

        IEnumerable<Projectile> Projectiles { [ItemNotNull] get; }

        IEnumerable<TrackingProjectile> TrackingProjectiles { [ItemNotNull] get; }
    }
}
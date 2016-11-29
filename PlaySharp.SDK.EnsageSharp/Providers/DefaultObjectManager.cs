// <copyright file="DefaultObjectManager.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Providers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;

    using Ensage;

    using PlaySharp.SDK.Composition.Attributes;
    using PlaySharp.SDK.Objects;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    [RegisterObjectManager("SDK")]
    public class DefaultObjectManager : IObjectManager
    {
        public Hero Hero
        {
            [SecuritySafeCritical]
            get
            {
                return ObjectManager.LocalHero;
            }
        }

        public IEnumerable<LinearProjectile> LinearProjectiles
        {
            [SecuritySafeCritical]
            get
            {
                return ObjectManager.LinearProjectiles;
            }
        }

        public IEnumerable<ParticleEffect> ParticleEffects
        {
            [SecuritySafeCritical]
            get
            {
                return ObjectManager.ParticleEffects;
            }
        }

        public Player Player
        {
            [SecuritySafeCritical]
            get
            {
                return ObjectManager.LocalPlayer;
            }
        }

        public IEnumerable<Projectile> Projectiles
        {
            [SecuritySafeCritical]
            get
            {
                return ObjectManager.LinearProjectiles;
            }
        }

        public IEnumerable<TrackingProjectile> TrackingProjectiles
        {
            [SecuritySafeCritical]
            get
            {
                return ObjectManager.TrackingProjectiles;
            }
        }

        [SecuritySafeCritical]
        public IEnumerable<TUnit> Get<TUnit>() where TUnit : Entity, new()
        {
            return ObjectManager.GetEntities<TUnit>();
        }

        [SecuritySafeCritical]
        public TUnit Get<TUnit>(uint id) where TUnit : Entity, new()
        {
            return ObjectManager.GetEntities<TUnit>().First(e => e.Handle == id);
        }

        [SecuritySafeCritical]
        public IEnumerable<TUnit> GetFast<TUnit>() where TUnit : Entity, new()
        {
            return ObjectManager.GetEntitiesFast<TUnit>();
        }

        [SecuritySafeCritical]
        public ParallelQuery<TUnit> GetParallel<TUnit>() where TUnit : Entity, new()
        {
            return ObjectManager.GetEntitiesParallel<TUnit>();
        }
    }
}
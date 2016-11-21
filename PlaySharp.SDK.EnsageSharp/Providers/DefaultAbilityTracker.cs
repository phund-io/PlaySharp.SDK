// <copyright file="DefaultAbilityTracker.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Providers
{
    using System.Security;

    using Ensage;

    using PlaySharp.SDK.Composition.Attributes;
    using PlaySharp.SDK.Trackers;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    [RegisterAbilityTracker("SDK", "dev", "work in progress")]
    public class DefaultAbilityTracker : NotifyCollection<IAbilityObject>, IAbilityTracker
    {
        public DefaultAbilityTracker()
        {
            ObjectManager.OnAddTrackingProjectile += this.OnAddTrackingProjectile;
            ObjectManager.OnRemoveTrackingProjectile += this.OnRemoveTrackingProjectile;

            ObjectManager.OnAddLinearProjectile += this.OnAddLinearProjectile;
            ObjectManager.OnRemoveLinearProjectile += this.OnRemoveLinearProjectile;
        }

        private void OnAddLinearProjectile(LinearProjectileEventArgs args)
        {
            this.Add(new AbilityObject(null, args.Projectile.ParticleEffect));
        }

        private void OnAddTrackingProjectile(TrackingProjectileEventArgs args)
        {
            this.Add(new AbilityObject(null, args.Projectile.ParticleEffect));
        }

        private void OnRemoveLinearProjectile(LinearProjectileEventArgs args)
        {
            this.Add(new AbilityObject(null, args.Projectile.ParticleEffect));
        }

        private void OnRemoveTrackingProjectile(TrackingProjectileEventArgs args)
        {
            this.Add(new AbilityObject(null, args.Projectile.ParticleEffect));
        }
    }
}
// <copyright file="AbilityBase.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Casting
{
    using System;
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    using SharpDX;

    [PublicAPI]
    [SecuritySafeCritical]
    public abstract class AbilityBase<TAbility, THero, TUnit> : IAbility<TAbility, TUnit>
    {
        protected AbilityBase([NotNull] THero owner, [NotNull] TAbility ability)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            if (ability == null)
            {
                throw new ArgumentNullException(nameof(ability));
            }

            this.Owner = owner;
            this.Instance = ability;
        }

        public TAbility Instance { get; }

        public THero Owner { get; }

        public abstract float GetDamage(TUnit target);

        public abstract bool Use(TUnit target);

        public abstract bool Use(Vector3 position);
    }
}
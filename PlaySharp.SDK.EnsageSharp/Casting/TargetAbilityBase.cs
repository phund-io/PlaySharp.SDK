// <copyright file="TargetAbilityBase.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Casting
{
    using System.Security;

    using Ensage;

    using PlaySharp.Toolkit.Helper.Annotations;

    using SharpDX;

    [PublicAPI]
    [SecuritySafeCritical]
    public abstract class TargetAbilityBase : ITargetAbility
    {
        protected TargetAbilityBase(Unit owner, Ability instance)
        {
            this.Owner = owner;
            this.Instance = instance;
        }

        public Ability Instance { get; }

        public Unit Owner { get; }

        public abstract float GetDamage(Unit target);

        public abstract bool Use(Unit target);

        public abstract bool Use(Vector3 position);
    }
}
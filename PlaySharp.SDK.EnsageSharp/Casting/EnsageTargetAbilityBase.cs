// <copyright file="EnsageTargetAbilityBase.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Casting
{
    using System.Security;

    using Ensage;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public abstract class EnsageTargetAbilityBase : TargetAbilityBase<Ability, Hero, Unit>, IEnsageAbility
    {
        protected EnsageTargetAbilityBase([NotNull] Hero owner, [NotNull] Ability ability)
            : base(owner, ability)
        {
        }
    }
}
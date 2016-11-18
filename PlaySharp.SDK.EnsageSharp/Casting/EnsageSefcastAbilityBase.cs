// <copyright file="EnsageSefcastAbilityBase.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Casting
{
    using System.Security;

    using Ensage;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public abstract class EnsageSefcastAbilityBase : SefcastAbilityBase<Ability, Hero, Unit>, IEnsageAbility
    {
        protected EnsageSefcastAbilityBase([NotNull] Hero owner, [NotNull] Ability ability)
            : base(owner, ability)
        {
        }
    }
}
// <copyright file="TargetAbilityBase.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Casting
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public abstract class TargetAbilityBase<TAbility, THero, TUnit> : AbilityBase<TAbility, THero, TUnit>
    {
        protected TargetAbilityBase([NotNull] THero owner, [NotNull] TAbility ability)
            : base(owner, ability)
        {
        }
    }
}
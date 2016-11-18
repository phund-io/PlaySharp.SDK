// <copyright file="SefcastAbilityBase.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Casting
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public abstract class SefcastAbilityBase<TAbility, THero, TUnit> : AbilityBase<TAbility, THero, TUnit>
    {
        protected SefcastAbilityBase([NotNull] THero owner, [NotNull] TAbility ability)
            : base(owner, ability)
        {
        }
    }
}
// <copyright file="ITargetAbility.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Casting
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface ITargetAbility<out TAbility, in TUnit, out TOwner> : IAbility<TAbility, TUnit, TOwner>
    {
    }
}
// <copyright file="ISelfcastAbility.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Casting
{
    using System.Security;

    using Ensage;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface ISelfcastAbility : ISelfcastAbility<Ability, Unit, Unit>, IAbility
    {
    }
}
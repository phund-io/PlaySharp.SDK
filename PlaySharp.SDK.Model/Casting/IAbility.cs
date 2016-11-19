// <copyright file="IAbility.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Casting
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    using SharpDX;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IAbility<out TAbility, in TUnit, out TOwner>
    {
        TAbility Instance { [NotNull] get; }

        TOwner Owner { [NotNull] get; }

        float GetDamage([NotNull] TUnit target);

        bool Use([NotNull] TUnit target);

        bool Use(Vector3 position);
    }
}
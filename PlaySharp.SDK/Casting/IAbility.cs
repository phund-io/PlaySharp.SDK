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
    public interface IAbility<out TAbility, in TUnit>
    {
        TAbility Instance { [NotNull] get; }

        float GetDamage([NotNull] TUnit target);

        bool Use([NotNull] TUnit target);

        bool Use(Vector3 position);
    }
}
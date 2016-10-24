// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DamageType.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.Game
{
    using System.Security;

    using JetBrains.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public enum DamageType
    {
        Magical,

        Physical,

        True,

        Mixed
    }
}
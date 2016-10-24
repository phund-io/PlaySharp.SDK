// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IObjectManager.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.ObjectManager
{
    using System.Security;

    using JetBrains.Annotations;

    using LeagueSharp;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IObjectManager : IObjectManager<GameObject, int, Obj_AI_Hero>
    {
    }
}
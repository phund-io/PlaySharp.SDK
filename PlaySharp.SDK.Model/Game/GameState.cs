// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameState.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.Game
{
    using System.Security;

    using JetBrains.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public enum GameState
    {
        Connecting = 1,

        Running = 2,

        Paused = 3,

        Finished = 4,

        Exiting = 5,
    }
}
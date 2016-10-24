// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnGameStateChanged.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.Events
{
    using System;
    using System.ComponentModel;
    using System.Security;

    using JetBrains.Annotations;

    using PlaySharp.SDK.Game;

    [PublicAPI]
    [SecuritySafeCritical]
    public class OnGameStateChanged
    {
        public OnGameStateChanged(GameState gameState)
        {
            if (!Enum.IsDefined(typeof(GameState), gameState))
            {
                throw new InvalidEnumArgumentException(nameof(gameState), (int)gameState, typeof(GameState));
            }

            this.GameState = gameState;
        }

        public GameState GameState { get; }
    }
}
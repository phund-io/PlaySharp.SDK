// <copyright file="OnGameStateChanged.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Events
{
    using System;
    using System.ComponentModel;
    using System.Security;

    using PlaySharp.SDK.Game;
    using PlaySharp.Toolkit.Helper.Annotations;

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
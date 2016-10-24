// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnGameEnd.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.Events
{
    using System;
    using System.Security;

    using JetBrains.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public class OnGameEnd
    {
        public OnGameEnd(int team)
        {
            if (team < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(team));
            }

            this.WinningTeam = team;
        }

        public int WinningTeam { get; }
    }
}
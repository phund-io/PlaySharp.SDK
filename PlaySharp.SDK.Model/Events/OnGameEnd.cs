// <copyright file="OnGameEnd.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Events
{
    using System;
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

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
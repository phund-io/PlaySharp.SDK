// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnGameStart.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.Events
{
    using System.Security;

    using JetBrains.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public class OnGameStart
    {
        public OnGameStart(bool firstStart = false)
        {
            this.IsFirstStart = firstStart;
        }

        public bool IsFirstStart { get; }
    }
}
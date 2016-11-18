// <copyright file="OnGameStart.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Events
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

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
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnWndProc.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.Events
{
    using System.Security;

    using JetBrains.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public class OnWndProc
    {
        public OnWndProc(uint msg, int lParam, uint wParam, bool process = true)
        {
            this.Msg = msg;
            this.LParam = lParam;
            this.WParam = wParam;
            this.Process = process;
        }

        public int LParam { get; }

        public uint Msg { get; }

        public bool Process { get; }

        public uint WParam { get; }
    }
}
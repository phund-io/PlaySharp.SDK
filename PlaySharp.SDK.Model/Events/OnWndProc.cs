// <copyright file="OnWndProc.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Events
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

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
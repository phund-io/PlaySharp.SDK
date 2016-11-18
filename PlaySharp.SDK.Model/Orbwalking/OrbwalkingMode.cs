// <copyright file="OrbwalkingMode.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Orbwalking
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public enum OrbwalkingMode
    {
        /// <summary>
        ///     The orbwalker will only last hit minions.
        /// </summary>
        LastHit,

        /// <summary>
        ///     The orbwalker will alternate between last hitting and auto attacking champions.
        /// </summary>
        Mixed,

        /// <summary>
        ///     The orbwalker will clear the lane of minions as fast as possible while attempting to get the last hit.
        /// </summary>
        LaneClear,

        /// <summary>
        ///     The orbwalker will only attack the target.
        /// </summary>
        Combo,

        /// <summary>
        ///     The orbwalker will only last hit minions as late as possible.
        /// </summary>
        Freeze,

        /// <summary>
        ///     The orbwalker will only move.
        /// </summary>
        CustomMode,

        /// <summary>
        ///     The orbwalker does nothing.
        /// </summary>
        None,

        /// <summary>
        ///     The flee mode.
        /// </summary>
        Flee
    }
}
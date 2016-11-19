// <copyright file="ITargetSelector.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Targetselection
{
    using System;
    using System.Collections.Generic;
    using System.Security;

    using PlaySharp.SDK.Game;
    using PlaySharp.Toolkit.Helper.Annotations;

    using SharpDX;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface ITargetSelector<TUnit>
        where TUnit : class
    {
        event EventHandler<OnTargetChanged<TUnit>> OnTargetChanged;

        TUnit FocusTarget { [CanBeNull] get; [CanBeNull] set; }

        [CanBeNull]
        TUnit GetTarget(float range, DamageType type, Vector3? from = null);

        [CanBeNull]
        TUnit GetTarget([NotNull] Func<IReadOnlyList<TUnit>, TUnit> selector);
    }
}
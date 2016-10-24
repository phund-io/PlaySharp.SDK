// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITargetSelector.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.TargetSelector
{
    using System;
    using System.Collections.Generic;
    using System.Security;

    using JetBrains.Annotations;

    using PlaySharp.SDK.Game;

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
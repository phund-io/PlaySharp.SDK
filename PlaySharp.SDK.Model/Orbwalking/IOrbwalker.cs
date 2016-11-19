// <copyright file="IOrbwalker.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Orbwalking
{
    using System;
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    using SharpDX;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IOrbwalker<TUnit>
        where TUnit : class
    {
        event EventHandler<OnAttack<TUnit>> OnAttack;

        event EventHandler<OnPostAttack<TUnit>> OnPostAttack;

        event EventHandler<OnPreAttack<TUnit>> OnPreAttack;

        bool AutoAttack { get; set; }

        float AutoAttackDelay { get; set; }

        bool IsEnabled { get; set; }

        bool Move { get; set; }

        float MoveDelay { get; set; }

        void AttackTo([NotNull] TUnit target);

        void AttackTo(Vector3 position);

        bool CanAutoAttack(float extraTime);

        bool CanMove(float extraTime);

        float GetAutoAttackRange([NotNull] TUnit target);

        float GetRealAutoAttackRange([NotNull] TUnit target);

        bool InAutoAttackRange([NotNull] TUnit target);

        bool IsAutoAttack([NotNull] string name);

        bool IsAutoAttackReset([NotNull] string name);

        void MoveTo(Vector3 position);

        void MoveTo([NotNull] TUnit target);

        void ResetAutoAttackTimer();
    }
}
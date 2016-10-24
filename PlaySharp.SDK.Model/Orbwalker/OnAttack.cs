// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnAttack.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.Orbwalker
{
    using System;
    using System.Security;

    using JetBrains.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public class OnAttack<TUnit>
        where TUnit : class
    {
        public OnAttack([NotNull] TUnit target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            this.Target = target;
        }

        public TUnit Target { [NotNull] get; }
    }
}
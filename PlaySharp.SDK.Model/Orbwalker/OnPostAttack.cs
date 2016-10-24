// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnPostAttack.cs" company="PlaySharp">
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
    public class OnPostAttack<TUnit>
        where TUnit : class
    {
        public OnPostAttack([NotNull] TUnit target)
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
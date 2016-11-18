// <copyright file="OnAttack.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Orbwalking
{
    using System;
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

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
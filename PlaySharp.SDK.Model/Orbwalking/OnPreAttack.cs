// <copyright file="OnPreAttack.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Orbwalking
{
    using System;
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public class OnPreAttack<TUnit>
        where TUnit : class
    {
        public OnPreAttack([NotNull] TUnit target)
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
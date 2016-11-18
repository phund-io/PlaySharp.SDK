// <copyright file="OnTargetChanged.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Targetselection
{
    using System;
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public class OnTargetChanged<TUnit>
        where TUnit : class
    {
        public OnTargetChanged([NotNull] TUnit target)
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
// <copyright file="EnsageServiceContext.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition
{
    using System;
    using System.Security;

    using Ensage;

    using PlaySharp.SDK.Composition.Repositories;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public sealed class EnsageServiceContext : IEnsageServiceContext
    {
        public EnsageServiceContext([NotNull] Hero unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }

            this.Owner = unit;
        }

        public Hero Owner { get; }

        public bool Equals(Hero other)
        {
            return this.Owner.Equals(other);
        }
    }
}
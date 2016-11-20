// <copyright file="IAttackTracker.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Trackers
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IAttackTracker<out TId, out TAttackObject> : INotifyCollectionChanged
    {
        IReadOnlyList<IAttackObject<TId, TAttackObject>> Attacks { [NotNull] [ItemNotNull] get; }
    }
}
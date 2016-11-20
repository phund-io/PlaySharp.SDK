// <copyright file="IAbilityTracker.cs" company="PlaySharp">
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
    public interface IAbilityTracker<out TId, out TAbilityObject> : INotifyCollectionChanged
    {
        IReadOnlyList<IAbilityObject<TId, TAbilityObject>> Attacks { [NotNull] [ItemNotNull] get; }
    }
}
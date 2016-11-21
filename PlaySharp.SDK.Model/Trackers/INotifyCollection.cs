// <copyright file="INotifyCollection.cs" company="PlaySharp">
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
    public interface INotifyCollection<T> : INotifyCollectionChanged
    {
        IReadOnlyList<T> Items { [NotNull] [ItemNotNull] get; }

        [NotNull]
        T Add([NotNull] T item);

        void OnCollectionChanged(NotifyCollectionChangedAction type, [NotNull] object item);

        [NotNull]
        T Remove([NotNull] T item);
    }
}
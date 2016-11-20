// <copyright file="CollectionChangedBase.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition
{
    using System;
    using System.Collections.Specialized;

    using PlaySharp.Toolkit.Helper.Annotations;

    public abstract class CollectionChangedBase : INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected virtual void OnCollectionChanged(NotifyCollectionChangedAction type, [NotNull] object item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            this.CollectionChanged?.Invoke(
                    this,
                    new NotifyCollectionChangedEventArgs(type, item));
        }
    }
}
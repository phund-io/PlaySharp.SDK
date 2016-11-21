// <copyright file="NotifyCollection.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Trackers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    using PlaySharp.Toolkit.Helper.Annotations;

    public abstract class NotifyCollection<T> : INotifyCollection<T>
    {
        protected readonly List<T> Objects = new List<T>();

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public IReadOnlyList<T> Items => this.Objects;

        public virtual T Add([NotNull] T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (this.Objects.Contains(item))
            {
                return item;
            }

            // add and notify
            this.Objects.Add(item);
            this.OnCollectionChanged(NotifyCollectionChangedAction.Add, item);
            return item;
        }

        public void OnCollectionChanged(NotifyCollectionChangedAction type, object item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            this.CollectionChanged?.Invoke(
                    this,
                    new NotifyCollectionChangedEventArgs(type, item));
        }

        public virtual T Remove([NotNull] T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (!this.Objects.Contains(item))
            {
                return item;
            }

            // remove and notify
            this.Objects.Remove(item);
            this.OnCollectionChanged(NotifyCollectionChangedAction.Remove, item);
            return item;
        }
    }
}
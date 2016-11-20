// <copyright file="ServiceRepositoryBase.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public class ServiceRepositoryBase<TService> : CollectionChangedBase, IServiceRepository<TService>
        where TService : class
    {
        protected readonly List<TService> services = new List<TService>();

        private TService activeService;

        public event EventHandler<ActiveServiceChangedEventArgs<TService>> ActiveChanged;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public virtual TService ActiveService
        {
            get
            {
                return this.activeService;
            }

            set
            {
                if (Equals(value, this.activeService))
                {
                    return;
                }

                this.activeService = value;
                this.OnActiveChanged(value);
            }
        }

        public virtual IReadOnlyList<TService> Services
        {
            get
            {
                return this.services;
            }
        }

        public virtual void Register([NotNull] TService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            if (this.services.Contains(service))
            {
                return;
            }

            // add and notify
            this.services.Add(service);
            this.OnCollectionChanged(NotifyCollectionChangedAction.Add, service);
        }

        public virtual void Unregister([NotNull] TService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            if (!this.services.Contains(service))
            {
                return;
            }

            // remove and notify
            this.services.Remove(service);
            this.OnCollectionChanged(NotifyCollectionChangedAction.Remove, service);
        }

        protected virtual void OnActiveChanged([NotNull] TService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            this.ActiveChanged?.Invoke(
                    this,
                    new ActiveServiceChangedEventArgs<TService>(service));
        }
    }
}
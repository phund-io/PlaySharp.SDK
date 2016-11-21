// <copyright file="ServiceRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition
{
    using System;
    using System.Security;

    using PlaySharp.SDK.Trackers;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public class ServiceRepository<TService> : NotifyCollection<TService>, IServiceRepository<TService>
        where TService : class
    {
        private TService activeService;

        public event EventHandler<ActiveServiceChangedEventArgs<TService>> ActiveChanged;

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
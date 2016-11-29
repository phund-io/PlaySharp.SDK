// <copyright file="ServiceRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Security;

    using log4net;

    using PlaySharp.SDK.Composition.Metadata;
    using PlaySharp.SDK.Trackers;
    using PlaySharp.Toolkit.Helper;
    using PlaySharp.Toolkit.Helper.Annotations;
    using PlaySharp.Toolkit.Logging;

    [PublicAPI]
    [SecuritySafeCritical]
    public abstract class ServiceRepository<TService, TMetadata> : NotifyCollection<Lazy<TService, TMetadata>>,
                                                                   IServiceRepository<Lazy<TService, TMetadata>>,
                                                                   IDisposable
        where TService : class
        where TMetadata : class, IServiceMetadata
    {
        private static readonly ILog Log = AssemblyLogs.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private Lazy<TService, TMetadata> activeService;

        private bool disposed;

        public event EventHandler<ActiveServiceChangedEventArgs<Lazy<TService, TMetadata>>> ActiveChanged;

        public virtual Lazy<TService, TMetadata> ActiveService
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

                this.Deactivate(this.activeService);
                this.Activate(value);
                this.activeService = value;

                this.OnActiveChanged(value);
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Activate(Lazy<TService, TMetadata> service)
        {
            var activatable = service?.Value as IActivatable;

            if (activatable == null)
            {
                return;
            }

            if (activatable.IsActive)
            {
                return;
            }

            Log.Info($"Activate {service.Metadata.Name}-{service.Metadata.Version}");
            activatable.Activate();
        }

        protected void Deactivate(Lazy<TService, TMetadata> service)
        {
            if (service == null)
            {
                return;
            }

            if (!service.IsValueCreated)
            {
                return;
            }

            var deactivatable = service.Value as IDeactivatable;

            if (deactivatable == null)
            {
                return;
            }

            Log.Info($"Deactivate {service.Metadata.Name}-{service.Metadata.Version}");
            deactivatable.Deactivate();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.ActiveService = null;
                this.Clear();
            }

            this.disposed = true;
        }

        protected virtual void OnActiveChanged([NotNull] Lazy<TService, TMetadata> service)
        {
            this.ActiveChanged?.Invoke(
                    this,
                    new ActiveServiceChangedEventArgs<Lazy<TService, TMetadata>>(service));
        }

        protected void Update(IEnumerable<Lazy<TService, TMetadata>> items)
        {
            if (items == null)
            {
                return;
            }

            try
            {
                var selection = this.ActiveService.Metadata.Name;

                this.Clear();
                this.AddRange(items.ToList());

                if (this.Items.Any(s => s.Metadata.Name == selection))
                {
                    this.ActiveService = this.Items.First(s => s.Metadata.Name == selection);
                }
                else
                {
                    this.ActiveService = this.Items.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}
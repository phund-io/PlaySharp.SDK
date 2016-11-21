// <copyright file="ContainerRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Reflection;
    using System.Security;

    using log4net;

    using PlaySharp.Toolkit.Helper.Annotations;
    using PlaySharp.Toolkit.Logging;

    [PublicAPI]
    [SecuritySafeCritical]
    public abstract class ContainerRepository<TContext>
        where TContext : class, IServiceContext
    {
        private static readonly ILog Log = AssemblyLogs.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected ContainerRepository()
        {
            this.Catalog = new AggregateCatalog();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Log.Debug($"Add Catalog {assembly.GetName().Name}");
                this.Catalog.Catalogs.Add(new AssemblyCatalog(assembly));
            }

            this.Scopes = new Dictionary<TContext, ContextContainer<TContext>>();
        }

        public ContextContainer<TContext> Default { get; protected set; }

        protected AggregateCatalog Catalog { get; }

        protected Dictionary<TContext, ContextContainer<TContext>> Scopes { get; }

        public virtual ContextContainer<TContext> GetContainer([NotNull] TContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!this.Scopes.ContainsKey(context))
            {
                this.Scopes[context] = this.CreateContainer(context);
            }

            return this.Scopes[context];
        }

        protected virtual ContextContainer<TContext> CreateContainer([NotNull] TContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            Log.Debug($"Create Context {context} Container");

            var container = new CompositionContainer(
                this.Catalog,
                CompositionOptions.IsThreadSafe |
                CompositionOptions.DisableSilentRejection);

            container.ComposeExportedValue<TContext>(context);

            return new ContextContainer<TContext>(context, container);
        }
    }
}
// <copyright file="EnsageContainerRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Providers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reflection;
    using System.Security;

    using Ensage;

    using log4net;

    using PlaySharp.SDK.Composition;
    using PlaySharp.SDK.Composition.EntryPoints;
    using PlaySharp.SDK.Composition.Metadata;
    using PlaySharp.SDK.Composition.Repositories;
    using PlaySharp.Toolkit.Helper;
    using PlaySharp.Toolkit.Helper.Annotations;
    using PlaySharp.Toolkit.Logging;

    [PublicAPI]
    [SecuritySafeCritical]
    public sealed class EnsageContainerRepository : ContainerRepository<EnsageServiceContext>,
                                                    IContainerRepository,
                                                    IControllable
    {
        private static readonly ILog Log = AssemblyLogs.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly object SyncRoot = new object();

        private static volatile EnsageContainerRepository instance = null;

        private EnsageContainerRepository()
        {
            this.Default = this.CreateContainer(new EnsageServiceContext(ObjectManager.LocalHero));
        }

        public static EnsageContainerRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new EnsageContainerRepository();
                        }
                    }
                }

                return instance;
            }
        }

        [ImportMany(typeof(IAssembly))]
        public IEnumerable<Lazy<IAssembly, IAssemblyMetadata>> Assemblies { get; private set; }

        public bool IsActive { get; private set; }

        [ImportMany(typeof(ILibrary))]
        public IEnumerable<Lazy<ILibrary, ILibraryMetadata>> Libraries { get; private set; }

        public void Activate()
        {
            this.Default.Container.ComposeParts(this);

            // get Context Hero name
            var name = this.Default.Context.Owner.Name;

            foreach (var library in this.Libraries)
            {
                try
                {
                    Log.Debug($"Activate {library.Metadata.Name} - {library.Metadata.Version}");
                    library.Value.Activate();
                }
                catch (Exception e)
                {
                    Log.Warn(e);
                }
            }

            foreach (var assembly in this.Assemblies)
            {
                try
                {
                    if (assembly.Metadata.Units.Contains("*") || assembly.Metadata.Units.Contains(name))
                    {
                        Log.Debug($"Activate {assembly.Metadata.Name} - {assembly.Metadata.Version}");
                        assembly.Value.Activate();
                    }
                    else
                    {
                        Log.Debug($"Ignored {assembly.Metadata.Name} - {assembly.Metadata.Version}");
                    }
                }
                catch (Exception e)
                {
                    Log.Warn(e);
                }
            }
        }

        public void Deactivate()
        {
            foreach (var assembly in this.Assemblies)
            {
                try
                {
                    if (assembly.IsValueCreated && assembly.Value.IsActive)
                    {
                        Log.Debug($"Deactivate {assembly.Metadata.Name} - {assembly.Metadata.Version}");
                        assembly.Value.Deactivate();
                    }
                }
                catch (Exception e)
                {
                    Log.Warn(e);
                }
            }

            foreach (var library in this.Libraries)
            {
                try
                {
                    if (library.IsValueCreated && library.Value.IsActive)
                    {
                        Log.Debug($"Deactivate {library.Metadata.Name} - {library.Metadata.Version}");
                        library.Value.Deactivate();
                    }
                }
                catch (Exception e)
                {
                    Log.Warn(e);
                }
            }

            this.Default.Container.Dispose();
        }

        public ContextContainer<EnsageServiceContext> GetHeroContainer([NotNull] Hero hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException(nameof(hero));
            }

            return this.Scopes.FirstOrDefault(s => s.Key.Owner.Equals(hero)).Value;
        }
    }
}
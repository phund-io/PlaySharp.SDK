// <copyright file="EnsageContainerRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition
{
    using System;
    using System.Linq;
    using System.Security;

    using Ensage;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public sealed class EnsageContainerRepository : ContainerRepository<EnsageServiceContext>
    {
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
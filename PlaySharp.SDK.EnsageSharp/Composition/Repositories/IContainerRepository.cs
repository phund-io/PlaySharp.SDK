// <copyright file="IContainerRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.Repositories
{
    using Ensage;

    using PlaySharp.Toolkit.Helper.Annotations;

    public interface IContainerRepository : IContainerRepository<EnsageServiceContext>
    {
        ContextContainer<EnsageServiceContext> GetHeroContainer([NotNull] Hero hero);
    }
}
// <copyright file="IContainerRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.Repositories
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IContainerRepository<TContext>
        where TContext : class, IServiceContext
    {
        ContextContainer<TContext> Default { get; }

        ContextContainer<TContext> GetContainer([NotNull] TContext context);
    }
}
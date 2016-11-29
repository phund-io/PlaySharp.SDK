// <copyright file="ITargetSelectorRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.Repositories
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface ITargetSelectorRepository<TService> : IServiceRepository<TService>
        where TService : class
    {
    }
}
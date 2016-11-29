// <copyright file="IPredictionRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.Repositories
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IPredictionRepository<TService> : IServiceRepository<TService>
        where TService : class
    {
    }
}
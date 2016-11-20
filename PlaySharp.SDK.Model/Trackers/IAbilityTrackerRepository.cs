// <copyright file="IAbilityTrackerRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Trackers
{
    using System.Security;

    using PlaySharp.SDK.Composition;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IAbilityTrackerRepository<TService> : IServiceRepository<TService>
        where TService : class
    {
    }
}
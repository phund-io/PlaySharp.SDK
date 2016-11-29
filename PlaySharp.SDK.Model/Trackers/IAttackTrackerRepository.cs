// <copyright file="IAttackTrackerRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Trackers
{
    using System.Security;

    using PlaySharp.SDK.Composition.Repositories;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IAttackTrackerRepository<TTracker> : IServiceRepository<TTracker>
        where TTracker : class
    {
    }
}
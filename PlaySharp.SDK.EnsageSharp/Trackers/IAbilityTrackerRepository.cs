// <copyright file="IAbilityTrackerRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Trackers
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IAbilityTrackerRepository : IAbilityTrackerRepository<IAbilityTracker>
    {
    }
}
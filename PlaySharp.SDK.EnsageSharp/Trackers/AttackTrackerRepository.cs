// <copyright file="AttackTrackerRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Trackers
{
    using System.ComponentModel.Composition;
    using System.Security;

    using PlaySharp.SDK.Composition;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    [Export(typeof(IAttackTrackerRepository))]
    [Export(typeof(IServiceRepository<IAttackTrackerRepository>))]
    public class AttackTrackerRepository : ServiceRepositoryBase<IAttackTrackerRepository>
    {
    }
}
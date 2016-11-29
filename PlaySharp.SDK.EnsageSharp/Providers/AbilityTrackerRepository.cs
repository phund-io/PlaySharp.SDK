// <copyright file="AbilityTrackerRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Providers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Security;

    using PlaySharp.SDK.Composition.Metadata;
    using PlaySharp.SDK.Composition.Repositories;
    using PlaySharp.SDK.Trackers;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    [Export(typeof(IAbilityTrackerRepository))]
    public class AbilityTrackerRepository : ServiceRepository<IAbilityTracker, IAbilityTrackerMetadata>,
                                            IAbilityTrackerRepository,
                                            IPartImportsSatisfiedNotification
    {
        [ImportMany(typeof(IAbilityTracker))]
        protected IEnumerable<Lazy<IAbilityTracker, IAbilityTrackerMetadata>> Imports { get; set; }

        public void OnImportsSatisfied()
        {
            this.Update(this.Imports);
        }
    }
}
// <copyright file="DefaultAbilityTracker.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Trackers
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel.Composition;
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    [Export(typeof(IAbilityTracker))]
    public class DefaultAbilityTracker : IAbilityTracker
    {
        protected readonly List<IAbilityObject<string, IAbilityObject>> Objects =
            new List<IAbilityObject<string, IAbilityObject>>();

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public IReadOnlyList<IAbilityObject<string, IAbilityObject>> Attacks
        {
            get
            {
                return this.Objects.AsReadOnly();
            }
        }

        // TODO: track abilities
    }
}
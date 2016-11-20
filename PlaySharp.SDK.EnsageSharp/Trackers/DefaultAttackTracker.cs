// <copyright file="DefaultAttackTracker.cs" company="PlaySharp">
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
    [Export(typeof(IAttackTracker))]
    public class DefaultAttackTracker : IAttackTracker
    {
        protected readonly List<IAttackObject<string, IAttackObject>> Objects =
            new List<IAttackObject<string, IAttackObject>>();

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public IReadOnlyList<IAttackObject<string, IAttackObject>> Attacks
        {
            get
            {
                return this.Objects.AsReadOnly();
            }
        }

        // TODO: track attacks
    }
}
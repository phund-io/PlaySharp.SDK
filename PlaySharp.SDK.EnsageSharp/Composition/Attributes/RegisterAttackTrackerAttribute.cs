// <copyright file="RegisterAttackTrackerAttribute.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.Attributes
{
    using System;
    using System.ComponentModel.Composition;
    using System.Security;

    using PlaySharp.SDK.Composition.Metadata;
    using PlaySharp.SDK.Trackers;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [MetadataAttribute]
    [SecuritySafeCritical]
    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterAttackTrackerAttribute : ObjectProviderAttribute, ITrackerMetadata
    {
        public RegisterAttackTrackerAttribute(string name, string version = null, string description = null)
            : base(typeof(IAttackTracker), name, version, description)
        {
        }
    }
}
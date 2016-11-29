// <copyright file="RegisterAssemblyAttribute.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.Attributes
{
    using System;
    using System.ComponentModel.Composition;
    using System.Security;

    using PlaySharp.SDK.Composition.EntryPoints;
    using PlaySharp.SDK.Composition.Metadata;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [MetadataAttribute]
    [SecuritySafeCritical]
    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterAssemblyAttribute : ObjectProviderAttribute, IAssemblyMetadata
    {
        public RegisterAssemblyAttribute(
            string name,
            string[] units = null,
            string version = null,
            string description = null)
            : base(typeof(IAssembly), name, version, description)
        {
            this.Units = units ?? new[] { "*" };
        }

        public string[] Units { get; }
    }
}
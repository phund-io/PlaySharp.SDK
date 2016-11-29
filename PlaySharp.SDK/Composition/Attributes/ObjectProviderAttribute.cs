// <copyright file="ObjectProviderAttribute.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.Attributes
{
    using System;
    using System.ComponentModel.Composition;

    using PlaySharp.SDK.Composition.Metadata;

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class ObjectProviderAttribute : ExportAttribute, IServiceMetadata
    {
        protected ObjectProviderAttribute(Type contract, string name, string version = null, string description = null)
            : base(contract)
        {
            this.Name = name;
            this.Version = version;
            this.Description = description;
        }

        public string Description { get; }

        public string Name { get; }

        public string Version { get; }
    }
}
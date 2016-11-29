// <copyright file="RegisterRendererAttribute.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.Attributes
{
    using System;
    using System.ComponentModel.Composition;
    using System.Security;

    using PlaySharp.SDK.Composition.Metadata;
    using PlaySharp.SDK.Rendering;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [MetadataAttribute]
    [SecuritySafeCritical]
    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterRendererAttribute : ObjectProviderAttribute, IRendererMetadata
    {
        public RegisterRendererAttribute(string name, RenderMode mode, string version = null, string description = null)
            : base(typeof(IRenderer), name, version, description)
        {
            this.Mode = mode;
        }

        public RenderMode Mode { get; }
    }
}
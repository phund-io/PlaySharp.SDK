// <copyright file="IServiceMetadata.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.Metadata
{
    using System.ComponentModel;
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IServiceMetadata
    {
        [DefaultValue("Orbwalker")]
        string Description { get; }

        [DefaultValue("Default")]
        string Name { get; }

        [DefaultValue("1.0.0.0")]
        string Version { get; }
    }
}
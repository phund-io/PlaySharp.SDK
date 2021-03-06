// <copyright file="IConfigMetadata.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.Metadata
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IConfigMetadata : IServiceMetadata
    {
    }
}
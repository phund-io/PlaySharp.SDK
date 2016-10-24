// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IImageLoader.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.ImageLoader
{
    using System.Security;

    using JetBrains.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IImageLoader
    {
        [SecuritySafeCritical]
        byte[] GetImage(ImageType type, [NotNull] string resource);
    }
}
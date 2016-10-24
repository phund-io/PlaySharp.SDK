// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IImageCache.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.ImageLoader
{
    using System.Security;

    using JetBrains.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IImageCache
    {
        string CacheDirectory { [NotNull] get; [NotNull] set; }

        [SecuritySafeCritical]
        byte[] GetData([NotNull] string url, [CanBeNull] string key = null);
    }
}
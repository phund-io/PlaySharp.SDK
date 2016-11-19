// <copyright file="IImageCache.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.ImageLoader
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IImageCache
    {
        string CacheDirectory { [NotNull] get; [NotNull] set; }

        [SecuritySafeCritical]
        byte[] GetData([NotNull] string url, [CanBeNull] string key = null);
    }
}
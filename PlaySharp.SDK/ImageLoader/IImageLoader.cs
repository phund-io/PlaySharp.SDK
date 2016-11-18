// <copyright file="IImageLoader.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.ImageLoader
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IImageLoader
    {
        [SecuritySafeCritical]
        byte[] GetImage(ImageType type, [NotNull] string resource);
    }
}
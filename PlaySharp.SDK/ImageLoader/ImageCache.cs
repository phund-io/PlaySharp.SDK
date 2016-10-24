// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageCache.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.ImageLoader
{
    using System;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Reflection;
    using System.Security;

    using JetBrains.Annotations;

    using log4net;

    using PlaySharp.Toolkit.Extensions;
    using PlaySharp.Toolkit.Helper;
    using PlaySharp.Toolkit.Logging;

    [PublicAPI]
    [SecuritySafeCritical]
    [Export(typeof(IImageCache))]
    public class ImageCache : IImageCache
    {
        private static readonly ILog Log = Logs.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        [SecuritySafeCritical]
        public ImageCache()
        {
            this.CacheDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cache", "images");
        }

        public string CacheDirectory { get; set; }

        [SecuritySafeCritical]
        public byte[] GetData(string url, string key = null)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            var ext = Path.GetExtension(url);
            if (ext.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(url), $"No Image Extension found '{ext}'");
            }

            var hash = key ?? HashFactory.MD5.String(url);
            var file = Path.Combine(this.CacheDirectory, $"{hash}{ext}");

            if (File.Exists(file) || this.Download(url, file))
            {
                Log.Debug($"Load File {url}");
                return File.ReadAllBytes(file);
            }

            return new byte[0];
        }

        [SecuritySafeCritical]
        private bool Download([NotNull] string url, [NotNull] string file)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            try
            {
                var directory = Path.GetDirectoryName(file);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var client = new PlaySharpWebClient())
                {
                    Log.Debug($"Download File {url}");
                    client.DownloadFile(url, file);
                }

                return true;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

            return false;
        }
    }
}
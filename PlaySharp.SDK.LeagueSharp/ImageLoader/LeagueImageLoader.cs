// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LeagueImageLoader.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.ImageLoader
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reflection;
    using System.Security;

    using JetBrains.Annotations;

    using log4net;

    using PlaySharp.Toolkit.Extensions;
    using PlaySharp.Toolkit.Helper;
    using PlaySharp.Toolkit.Logging;

    [PublicAPI]
    [SecuritySafeCritical]
    [Export(typeof(IImageLoader))]
    public class LeagueImageLoader : IImageLoader
    {
        private static readonly ILog Log = Logs.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public LeagueImageLoader()
        {
            this.Version = this.GetLatestGameVersion();
        }

        [Import(typeof(IImageCache))]
        protected Lazy<IImageCache> ImageCache { get; set; }

        private string CdnEndpoint { get; } = "http://ddragon.leagueoflegends.com/cdn";

        private string Version { get; set; }

        private string VersionEndpoint { get; } = "https://ddragon.leagueoflegends.com/api/versions.json";

        [SecuritySafeCritical]
        public byte[] GetImage(ImageType type, string resource)
        {
            if (!Enum.IsDefined(typeof(ImageType), type))
            {
                throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(ImageType));
            }

            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            var key = $"{type.ToName()}/{resource}.png";
            var url = $"{this.CdnEndpoint}/{this.Version}/img/{key}";

            // get image from cache layer
            // index by type+resource to prevent re-download on patch
            return this.ImageCache.Value.GetData(url, key);
        }

        [SecuritySafeCritical]
        private string GetLatestGameVersion()
        {
            try
            {
                using (var client = new PlaySharpWebClient())
                {
                    var content = client.DownloadString(this.VersionEndpoint);
                    var json = JsonFactory.FromString<string[]>(content);
                    var latest = json.First();

                    Log.Debug($"Resolved ddragon Version {latest}");

                    return latest;
                }
            }
            catch (Exception e)
            {
                Log.Warn(e.Message);
            }

            return string.Empty;
        }
    }
}
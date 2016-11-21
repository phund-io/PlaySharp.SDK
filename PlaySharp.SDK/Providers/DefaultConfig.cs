// <copyright file="DefaultConfig.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Providers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Security;

    using log4net;

    using PlaySharp.SDK.Composition.Attributes;
    using PlaySharp.SDK.Configuration;
    using PlaySharp.Toolkit.Helper;
    using PlaySharp.Toolkit.Helper.Annotations;
    using PlaySharp.Toolkit.Logging;

    [PublicAPI]
    [RegisterConfig("SDK")]
    [SecuritySafeCritical]
    public class DefaultConfig : IConfig, IDisposable
    {
        private static readonly ILog Log = AssemblyLogs.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private bool disposed;

        public DefaultConfig()
        {
            this.StoreFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "Assemblies", "sdk.json");
            this.Load();
        }

        public string StoreFile { [NotNull] get; [NotNull] set; }

        private Dictionary<string, object> Store { get; set; } = new Dictionary<string, object>();

        public object this[string key]
        {
            get
            {
                return this.Store[key];
            }

            set
            {
                this.Store[key] = value;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T GetValue<T>(string key) where T : class
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (!this.Store.ContainsKey(key))
            {
                throw new KeyNotFoundException(key);
            }

            return this.Store[key] as T;
        }

        public void Load()
        {
            try
            {
                if (File.Exists(this.StoreFile))
                {
                    this.Store = JsonFactory.FromFile<Dictionary<string, object>>(this.StoreFile);
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public void Save()
        {
            try
            {
                JsonFactory.ToFile(this.StoreFile, this.Store);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public void SetValue<T>(string key, T value) where T : class
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            this.Store[key] = value;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.Save();
            }

            this.disposed = true;
        }
    }
}
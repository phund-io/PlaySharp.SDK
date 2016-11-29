// <copyright file="DefaultConfig.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Providers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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

        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

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

        public void Bind(object target)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T GetValue<T>(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (!this.Store.ContainsKey(key))
            {
                throw new KeyNotFoundException(key);
            }

            return (T)this.Store[key];
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

        public void SetValue<T>(string key, T value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (this.Store.ContainsKey(key))
            {
                if (this.Store[key].Equals(value))
                {
                    return;
                }
            }

            this.OnPropertyChanging(key);
            this.Store[key] = value;
            this.OnPropertyChanged(key);
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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanging(string propertyName = null)
        {
            this.PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }
    }
}
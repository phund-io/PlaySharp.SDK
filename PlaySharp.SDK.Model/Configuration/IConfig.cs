// <copyright file="IConfig.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Configuration
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IConfig
    {
        object this[string key] { get; set; }

        T GetValue<T>(string key) where T : class;

        void Load();

        void Save();

        void SetValue<T>(string key, T value) where T : class;
    }
}
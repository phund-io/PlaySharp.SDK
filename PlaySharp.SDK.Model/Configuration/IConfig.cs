// <copyright file="IConfig.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Configuration
{
    using System.ComponentModel;
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IConfig : INotifyPropertyChanging, INotifyPropertyChanged
    {
        object this[string key] { get; set; }

        void Bind(object target);

        T GetValue<T>(string key);

        void Load();

        void Save();

        void SetValue<T>(string key, T value);
    }
}
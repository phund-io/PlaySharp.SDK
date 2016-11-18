// <copyright file="IConfigurationRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IConfigurationRepository
    {
        object this[string key] { get; set; }

        T GetValue<T>(string key);

        void SetValue<T>(string key, T value);
    }
}
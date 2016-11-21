// <copyright file="IServiceRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition
{
    using System;
    using System.Security;

    using PlaySharp.SDK.Trackers;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IServiceRepository<TService> : INotifyCollection<TService>
        where TService : class
    {
        event EventHandler<ActiveServiceChangedEventArgs<TService>> ActiveChanged;

        TService ActiveService { get; set; }
    }
}
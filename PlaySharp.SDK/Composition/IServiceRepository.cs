// <copyright file="IServiceRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IServiceRepository<TService> : INotifyCollectionChanged
        where TService : class
    {
        event EventHandler<ActiveServiceChangedEventArgs<TService>> ActiveChanged;

        TService ActiveService { get; set; }

        IReadOnlyList<TService> Services { get; }

        void Register(TService service);

        void Unregister(TService service);
    }
}
// <copyright file="ActiveServiceChangedEventArgs.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition
{
    using System;
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public class ActiveServiceChangedEventArgs<TService> : EventArgs
    {
        public ActiveServiceChangedEventArgs([NotNull] TService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            this.Service = service;
        }

        public TService Service { get; }
    }
}
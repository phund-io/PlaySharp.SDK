// <copyright file="IEnsageServiceContext.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition
{
    using System.Security;

    using Ensage;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IEnsageServiceContext : IServiceContext
    {
        Hero Owner { get; }
    }
}
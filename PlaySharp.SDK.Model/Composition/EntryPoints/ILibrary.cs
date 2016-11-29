// <copyright file="ILibrary.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.EntryPoints
{
    using System.Security;

    using PlaySharp.Toolkit.Helper;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface ILibrary : IControllable
    {
    }
}
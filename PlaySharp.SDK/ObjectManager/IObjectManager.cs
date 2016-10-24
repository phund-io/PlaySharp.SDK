// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IObjectManager.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.ObjectManager
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;

    using JetBrains.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IObjectManager<in TBaseType, in TIndexType, out THeroType>
        where THeroType : class, new()
        where TBaseType : class, new()
    {
        THeroType Hero { [NotNull] [SecuritySafeCritical] get; }

        [NotNull]
        [ItemNotNull]
        [SecuritySafeCritical]
        IEnumerable<TUnit> Get<TUnit>() where TUnit : TBaseType, new();

        [CanBeNull]
        [SecuritySafeCritical]
        TUnit Get<TUnit>(TIndexType id) where TUnit : TBaseType, new();

        [NotNull]
        [ItemNotNull]
        [SecuritySafeCritical]
        IEnumerable<TUnit> GetFast<TUnit>() where TUnit : TBaseType, new();

        [NotNull]
        [ItemNotNull]
        [SecuritySafeCritical]
        ParallelQuery<TUnit> GetParallel<TUnit>() where TUnit : TBaseType, new();
    }
}
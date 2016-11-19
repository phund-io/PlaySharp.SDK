// <copyright file="IObjectManagerProvider.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Objects
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IObjectManagerProvider<in TBaseType, in TIndexType, out THeroType>
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
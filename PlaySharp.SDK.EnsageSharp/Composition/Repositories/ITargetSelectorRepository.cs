// <copyright file="ITargetSelectorRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.Repositories
{
    using System;

    using PlaySharp.SDK.Composition.Metadata;
    using PlaySharp.SDK.Targetselection;

    public interface ITargetSelectorRepository :
        ITargetSelectorRepository<Lazy<ITargetSelector, ITargetSelectorMetadata>>
    {
    }
}
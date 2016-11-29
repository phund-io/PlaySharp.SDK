// <copyright file="IOrbwalkerRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.Repositories
{
    using System;

    using PlaySharp.SDK.Composition.Metadata;
    using PlaySharp.SDK.Orbwalking;

    public interface IOrbwalkerRepository : IOrbwalkerRepository<Lazy<IOrbwalker, IOrbwalkerMetadata>>
    {
    }
}
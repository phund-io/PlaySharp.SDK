// <copyright file="IPredictionRepository.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.Repositories
{
    using System;

    using PlaySharp.SDK.Composition.Metadata;
    using PlaySharp.SDK.Prediction;

    public interface IPredictionRepository : IPredictionRepository<Lazy<IPrediction, IPredictionMetadata>>
    {
    }
}
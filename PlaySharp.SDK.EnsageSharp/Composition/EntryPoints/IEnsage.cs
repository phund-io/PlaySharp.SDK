// <copyright file="IEnsage.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.EntryPoints
{
    using System;
    using System.Collections.Generic;

    using PlaySharp.SDK.Composition.Metadata;
    using PlaySharp.SDK.Composition.Repositories;
    using PlaySharp.SDK.Configuration;
    using PlaySharp.SDK.Menu;
    using PlaySharp.SDK.Orbwalking;
    using PlaySharp.SDK.Prediction;
    using PlaySharp.SDK.Rendering;
    using PlaySharp.SDK.Targetselection;
    using PlaySharp.SDK.Trackers;
    using PlaySharp.Toolkit.EventAggregator;

    public interface IEnsage
    {
        IAbilityTracker AbilityTracker { get; }

        IAbilityTrackerRepository AbilityTrackerRepository { get; }

        IEnumerable<Lazy<IAssembly, IAssemblyMetadata>> Assemblies { get; }

        IAttackTracker AttackTracker { get; }

        IAttackTrackerRepository AttackTrackerRepository { get; }

        IConfig Config { get; }

        IContainerRepository ContainerRepository { get; }

        IEnsageServiceContext Context { get; }

        IEventAggregator EventAggregator { get; }

        IEnumerable<Lazy<ILibrary, ILibraryMetadata>> Libraries { get; }

        IMenu Menu { get; }

        IOrbwalker Orbwalker { get; }

        IOrbwalkerRepository OrbwalkerRepository { get; }

        IPrediction Prediction { get; }

        IPredictionRepository PredictionRepository { get; }

        IRenderer Renderer { get; }

        ITargetSelector TargetSelector { get; }

        ITargetSelectorRepository TargetSelectorRepository { get; }
    }
}
// <copyright file="EnsageBootstrapper.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reflection;
    using System.Security;

    using Ensage;

    using log4net;

    using PlaySharp.SDK.Composition.EntryPoints;
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
    using PlaySharp.Toolkit.Helper.Annotations;
    using PlaySharp.Toolkit.Logging;

    using RenderMode = Ensage.RenderMode;

    [PublicAPI]
    [SecuritySafeCritical]
    [Export(typeof(IEnsage))]
    [Export(typeof(IBootstrapper))]
    public class EnsageBootstrapper : IBootstrapper, IEnsage
    {
        private static readonly ILog Log = AssemblyLogs.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IAbilityTracker AbilityTracker { get; protected set; }

        [Import(typeof(IAbilityTrackerRepository))]
        public IAbilityTrackerRepository AbilityTrackerRepository { get; protected set; }

        [ImportMany(typeof(IAssembly))]
        public IEnumerable<Lazy<IAssembly, IAssemblyMetadata>> Assemblies { get; protected set; }

        public IAttackTracker AttackTracker { get; protected set; }

        [Import(typeof(IAttackTrackerRepository))]
        public IAttackTrackerRepository AttackTrackerRepository { get; protected set; }

        [Import(typeof(IConfig))]
        public IConfig Config { get; protected set; }

        [Import(typeof(IContainerRepository))]
        public IContainerRepository ContainerRepository { get; protected set; }

        [Import(typeof(IEnsageServiceContext))]
        public IEnsageServiceContext Context { get; protected set; }

        [Import(typeof(IEventAggregator))]
        public IEventAggregator EventAggregator { get; protected set; }

        public bool IsActive { get; private set; }

        [ImportMany(typeof(ILibrary))]
        public IEnumerable<Lazy<ILibrary, ILibraryMetadata>> Libraries { get; protected set; }

        public IMenu Menu { get; protected set; }

        public IOrbwalker Orbwalker { get; protected set; }

        [Import(typeof(IOrbwalkerRepository))]
        public IOrbwalkerRepository OrbwalkerRepository { get; protected set; }

        public IPrediction Prediction { get; protected set; }

        [Import(typeof(IPredictionRepository))]
        public IPredictionRepository PredictionRepository { get; protected set; }

        public IRenderer Renderer { get; protected set; }

        public ITargetSelector TargetSelector { get; protected set; }

        [Import(typeof(ITargetSelectorRepository))]
        public ITargetSelectorRepository TargetSelectorRepository { get; protected set; }

        [ImportMany(typeof(IRenderer))]
        protected IEnumerable<Lazy<IRenderer, IRendererMetadata>> Renderers { get; set; }

        public void Activate()
        {
            if (this.IsActive)
            {
                return;
            }

            this.SetupServices();

            this.IsActive = true;
        }

        public void Deactivate()
        {
            if (!this.IsActive)
            {
                return;
            }

            this.IsActive = false;
        }

        private void SetupRender()
        {
            try
            {
                switch (Drawing.RenderMode)
                {
                    case RenderMode.Dx9:
                        this.Renderer =
                            this.Renderers
                                .First(r => r.Metadata.Mode == Rendering.RenderMode.DirectX9)
                                .Value;
                        break;

                    case RenderMode.Dx11:
                        this.Renderer =
                            this.Renderers
                                .First(r => r.Metadata.Mode == Rendering.RenderMode.DirectX11)
                                .Value;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(Drawing.RenderMode),
                            $"RenderMode: {Drawing.RenderMode} not supported.");
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private void SetupServices()
        {
            try
            {
                this.SetupRender();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}
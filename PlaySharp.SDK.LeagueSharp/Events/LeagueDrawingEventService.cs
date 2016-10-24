// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LeagueDrawingEventService.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.Events
{
    using System;
    using System.ComponentModel.Composition;
    using System.Reflection;
    using System.Security;

    using JetBrains.Annotations;

    using LeagueSharp;

    using log4net;

    using PlaySharp.Toolkit.AppDomain.Service;
    using PlaySharp.Toolkit.EventAggregator;
    using PlaySharp.Toolkit.Logging;

    [PublicAPI]
    [SecuritySafeCritical]
    [Export(typeof(IEventService))]
    public class LeagueDrawingEventService : IEventService
    {
        private static readonly ILog Log = Logs.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public bool IsActive { get; private set; }

        [Import(typeof(IEventAggregator))]
        protected Lazy<IEventAggregator> EventAggregator { get; set; }

        [SecuritySafeCritical]
        public void Activate()
        {
            if (this.EventAggregator?.Value == null)
            {
                Log.Warn($"{nameof(IEventAggregator)} is not present");
                return;
            }

            if (this.IsActive)
            {
                Log.Warn($"{nameof(LeagueDrawingEventService)} already Active");
                return;
            }

            try
            {
                Drawing.OnDraw += this.OnDraw;
                Drawing.OnBeginScene += this.OnBeginScene;
                Drawing.OnEndScene += this.OnEndScene;
                Drawing.OnPreReset += this.OnPreReset;
                Drawing.OnPostReset += this.OnPostReset;
                Drawing.OnPresent += this.OnPresent;
                this.IsActive = true;
            }
            catch (Exception e)
            {
                Log.Error(e);
                this.IsActive = false;
            }
        }

        [SecuritySafeCritical]
        public void Deactivate()
        {
            if (!this.IsActive)
            {
                Log.Warn($"{nameof(LeagueDrawingEventService)} is not Active");
                return;
            }

            try
            {
                Drawing.OnDraw -= this.OnDraw;
                Drawing.OnBeginScene -= this.OnBeginScene;
                Drawing.OnEndScene -= this.OnEndScene;
                Drawing.OnPreReset -= this.OnPreReset;
                Drawing.OnPostReset -= this.OnPostReset;
                Drawing.OnPresent -= this.OnPresent;
                this.IsActive = false;
            }
            catch (Exception e)
            {
                Log.Error(e);
                this.IsActive = false;
            }
        }

        private void OnBeginScene(EventArgs args)
        {
            this.EventAggregator.Value.PublishOnCurrentThread(new OnDXBeginScene());
        }

        private void OnDraw(EventArgs args)
        {
            this.EventAggregator.Value.PublishOnCurrentThread(new OnGameDraw());
        }

        private void OnEndScene(EventArgs args)
        {
            this.EventAggregator.Value.PublishOnCurrentThread(new OnDXEndScene());
        }

        private void OnPostReset(EventArgs args)
        {
            this.EventAggregator.Value.PublishOnCurrentThread(new OnDXPostReset());
        }

        private void OnPreReset(EventArgs args)
        {
            this.EventAggregator.Value.PublishOnCurrentThread(new OnDXPreReset());
        }

        private void OnPresent(EventArgs args)
        {
            this.EventAggregator.Value.PublishOnCurrentThread(new OnDXPresent());
        }
    }
}
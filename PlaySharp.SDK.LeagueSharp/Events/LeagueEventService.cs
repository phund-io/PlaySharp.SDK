// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LeagueEventService.cs" company="PlaySharp">
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
    public class LeagueGameEventService : IEventService
    {
        private static readonly ILog Log = AssemblyLogs.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
                Log.Warn($"{nameof(LeagueGameEventService)} already Active");
                return;
            }

            try
            {
                Game.OnStart += this.OnStart;
                Game.OnEnd += this.OnEnd;
                Game.OnUpdate += this.OnUpdate;
                Game.OnWndProc += this.OnWndProc;
                Game.OnChat += this.OnChat;

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
                Log.Warn($"{nameof(LeagueGameEventService)} is not Active");
                return;
            }

            try
            {
                Game.OnStart -= this.OnStart;
                Game.OnEnd -= this.OnEnd;
                Game.OnUpdate -= this.OnUpdate;
                Game.OnWndProc -= this.OnWndProc;
                Game.OnChat -= this.OnChat;

                this.IsActive = false;
            }
            catch (Exception e)
            {
                Log.Error(e);
                this.IsActive = false;
            }
        }

        private void OnChat(GameChatEventArgs args)
        {
            // TODO: sender is sometimes null? jodus pls
            var generic = new OnGameChat(args.Sender.Name, args.Message);

            this.EventAggregator.Value.PublishOnCurrentThread(args);
            this.EventAggregator.Value.PublishOnCurrentThread(generic);

            args.Process = args.Process && generic.Process;
        }

        private void OnEnd(GameEndEventArgs args)
        {
            this.EventAggregator.Value.PublishOnCurrentThread(args);
            this.EventAggregator.Value.PublishOnCurrentThread(new OnGameEnd((int)args.WinningTeam));
        }

        private void OnInput(GameInputEventArgs args)
        {
            var generic = new OnGameInput(args.Input, args.Process);

            this.EventAggregator.Value.PublishOnCurrentThread(args);
            this.EventAggregator.Value.PublishOnCurrentThread(generic);

            args.Process = args.Process && generic.Process;
        }

        private void OnNotify(GameNotifyEventArgs args)
        {
            var generic = new OnGameEvent(
                (int)args.EventId,
                args.EventId.ToString(),
                args.NetworkId,
                ObjectManager.GetUnitByNetworkId<GameObject>(args.NetworkId)?.Name);

            this.EventAggregator.Value.PublishOnCurrentThread(args);
            this.EventAggregator.Value.PublishOnCurrentThread(generic);
        }

        private void OnStart(EventArgs args)
        {
            this.EventAggregator.Value.PublishOnCurrentThread(new OnGameStart());
        }

        private void OnUpdate(EventArgs args)
        {
            this.EventAggregator.Value.PublishOnCurrentThread(new OnGameUpdate());
        }

        private void OnWndProc(WndEventArgs args)
        {
            var generic = new OnWndProc(args.Msg, args.LParam, args.WParam, args.Process);

            this.EventAggregator.Value.PublishOnCurrentThread(args);
            this.EventAggregator.Value.PublishOnCurrentThread(generic);

            args.Process = args.Process && generic.Process;
        }
    }
}
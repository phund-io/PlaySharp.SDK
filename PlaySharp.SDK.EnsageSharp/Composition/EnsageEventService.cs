// <copyright file="EnsageEventService.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition
{
    using System;
    using System.Reflection;

    using Ensage;

    using log4net;

    using PlaySharp.Toolkit.Extensions;
    using PlaySharp.Toolkit.Logging;

    public class EnsageEventService
    {
        private static readonly ILog Log = AssemblyLogs.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public EnsageEventService()
        {
            Game.OnUpdate += this.OnUpdate;
        }

        private GameState LastState { get; set; }

        private void OnUpdate(EventArgs args)
        {
            if (this.LastState == Game.GameState)
            {
                return;
            }

            Log.Debug($"Game State changed {this.LastState} -> {Game.GameState}");

            switch (Game.GameState)
            {
                // pre game
                case GameState.NotInGame:
                case GameState.Picking:
                case GameState.WaitingForLoaders:
                case GameState.Prestart:
                case GameState.Started:
                    break;

                // ingame
                case GameState.Loaded:

                    // double check if Hero obj is loaded
                    if (ObjectManager.LocalHero.Name.IsNullOrEmpty())
                    {
                        return;
                    }

                    this.RaiseStartup();
                    break;

                // post game
                case GameState.Scoreboard:
                case GameState.LeftTheGame:
                    this.RaiseShutdown();
                    break;
            }

            this.LastState = Game.GameState;
        }

        private void RaiseShutdown()
        {
        }

        private void RaiseStartup()
        {
        }
    }
}
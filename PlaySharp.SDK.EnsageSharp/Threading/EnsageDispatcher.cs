// <copyright file="EnsageDispatcher.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Threading
{
    using System;
    using System.Threading;

    using Ensage;

    public static class EnsageDispatcher
    {
        static EnsageDispatcher()
        {
            Game.OnUpdate += UpdateDispatcher;
            Game.OnIngameUpdate += IngameUpdateDispatcher;
        }

        public static event GameIngameUpdate OnIngameUpdate;

        public static event GameUpdate OnUpdate;

        /// <summary>
        ///     Schedules <paramref name="action" /> to be executed on next Update
        /// </summary>
        /// <param name="action"></param>
        public static void BeginInvoke(Action action)
        {
            EnsageSynchronizationContext.Instance.Post(state => action(), null);
        }

        public static void InvokeEvent(Action action)
        {
            var gameContext = EnsageSynchronizationContext.Instance;
            var context = SynchronizationContext.Current;

            try
            {
                SynchronizationContext.SetSynchronizationContext(gameContext);
                action();
                gameContext.RunOnCurrentThread();
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(context);
            }
        }

        private static void IngameUpdateDispatcher(EventArgs args)
        {
            InvokeEvent(() => OnIngameUpdate?.Invoke(EventArgs.Empty));
        }

        private static void UpdateDispatcher(EventArgs args)
        {
            InvokeEvent(() => OnUpdate?.Invoke(EventArgs.Empty));
        }
    }
}
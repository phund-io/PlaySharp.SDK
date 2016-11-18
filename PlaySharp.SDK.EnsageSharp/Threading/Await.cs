// <copyright file="Await.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Threading
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Ensage;

    using PlaySharp.Toolkit.Helper.Annotations;

    /// <summary>
    ///     Await Helpers.
    /// </summary>
    public class Await
    {
        private static readonly SynchronizedCollection<string> Running = new SynchronizedCollection<string>();

        public static async void Block([NotNull] string key, [NotNull] Func<Task> taskFactory)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (taskFactory == null)
            {
                throw new ArgumentNullException(nameof(taskFactory));
            }

            if (Running.Contains(key))
            {
                // block if running
                return;
            }

            Running.Add(key);

            try
            {
                await taskFactory();
            }
            finally
            {
                Running.Remove(key);
            }
        }

        public static async Task<int> Delay(int time, [CanBeNull] CancellationToken token = default(CancellationToken))
        {
            var waitTime = Math.Max((int)Game.Ping, time);
            await Task.Delay(waitTime, token);
            return waitTime;
        }
    }
}
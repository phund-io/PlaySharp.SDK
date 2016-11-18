// <copyright file="GameSynchronizationContext.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Threading
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;

    public class GameSynchronizationContext : SynchronizationContext
    {
        private static readonly object SyncRoot = new object();

        private static GameSynchronizationContext instance;

        private readonly ConcurrentQueue<KeyValuePair<SendOrPostCallback, object>> queue =
            new ConcurrentQueue<KeyValuePair<SendOrPostCallback, object>>();

        public static GameSynchronizationContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new GameSynchronizationContext();
                        }
                    }
                }

                return instance;
            }
        }

        public override SynchronizationContext CreateCopy()
        {
            return new GameSynchronizationContext();
        }

        public override void Post(SendOrPostCallback d, object state)
        {
            this.queue.Enqueue(new KeyValuePair<SendOrPostCallback, object>(d, state));
        }

        internal void RunOnCurrentThread()
        {
            KeyValuePair<SendOrPostCallback, object> workItem;

            while (!this.queue.IsEmpty && this.queue.TryDequeue(out workItem))
            {
                workItem.Key(workItem.Value);
            }
        }
    }
}
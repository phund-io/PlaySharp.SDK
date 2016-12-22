// <copyright file="EntryPoint.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.EntryPoints
{
    using System;
    using System.Reflection;

    using log4net;

    using PlaySharp.Toolkit.Logging;

    public abstract class EntryPoint
    {
        private static readonly ILog Log = AssemblyLogs.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public bool IsActive { get; private set; }

        public bool IsInitialized { get; private set; }

        protected object SyncRoot { get; } = new object();

        public void Activate()
        {
            if (this.IsActive)
            {
                return;
            }

            try
            {
                if (!this.IsInitialized)
                {
                    lock (this.SyncRoot)
                    {
                        if (!this.IsInitialized)
                        {
                            this.OnInitialize();
                            this.IsInitialized = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Warn(e);
            }

            try
            {
                this.OnActivate();
                this.IsActive = true;
            }
            catch (Exception e)
            {
                Log.Warn(e);
            }
        }

        public void Deactivate()
        {
            if (!this.IsActive)
            {
                return;
            }

            try
            {
                this.OnDeactivate();
            }
            catch (Exception e)
            {
                Log.Warn(e);
            }
            finally
            {
                this.IsActive = false;
            }
        }

        protected virtual void OnActivate()
        {
        }

        protected virtual void OnDeactivate()
        {
        }

        protected virtual void OnInitialize()
        {
        }
    }
}
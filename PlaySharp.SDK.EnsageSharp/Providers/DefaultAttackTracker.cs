// <copyright file="DefaultAttackTracker.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Providers
{
    using System.Security;

    using Ensage;

    using PlaySharp.SDK.Composition.Attributes;
    using PlaySharp.SDK.Trackers;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    [RegisterAttackTracker("SDK", "0.0.0.1-alpha", "work in progress")]
    public class DefaultAttackTracker : NotifyCollection<IAttackObject>, IAttackTracker
    {
        public DefaultAttackTracker()
        {
            Entity.OnInt32PropertyChange += this.Int32PropertyChange;
        }

        private void Int32PropertyChange(Entity sender, Int32PropertyChangeEventArgs args)
        {
            if (args.PropertyName != "m_NetworkActivity")
            {
                return;
            }

            var unit = sender as Unit;
            if (unit == null)
            {
                return;
            }

            this.Add(new AttackObject(unit, (NetworkActivity)args.NewValue));
        }
    }
}
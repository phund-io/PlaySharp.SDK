// <copyright file="TargetAbility.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Casting
{
    using System;
    using System.Reflection;
    using System.Security;

    using Ensage;

    using log4net;

    using PlaySharp.SDK.Extensions;
    using PlaySharp.Toolkit.Helper.Annotations;
    using PlaySharp.Toolkit.Logging;

    using SharpDX;

    [PublicAPI]
    [SecuritySafeCritical]
    public class TargetAbility : TargetAbilityBase
    {
        private static readonly ILog Log = AssemblyLogs.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public TargetAbility([NotNull] Hero owner, [NotNull] Ability ability)
            : base(owner, ability)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            if (ability == null)
            {
                throw new ArgumentNullException(nameof(ability));
            }
        }

        public TargetAbility([NotNull] Hero owner, [NotNull] string ability)
            : base(owner, owner.GetAbility(ability))
        {
        }

        public override float GetDamage([NotNull] Unit target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            throw new NotImplementedException();
        }

        public override bool Use([NotNull] Unit target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            Log.Debug($"Use {this.Instance.Name} @ {target.Name}");
            this.Instance.UseAbility(target);
            return true;
        }

        public override bool Use(Vector3 position)
        {
            throw new NotSupportedException();
        }
    }
}
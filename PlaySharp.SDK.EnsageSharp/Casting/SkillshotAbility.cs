// <copyright file="SkillshotAbility.cs" company="PlaySharp">
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
    using PlaySharp.SDK.Prediction;
    using PlaySharp.Toolkit.Helper.Annotations;
    using PlaySharp.Toolkit.Logging;

    using SharpDX;

    [PublicAPI]
    [SecuritySafeCritical]
    public class SkillshotAbility : EnsageSkillshotAbilityBase
    {
        private static readonly ILog Log = AssemblyLogs.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public SkillshotAbility([NotNull] Hero owner, [NotNull] Ability ability)
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

        public SkillshotAbility([NotNull] Hero owner, [NotNull] string ability)
            : this(owner, owner.GetAbility(ability))
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

        public override IPredictionOutput GetPrediction([NotNull] Unit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }

            throw new NotImplementedException();
        }

        public override bool Use([NotNull] Unit target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            var output = this.GetPrediction(target);

            if (output.Cast)
            {
                this.Use(output.Position);
                return true;
            }

            return false;
        }

        public override bool Use(Vector3 position)
        {
            if (position.IsZero)
            {
                throw new ArgumentNullException(nameof(position));
            }

            Log.Debug($"UseAbility {this.Instance.Name} @ {position}");
            this.Instance.UseAbility(position);
            return true;
        }
    }
}
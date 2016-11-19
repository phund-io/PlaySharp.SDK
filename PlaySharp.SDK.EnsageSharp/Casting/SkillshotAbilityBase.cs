// <copyright file="SkillshotAbilityBase.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Casting
{
    using System.Security;

    using Ensage;

    using PlaySharp.SDK.Prediction;
    using PlaySharp.Toolkit.Helper.Annotations;

    using SharpDX;

    [PublicAPI]
    [SecuritySafeCritical]
    public abstract class SkillshotAbilityBase : ISkillshotAbility
    {
        protected SkillshotAbilityBase(Unit owner, Ability instance)
        {
            this.Instance = instance;
            this.Owner = owner;
        }

        public Ability Instance { get; }

        public Unit Owner { get; }

        public abstract float GetDamage(Unit target);

        public abstract IPredictionOutput GetPrediction(Unit unit);

        public abstract bool Use(Unit target);

        public abstract bool Use(Vector3 position);
    }
}
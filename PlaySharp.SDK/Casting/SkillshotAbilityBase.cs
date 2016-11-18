// <copyright file="SkillshotAbilityBase.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Casting
{
    using System.Security;

    using PlaySharp.SDK.Prediction;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public abstract class SkillshotAbilityBase<TAbility, THero, TUnit> : AbilityBase<TAbility, THero, TUnit>
    {
        protected SkillshotAbilityBase([NotNull] THero owner, [NotNull] TAbility ability)
            : base(owner, ability)
        {
        }

        [NotNull]
        public abstract IPredictionOutput GetPrediction([NotNull] TUnit unit);
    }
}
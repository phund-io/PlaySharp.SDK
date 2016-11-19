// <copyright file="ISkillshotAbility.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Casting
{
    using System.Security;

    using PlaySharp.SDK.Prediction;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface ISkillshotAbility<out TAbility, in TUnit, out TOwner> : IAbility<TAbility, TUnit, TOwner>
    {
        [NotNull]
        IPredictionOutput GetPrediction([NotNull] TUnit unit);
    }
}
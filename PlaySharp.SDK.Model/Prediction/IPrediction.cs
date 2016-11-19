// <copyright file="IPrediction.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Prediction
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IPrediction<in TAbility, in TUnit>
    {
        [NotNull]
        IPredictionOutput GetPrediction([NotNull] TAbility ability, [NotNull] TUnit target);
    }
}
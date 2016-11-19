// <copyright file="IPredictionOutput.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Prediction
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    using SharpDX;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IPredictionOutput
    {
        bool Cast { get; }

        Vector3 Position { get; }
    }
}
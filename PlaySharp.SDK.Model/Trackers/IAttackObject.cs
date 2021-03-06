// <copyright file="IAttackObject.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Trackers
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IAttackObject<out TObject> : ITrackableObject<TObject>
    {
        long Created { get; }
    }
}
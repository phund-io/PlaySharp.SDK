// <copyright file="ITrackableObject.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Trackers
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface ITrackableObject<out TId, out TObject>
    {
        TId Id { [NotNull] get; }

        TObject Instance { [NotNull] get; }
    }
}
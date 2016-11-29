// <copyright file="EnsageContainer.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition
{
    using System.Security;

    using PlaySharp.SDK.Providers;
    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public static class EnsageContainer
    {
        public static ContextContainer<EnsageServiceContext> Default
        {
            get
            {
                return EnsageContainerRepository.Instance.Default;
            }
        }
    }
}
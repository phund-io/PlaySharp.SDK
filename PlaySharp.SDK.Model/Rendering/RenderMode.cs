// <copyright file="RenderMode.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Rendering
{
    using System.Security;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public enum RenderMode
    {
        DirectX9 = 0,

        DirectX11 = 1,

        OpenGL = 2,

        Vulkan = 4,
    }
}
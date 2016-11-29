// <copyright file="IRenderer.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Rendering
{
    using System.Security;

    using PlaySharp.SDK.Events;
    using PlaySharp.Toolkit.Helper.Annotations;

    using SharpDX;

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IRenderer
    {
        event EventHandlerNoSender OnDraw;

        void DrawLine2D(Vector2 start, Vector2 end, Color color, float width = 1.0f);

        void DrawRect2D(Rectangle rect, Color color, bool outline = false);

        void DrawText2D(string text, Vector2 position, Color color);
    }
}
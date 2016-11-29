// <copyright file="RendererDirectX9.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Rendering
{
    using System;
    using System.Security;

    using Ensage;

    using PlaySharp.SDK.Composition.Attributes;
    using PlaySharp.SDK.Events;
    using PlaySharp.Toolkit.Helper.Annotations;

    using SharpDX;
    using SharpDX.Direct3D9;

    [PublicAPI]
    [SecuritySafeCritical]
    [RegisterRenderer("DirectX9", RenderMode.DirectX9)]
    public class RendererDirectX9 : IRenderer, IDisposable
    {
        private bool disposed;

        public RendererDirectX9()
        {
            this.Device = Drawing.Direct3DDevice9;

            Drawing.OnPreReset += this.Drawing_OnPreReset;
            Drawing.OnPostReset += this.Drawing_OnPostReset;

            this.Line = new Line(this.Device);
            this.Sprite = new Sprite(this.Device);

            this.Font = new Font(
                this.Device,
                new FontDescription
                {
                    FaceName = "Calibri",
                    Height = 13,
                    OutputPrecision = FontPrecision.Default,
                    Quality = FontQuality.Default
                });
        }

        public event EventHandlerNoSender OnDraw
        {
            add
            {
                Drawing.OnEndScene += new DrawingEndScene(value);
            }

            remove
            {
                Drawing.OnEndScene -= new DrawingEndScene(value);
            }
        }

        private Device Device { get; }

        private Font Font { get; }

        private Line Line { get; }

        private Sprite Sprite { get; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void DrawLine2D(Vector2 start, Vector2 end, Color color, float width = 1.0f)
        {
            this.Line.Width = width;
            this.Line.Begin();
            this.Line.Draw(new[] { start, end }, color);
            this.Line.End();
        }

        public void DrawRect2D(Rectangle rect, Color color, bool outline = false)
        {
            this.Line.Width = outline ? 1.0f : rect.Height;
            this.Line.Begin();
            if (outline)
            {
                this.Line.Draw(new[] { new Vector2(rect.X, rect.Y), new Vector2(rect.X + rect.Width, rect.Y) }, color);
                this.Line.Draw(
                        new[]
                        {
                            new Vector2(rect.X + rect.Width, rect.Y),
                            new Vector2(rect.X + rect.Width, rect.Y + rect.Height)
                        },
                        color);
                this.Line.Draw(
                        new[]
                        {
                            new Vector2(rect.X + rect.Width, rect.Y + rect.Height),
                            new Vector2(rect.X, rect.Y + rect.Height)
                        },
                        color);
                this.Line.Draw(new[] { new Vector2(rect.X, rect.Y + rect.Height), new Vector2(rect.X, rect.Y) }, color);
            }
            else
                this.Line.Draw(
                        new[]
                        {
                            new Vector2(rect.X, rect.Y + rect.Height / 2),
                            new Vector2(rect.X + rect.Width, rect.Y + rect.Height / 2)
                        },
                        color);
            this.Line.End();
        }

        public void DrawText2D(string text, Vector2 position, Color color)
        {
            this.Font.DrawText(null, text, (int)position.X, (int)position.Y, color);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                Drawing.OnPreReset -= this.Drawing_OnPreReset;
                Drawing.OnPostReset -= this.Drawing_OnPostReset;
            }

            // TODO: unmanaged
            this.disposed = true;
        }

        private void Drawing_OnPostReset(EventArgs args)
        {
            this.Line.OnResetDevice();
            this.Font.OnResetDevice();
            this.Sprite.OnResetDevice();
        }

        private void Drawing_OnPreReset(EventArgs args)
        {
            this.Font.OnLostDevice();
            this.Sprite.OnLostDevice();
            this.Line.OnLostDevice();
        }
    }
}
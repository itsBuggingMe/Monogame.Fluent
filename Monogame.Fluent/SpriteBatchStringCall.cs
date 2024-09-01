using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Runtime.CompilerServices;

namespace Monogame.Fluent;

public class SpriteBatchStringCall
{
    [ThreadStatic]
    private static FastStack<SpriteBatchStringCall> _storage = new(1);
    internal static SpriteBatchStringCall Request() => _storage.HasElements ? _storage.Pop() : new();

    internal SpriteBatch SpriteBatch;
    internal SpriteFont SpriteFont;
    internal string Text;
    internal Vector2 Position;
    internal Vector2 Scale = Vector2.One;
    internal Vector2 Origin;
    internal Color Color = Color.Black;
    internal float Rotation;
    internal SpriteEffects Effect = SpriteEffects.None;
    internal float Depth;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void Complete()
    {
        SpriteBatch.DrawString(SpriteFont, Text, Position, Color, Rotation, Origin, Scale, Effect, Depth);
        Scale = Vector2.One;
        Origin = default;
        Color = Color.Black;
        Rotation = 0;
        Effect = SpriteEffects.None;
        Depth = 0;
        _storage.Push(this);
    }
}

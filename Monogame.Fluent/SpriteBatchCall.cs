using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Runtime.CompilerServices;

namespace Monogame.Fluent;

//we can't use ref because the way its assigned does not allow it
public class SpriteBatchCall
{
    [ThreadStatic]
    //just in case they save the spritebatchcall and use another one meanwhile
    private static FastStack<SpriteBatchCall> _storage = new(1);
    internal static SpriteBatchCall Request()
    {
        var o = _storage.HasElements? _storage.Pop() : new();
        o.Position = default;
        o.Source = default;
        o.Scale = Vector2.One;
        o.Origin = default;
        o.Color = Color.White;
        o.Effect = SpriteEffects.None;
        o.Depth = 0;
        return o;
    }

    internal SpriteBatch SpriteBatch;
    internal Texture2D Texture;
    internal Vector2 Position;
    internal Rectangle? Source;
    internal Vector2 Scale = Vector2.One;
    internal Vector2 Origin;
    internal Color Color = Color.White;
    internal float Rotation;
    internal SpriteEffects Effect = SpriteEffects.None;
    internal float Depth;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void Complete()
    {
        SpriteBatch.Draw(Texture, Position, Source, Color, Rotation, Origin, Scale, Effect, Depth);
        _storage.Push(this);
    }
}

using SBC = Monogame.Fluent.SpriteBatchCall;
using StrBC = Monogame.Fluent.SpriteBatchStringCall;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Monogame.Fluent;

public static class FluentExtensions
{
    public static SBC Draw(this SpriteBatch spriteBatch, Texture2D texture, Vector2 position)
    {
        var sbc = SBC.Request();
        sbc.Texture = texture;
        sbc.Position = position;
        sbc.SpriteBatch = spriteBatch;
        return sbc;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SBC Draw(this SpriteBatch spriteBatch, Texture2D texture, float x, float y)
        => Draw(spriteBatch, texture, new Vector2(x, y));

    public static StrBC DrawString(this SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position)
    {
        var strbc = StrBC.Request();
        strbc.Position = position;
        strbc.SpriteBatch = spriteBatch;
        strbc.SpriteFont = font;
        strbc.Text = text;
        return strbc;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StrBC DrawString(this SpriteBatch spriteBatch, SpriteFont font, string text, float x, float y)
        => DrawString(spriteBatch, font, text, new Vector2(x, y));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SBC Rotate(this SBC SBC, float radians)
    {
        SBC.Rotation = radians;
        return SBC;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StrBC Rotate(this StrBC SBC, float radians)
    {
        SBC.Rotation = radians;
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SBC SetSource(this SBC SBC, Rectangle source)
    {
        SBC.Source = source;
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SBC Scale(this SBC SBC, Vector2 scale)
    {
        SBC.Scale = scale;
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StrBC Scale(this StrBC SBC, Vector2 scale)
    {
        SBC.Scale = scale;
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SBC Scale(this SBC SBC, float scale)
    {
        SBC.Scale = new(scale);
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StrBC Scale(this StrBC SBC, float scale)
    {
        SBC.Scale = new(scale);
        return SBC;

    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SBC Origin(this SBC SBC, Vector2 origin)
    {
        SBC.Origin = origin;
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StrBC Origin(this StrBC SBC, Vector2 origin)
    {
        SBC.Origin = origin;
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SBC Color(this SBC SBC, Color color)
    {
        SBC.Color = color;
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StrBC Color(this StrBC SBC, Color color)
    {
        SBC.Color = color;
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SBC FlipHorizonally(this SBC SBC)
    {//if they flip twice, it will flip back, so we XOR instead of OR
        SBC.Effect ^= SpriteEffects.FlipHorizontally;
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StrBC FlipHorizonally(this StrBC SBC)
    {
        SBC.Effect ^= SpriteEffects.FlipHorizontally;
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SBC FlipVertically(this SBC SBC)
    {
        SBC.Effect ^= SpriteEffects.FlipVertically;
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StrBC FlipVertically(this StrBC SBC)
    {
        SBC.Effect ^= SpriteEffects.FlipVertically;
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SBC AtDepth(this SBC SBC, float depth)
    {
        SBC.Depth = depth;
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StrBC AtDepth(this StrBC SBC, float depth)
    {
        SBC.Depth = depth;
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SBC Submit(this SBC SBC)
    {
        SBC.Complete();
        return SBC;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StrBC Submit(this StrBC SBC)
    {
        SBC.Complete();
        return SBC;
    }
}
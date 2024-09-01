using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Monogame.Fluent.Examples;
public class GameRoot : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteFont _font;
    private Texture2D _pixel;

    public GameRoot()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _font = Content.Load<SpriteFont>("arial");
        _pixel = new Texture2D(GraphicsDevice, 1, 1);
        _pixel.SetData([Color.White]);
        for(int i = 0; i < 100; i++)
        {
            var result = _spriteBatch.Draw(_pixel, new Vector2(Random.Shared.NextSingle() * GraphicsDevice.Viewport.Width, Random.Shared.NextSingle() * GraphicsDevice.Viewport.Height));

            if(Random.Shared.NextSingle() < 0.2f)
                result.Rotate(Random.Shared.NextSingle() * MathHelper.TwoPi);

            result
                .Color(new Color((uint)Random.Shared.NextInt64()))
                .Scale(Random.Shared.NextSingle() * 20 + 20);

            _calls.Add(result);
        }
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        base.Update(gameTime);
    }

    private List<SpriteBatchCall> _calls = new();

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();

        _spriteBatch.Draw(_pixel, 100, 200)
            .Scale(10)
            .Color(Color.Red)
            .Rotate(0.2f)
            .FlipHorizonally()
            .Submit();

        _spriteBatch.DrawString(_font, "Hello", 100, 300)
            .Color(Color.Black)
            .FlipVertically()
            .Submit();

        foreach (var call in _calls)
        {
            call.Submit();
        }

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}

# Monogame.Fluent

Test in adding some fluent syntax into spritebatch

Example:
```csharp
_spriteBatch.Draw(_pixel, 100, 200)
            .Scale(10)
            .Color(Color.Red)
            .Rotate(0.2f)
            .FlipHorizonally()
            .Submit();
```

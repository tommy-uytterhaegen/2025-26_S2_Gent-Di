using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame_Pikachu.Extensions
{
    internal static class SpriteBatchExtensions
    {
        public static void Draw(this SpriteBatch spriteBatch, Texture2D texture, Vector2 vector)
        {
            spriteBatch.Draw(texture, vector, Color.White);
        }
        public static void Draw(this SpriteBatch spriteBatch, Texture2D texture, Vector2 vector, float scale)
        {
            spriteBatch.Draw(texture, vector, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
    }
}

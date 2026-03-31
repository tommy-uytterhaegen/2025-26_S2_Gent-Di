using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Pikachu.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Core.Objects
{
    public abstract class Sprite
    {
        protected const float NO_SCALE = 1.0f;

        public Texture2D Texture { get; init; }

        public Vector2 Position { get; private set; }

        public float Scale { get; init; }

        public float Speed { get; init; }

        protected Sprite(Texture2D texture, Vector2 position, float scale, float speed)
        {
            Texture = texture;
            Position = position;
            Scale = scale;
            Speed = speed;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Scale == NO_SCALE)
                spriteBatch.Draw(Texture, Position);
            else
                spriteBatch.Draw(Texture, Position, Scale);
        }

        public virtual void Update()
        {

        }

        public void UpdatePosition(float x, float y)
        {
            Position = Position with
            {
                X = Position.X + x,
                Y = Position.Y + y
            };
        }

        public void UpdatePositionX(float x)
        {
            Position = Position with
            {
                X = Position.X + x
            };
        }

        public void UpdatePositionY(float y)
        {
            Position = Position with
            {
                Y = Position.Y + y
            };
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Objects;

namespace MonoGame_Pikachu.States
{
    public class StartScreenState
        : AbstractState
    {
        public StartScreenState(GameContext context)
            :base(context)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (IsKeyDown(Keys.Enter))
                Context.ChangeState(new PlayingState(Context));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Context.Assets.GetFont(AssetNames.FONT), 
                                    "Druk op enter om te beginnen", 
                                    Vector2.Zero, 
                                    Color.White);
        }

    }
}

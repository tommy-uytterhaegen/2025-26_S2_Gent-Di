using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.States
{
    public class PausedState
         : AbstractState
    {
        private PlayingState PreviousState { get; init; }

        public PausedState(Game1 context, PlayingState previousState) 
            : base(context)
        {
            PreviousState = previousState;
        }

        public override void Update(GameTime gameTime)
        {
            if (WasKeyJustPressed(Keys.P))
                Context.ChangeState(PreviousState);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            PreviousState.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(Context._spriteFont, "Gepauzeerd. Druk op enter om verder te gaan", Vector2.Zero, Color.White);
        }

    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Objects;
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

        public PausedState(GameContext context, PlayingState previousState) 
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

            spriteBatch.DrawString(Context.Assets.GetFont(AssetNames.FONT), 
                                   "Gepauzeerd. Druk op enter om verder te gaan", 
                                   position: Vector2.Zero, 
                                   color: Color.White);
        }

    }
}

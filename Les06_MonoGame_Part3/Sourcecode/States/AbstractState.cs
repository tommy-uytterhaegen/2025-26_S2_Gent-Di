using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.States
{
    public abstract class AbstractState
    {
        protected Game1 Context { get; init; }

        protected AbstractState(Game1 context)
        {
            Context = context;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        protected bool IsKeyDown(Keys key)
            => KeyboardFacade.IsKeyDown(key);

        protected bool WasKeyJustPressed(Keys key)
            => KeyboardFacade.WasKeyJustPressed(key);

        protected bool IsKeyDown(Keys key1, Keys key2)
            => IsKeyDown(key1) || IsKeyDown(key2);

    }
}

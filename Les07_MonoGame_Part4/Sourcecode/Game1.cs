using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Core;
using MonoGame_Pikachu.Objects;

namespace MonoGame_Pikachu
{
    // Ik heb mogelijke TODO's toegevoegd die het spel interessanter kunnen maken. Deze zijn vrijblijvend, maar aangeraden. 
    public class Game1 : Game
    {
        private SpriteBatch _spriteBatch;

        public GameContext GameContext { get; private set; }

        public Game1()
        {
            GraphicsFacade.Initialize(this, height: 540, width: 768);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GameContext = new GameContext(this);
             
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardFacade.Update();

            // TODO: Gebruik hier de KeyboardFacade
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            GameContext.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Afhankelijk van het aantal haaien die onze speler voorbij is zouden we de clear kleur kunnen aanpassen, zo wordt het spel steeds donkerder naarmate je meer haaien voorbij bent. Nu is de clear kleur altijd hetzelfde.
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            GameContext.Draw(gameTime, _spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
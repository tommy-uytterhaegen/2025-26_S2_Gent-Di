using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Core;
using MonoGame_Pikachu.Extensions;
using MonoGame_Pikachu.Factories;
using MonoGame_Pikachu.Objects;
using MonoGame_Pikachu.States;
using System;
using System.Collections.Generic;

namespace MonoGame_Pikachu
{
    // Ik heb mogelijke TODO's toegevoegd die het spel interessanter kunnen maken. Deze zijn vrijblijvend, maar aangeraden. 
    public class Game1 : Game
    {
        // Constants for game configuration
        public const int SHARK_SPAWN_TIME_IN_MS = 3000;

        public const float PLAYER_SPEED = 5f;
        public const float PLAYER_SCALE = 1.0f;

        public const float SHARK_SPEED = 3f;
        public const float SHARK_SCALE = 0.35f;

        public const float BACKGROUND_SPEED = 2f;
        public const float BACKGROUND_SCALE = 0.25f;

        private AbstractState _activeState;

        private SpriteBatch _spriteBatch;

        // DIT IS VUIL
        // We willen iedere 3 seconden een nieuwe haai, hiervoor moeten wij bijhouden hoeveel tijd er is verstreken sinds de laatste haai is gespawned. Hiervoor gebruiken wij deze variabele.
        public double _elapsedTimeForSpawnInMs;


        public SpriteFont _spriteFont;

        public PlayerSprite _player;

        public Texture2D _playerTexture;

        public Texture2D _enemyTexture;
        public List<SharkSprite> _sharks;

        // TODO: Zet deze ook om naar een sprite
        public Texture2D _backgroundTexture;
        public Vector2 _backgroundPosition;
        // EINDE VUIL

        public Game1()
        {
            GraphicsFacade.Initialize(this, height: 540, width: 768);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void ChangeState(AbstractState newActiveActive)
        {
            _activeState = newActiveActive;
        }

        protected override void Initialize()
        {
            _activeState = new StartScreenState(this);

            _elapsedTimeForSpawnInMs = 0;

            _backgroundPosition = new Vector2(0, 0);
            _sharks = new List<SharkSprite>();

            base.Initialize();

            _player = PlayerFactory.CreateInVerticalCenter(_playerTexture);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: Maak een AssetManager die het laden van assets voor ons doet. Deze zal ook elke asset maar 1x inladen.
            //       Als hij een asset (Texture, Font, ...) al eens geladen heeft dan moet hij dezelfde instantie geven (denk dictionary)
            _playerTexture = Content.Load<Texture2D>("surfing-pikachu");
            _enemyTexture = Content.Load<Texture2D>("haai");
            _backgroundTexture = Content.Load<Texture2D>("water");

            _spriteFont = Content.Load<SpriteFont>("game-font");
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardFacade.Update();

            // TODO: Gebruik hier de KeyboardFacade
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _activeState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Afhankelijk van het aantal haaien die onze speler voorbij is zouden we de clear kleur kunnen aanpassen, zo wordt het spel steeds donkerder naarmate je meer haaien voorbij bent. Nu is de clear kleur altijd hetzelfde.
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _activeState.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}

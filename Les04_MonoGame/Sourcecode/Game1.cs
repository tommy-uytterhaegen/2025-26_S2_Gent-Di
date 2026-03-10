using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Extensions;
using System;
using System.Collections.Generic;

namespace MonoGame_Pikachu
{
    // Ik heb mogelijke TODO's toegevoegd die het spel interessanter kunnen maken. Deze zijn vrijblijvend, maar aangeraden. 
    public class Game1 : Game
    {
        // Constants for game configuration
        private const int SHARK_SPAWN_TIME_IN_MS = 3000;

        private const float PLAYER_SPEED = 5f;
        private const float PLAYER_SCALE = 0.5f;

        private const float SHARK_SPEED = 3f;
        private const float SHARK_SCALE = 0.35f;

        private const float BACKGROUND_SPEED = 2f;
        private const float BACKGROUND_SCALE = 0.25f;

        // We willen iedere 3 seconden een nieuwe haai, hiervoor moeten wij bijhouden hoeveel tijd er is verstreken sinds de laatste haai is gespawned. Hiervoor gebruiken wij deze variabele.
        private double _elapsedTimeForSpawnInMs;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        private Texture2D _playerTexture;
        private Vector2 _playerPosition;

        private Texture2D _enemyTexture;
        private List<Vector2> _enemyPositions;

        private Texture2D _backgroundTexture;
        private Vector2 _backgroundPosition;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Resolutie verzetten
            _graphics.PreferredBackBufferHeight = 540;
            _graphics.PreferredBackBufferWidth = 768;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            _elapsedTimeForSpawnInMs = 0;

            _playerPosition = new Vector2(0, _graphics.PreferredBackBufferHeight / 2);
            _backgroundPosition = new Vector2(0, 0);
            _enemyPositions = new List<Vector2>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _playerTexture = Content.Load<Texture2D>("surfing-pikachu");
            _enemyTexture = Content.Load<Texture2D>("haai");
            _backgroundTexture = Content.Load<Texture2D>("water");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Controlleer of de speler een haai aanraakt. Indien 'ja' -> Dood (bv. Exit)

            // TODO: Er is nog geen limiet aan het aantal haaien dat kan spawnen. Voeg een limiet toe van 8 haaien tegelijk.
            _elapsedTimeForSpawnInMs += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_elapsedTimeForSpawnInMs >= SHARK_SPAWN_TIME_IN_MS)
            {
                // TODO: Geef een haai ook verschillende snelheden, nu hebben alle haaien dezelfde snelheid (wat het speelveld saai maakt). Je kan bijvoorbeeld een random snelheid geven tussen de 1 en 3.
                // TODO: Spawn elke haai op een random hoogte, nu spawnen ze altijd in het midden van het scherm.
                _enemyPositions.Add(new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight / 2));
                _elapsedTimeForSpawnInMs = 0;
            }

            UpdateBackgroundPosition();

            HandlePlayerMovement();

            UpdateEnemyPositions();

            // TODO: Als een haai links uit beeld is, dan mag deze uit de lijst. Nu blijven de haaien oneindig in de lijst staan, ook al zijn ze al lang uit beeld.

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Afhankelijk van het aantal haaien die onze speler voorbij is zouden we de clear kleur kunnen aanpassen, zo wordt het spel steeds donkerder naarmate je meer haaien voorbij bent. Nu is de clear kleur altijd hetzelfde.
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_backgroundTexture, _backgroundPosition, BACKGROUND_SCALE);
            _spriteBatch.Draw(_playerTexture, _playerPosition, PLAYER_SCALE);

            // TODO: We zouden bij het spawned van de haaien een bepaalde random scale kunnen geven aan een specifieke haai, zo zien sommige er groter uit dan anderen. Dit zou het speelveld interessanter maken. Nu hebben alle haaien dezelfde grootte.
            foreach (var sharkPosition in _enemyPositions)
                _spriteBatch.Draw(_enemyTexture, sharkPosition, SHARK_SCALE);


            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateEnemyPositions()
        {
            for (var i = 0; i < _enemyPositions.Count; i++)
                _enemyPositions[i] = new Vector2(_enemyPositions[i].X - SHARK_SPEED, _enemyPositions[i].Y);
        }

        private void UpdateBackgroundPosition()
        {
            _backgroundPosition.X -= BACKGROUND_SPEED;
        }

        private void HandlePlayerMovement()
        {
            // TODO: We zouden deze toetsen kunnen uitlezen uit een bestand (denk aan wat jullie bij programmeren gedaan hebben). Dit zou het makkelijker maken om de controls aan te passen, zonder dat je de code moet aanpassen. Nu zijn de controls hardcoded in de code.
            if (IsKeyDown(Keys.Right, Keys.D))
                _playerPosition.X += PLAYER_SPEED;

            if (IsKeyDown(Keys.Left, Keys.Q))
                _playerPosition.X -= PLAYER_SPEED;

            if (IsKeyDown(Keys.Up, Keys.Z))
                _playerPosition.Y -= PLAYER_SPEED;

            if (IsKeyDown(Keys.Down, Keys.S))
                _playerPosition.Y += PLAYER_SPEED;
        }

        private bool IsKeyDown(Keys key1, Keys key2)
            => IsKeyDown(key1) || IsKeyDown(key2);

        private bool IsKeyDown(Keys key)
            => Keyboard.GetState().IsKeyDown(key);

    }
}

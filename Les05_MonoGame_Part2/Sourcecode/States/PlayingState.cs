using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.States
{
    public class PlayingState
        : AbstractState
    {
        public PlayingState(Game1 context) 
            : base(context)
        {
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Controlleer of de speler een haai aanraakt. Indien 'ja' -> Dood (bv. Exit)

            SpawnEnemyIfNeeded(gameTime);

            UpdateBackgroundPosition();

            HandlePlayerMovement();

            UpdateEnemyPositions();

            // TODO: Als een haai links uit beeld is, dan mag deze uit de lijst. Nu blijven de haaien oneindig in de lijst staan, ook al zijn ze al lang uit beeld.

            if (IsKeyDown(Keys.P))
                Context.ChangeState(new PausedState(Context, this));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Context._backgroundTexture, Context._backgroundPosition, Game1.BACKGROUND_SCALE);
            spriteBatch.Draw(Context._playerTexture, Context._playerPosition, Game1.PLAYER_SCALE);

            // TODO: We zouden bij het spawned van de haaien een bepaalde random scale kunnen geven aan een specifieke haai, zo zien sommige er groter uit dan anderen. Dit zou het speelveld interessanter maken. Nu hebben alle haaien dezelfde grootte.
            foreach (var sharkPosition in Context._enemyPositions)
                spriteBatch.Draw(Context._enemyTexture, sharkPosition, Game1.SHARK_SCALE);
        }

        private void SpawnEnemyIfNeeded(GameTime gameTime)
        {
            // TODO: Er is nog geen limiet aan het aantal haaien dat kan spawnen. Voeg een limiet toe van 8 haaien tegelijk.
            Context._elapsedTimeForSpawnInMs += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (Context._elapsedTimeForSpawnInMs >= Game1.SHARK_SPAWN_TIME_IN_MS)
            {
                // TODO: Geef een haai ook verschillende snelheden, nu hebben alle haaien dezelfde snelheid (wat het speelveld saai maakt). Je kan bijvoorbeeld een random snelheid geven tussen de 1 en 3.
                // TODO: Spawn elke haai op een random hoogte, nu spawnen ze altijd in het midden van het scherm.
                Context._enemyPositions.Add(new Vector2(Context._graphics.PreferredBackBufferWidth, Context._graphics.PreferredBackBufferHeight / 2));
                Context._elapsedTimeForSpawnInMs = 0;
            }
        }

        private void UpdateEnemyPositions()
        {
            for (var i = 0; i < Context._enemyPositions.Count; i++)
                Context._enemyPositions[i] = Context._enemyPositions[i] with { X = Context._enemyPositions[i].X - Game1.SHARK_SPEED };
        }

        private void UpdateBackgroundPosition()
        {
            Context._backgroundPosition.X -= Game1.BACKGROUND_SPEED;
        }

        private void HandlePlayerMovement()
        {
            // TODO: We zouden deze toetsen kunnen uitlezen uit een bestand (denk aan wat jullie bij programmeren gedaan hebben). Dit zou het makkelijker maken om de controls aan te passen, zonder dat je de code moet aanpassen. Nu zijn de controls hardcoded in de code.
            if (ShouldMoveRight())
                MoveRight();

            // TODO: Splits deze ook af zoals de MoveRight / ShouldMoveRight
            if (IsKeyDown(Keys.Left, Keys.Q))
                Context._playerPosition.X -= Game1.PLAYER_SPEED;

            if (IsKeyDown(Keys.Up, Keys.Z))
                Context._playerPosition.Y -= Game1.PLAYER_SPEED;

            if (IsKeyDown(Keys.Down, Keys.S))
                Context._playerPosition.Y += Game1.PLAYER_SPEED;
        }

        private void MoveRight()
        {
            Context._playerPosition.X += Game1.PLAYER_SPEED;
        }

        private bool ShouldMoveRight()
        {
            return IsKeyDown(Keys.Right, Keys.D);
        }

    }
}

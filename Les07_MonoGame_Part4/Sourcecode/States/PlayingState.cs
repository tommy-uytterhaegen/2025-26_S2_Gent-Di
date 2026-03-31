using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Core;
using MonoGame_Pikachu.Extensions;
using MonoGame_Pikachu.Factories;
using MonoGame_Pikachu.Objects;
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
        public PlayingState(GameContext context)
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

            if (WasKeyJustPressed(Keys.P))
                Context.ChangeState(new PausedState(Context, this));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Context.Assets.GetTexture(AssetNames.BACKGROUND_TEXTURE),
                             Context._backgroundPosition,
                             Const.BACKGROUND_SCALE);

            Context._player.Draw(gameTime, spriteBatch);

            // TODO: We zouden bij het spawned van de haaien een bepaalde random scale kunnen geven aan een specifieke haai, zo zien sommige er groter uit dan anderen. Dit zou het speelveld interessanter maken. Nu hebben alle haaien dezelfde grootte.
            foreach (var shark in Context._sharks)
                shark.Draw(gameTime, spriteBatch);
        }

        private void SpawnEnemyIfNeeded(GameTime gameTime)
        {
            Context.Spawn.AddEnemiesIfNeeded(gameTime, Context._sharks);
        }

        private void UpdateEnemyPositions()
        {
            foreach (var shark in Context._sharks)
                shark.Update();
        }

        private void UpdateBackgroundPosition()
        {
            Context._backgroundPosition.X -= Const.BACKGROUND_SPEED;
        }

        private void HandlePlayerMovement()
        {
            Context._player.Update();
        }
    }
}

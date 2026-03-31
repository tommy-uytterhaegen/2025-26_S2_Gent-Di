using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Pikachu.Factories;
using MonoGame_Pikachu.Service;
using MonoGame_Pikachu.Spawner;
using MonoGame_Pikachu.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Objects
{
    public class GameContext
    {
        public AssetManager Assets { get; private set; }
        public SpawnManager Spawn { get; private set; }

        private AbstractState _activeState;

        public PlayerSprite _player;
        public List<Enemy> _sharks;

        // TODO: Zet deze ook om naar een sprite
        public Vector2 _backgroundPosition;

        public GameContext(Game game)
        {
            Assets = new AssetManager(game);
            Spawn = new SpawnManager(new List<Spawner.Spawner>
            {
                new SharkSpawner(this, Const.SHARK_SPAWN_TIME_IN_MS),
                new SharkSpawner(this, Const.SHARK_SPAWN_TIME_IN_MS * 2)
            });

            _activeState = new StartScreenState(this);

            _backgroundPosition = new Vector2(0, 0);
            _sharks = new List<Enemy>();

            _player = PlayerFactory.CreateInVerticalCenter(
                    Assets.GetTexture(AssetNames.PLAYER_TEXTURE),
                    Const.PLAYER_SPEED,
                    new PlayerInputService());

        }

        public void ChangeState(AbstractState newActiveActive)
        {
            _activeState = newActiveActive;
        }

        internal void Update(GameTime gameTime)
        {
            _activeState.Update(gameTime);
        }

        internal void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _activeState.Draw(gameTime, spriteBatch);
        }
    }
}

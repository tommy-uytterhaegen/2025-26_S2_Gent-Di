using Microsoft.Xna.Framework;
using MonoGame_Pikachu.Core;
using MonoGame_Pikachu.Factories;
using MonoGame_Pikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Spawner
{
    public class SpawnManager
    {
        private readonly List<Spawner> _spawners;

        public SpawnManager(List<Spawner> spawners)
        {
            _spawners = spawners;
        }

        public void AddEnemiesIfNeeded(GameTime gameTime, List<Enemy> enemies)
        {
            foreach (var spawner in _spawners)
            {
                if ( spawner.TrySpawn(gameTime, out var enemy) )
                    enemies.Add(enemy);
            }
        }
    }
}

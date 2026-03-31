using Microsoft.Xna.Framework;
using MonoGame_Pikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Spawner
{
    public abstract class Spawner
    {
        public abstract bool TrySpawn(GameTime gameTime, out Enemy enemy);
    }
}

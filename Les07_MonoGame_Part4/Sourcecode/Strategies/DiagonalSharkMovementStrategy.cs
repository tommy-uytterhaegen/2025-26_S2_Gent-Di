using MonoGame_Pikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Strategies
{
    internal class DiagonalSharkMovementStrategy
        : SharkMovementStrategy
    {
        public override void Apply(SharkSprite shark)
        {
            shark.UpdatePosition(-shark.Speed, 1f);
        }
    }
}

using MonoGame_Pikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Strategies
{
    public class FastSharkMovementStrategy
        : SharkMovementStrategy
    {
        public override void Apply(SharkSprite shark)
        {
            shark.UpdatePositionX( - shark.Speed * 1.5f);
        }
    }
}

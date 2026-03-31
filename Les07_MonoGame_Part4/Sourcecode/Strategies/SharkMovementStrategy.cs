using MonoGame_Pikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Strategies
{
    public abstract class SharkMovementStrategy
    {
        abstract public void Apply(SharkSprite shark);
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Pikachu.Core.Objects;
using MonoGame_Pikachu.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Objects
{
    public class SharkSprite : Enemy
    {
        public SharkMovementStrategy MovementStrategy { get; init; }

        public SharkSprite(Texture2D texture, Vector2 position, float scale, float speed, SharkMovementStrategy movementStrategy) 
            : base(texture, position, scale, speed)
        {
            MovementStrategy = movementStrategy;
        }

        public override void Update()
        {
            MovementStrategy.Apply(this);
        }
    }
}

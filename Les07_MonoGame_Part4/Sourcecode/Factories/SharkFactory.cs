using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Pikachu.Core;
using MonoGame_Pikachu.Objects;
using MonoGame_Pikachu.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Factories
{
    public static class SharkFactory
    { 
        public static SharkSprite CreateBig(Texture2D texture, float x, float y, float speed)
        {
            return new SharkSprite(texture,
                                   new Vector2(x, y), 
                                   1.0f,
                                   speed,
                                   new DiagonalSharkMovementStrategy());
        }

        public static SharkSprite CreateSmall(Texture2D texture, float x, float y, float speed)
        {
            return new SharkSprite(texture,
                                   new Vector2(x, y),
                                   Const.SHARK_SCALE,
                                   speed,
                                   new HorizontalSharkMovementStrategy());
        }

        public static SharkSprite CreateMedium(Texture2D texture, float x, float y, float speed)
        {
            return new SharkSprite(texture,
                                   new Vector2(x, y),
                                   Const.SHARK_SCALE,
                                   speed,
                                   new FastSharkMovementStrategy());
        }

        public static SharkSprite CreateRandomSize(Texture2D texture, float x, float y, float speed)
        {
            var r = Random.Shared.Next(3);
            if ( r == 0 )
                return CreateBig(texture, x, y, speed);
            else if ( r == 1 )
                return CreateSmall(texture, x, y, speed);
            else if (r == 2)
                return CreateMedium(texture, x, y, speed);
            else
                throw new NotImplementedException();
        }


    }
}

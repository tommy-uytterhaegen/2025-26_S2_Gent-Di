using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Pikachu.Core;
using MonoGame_Pikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Factories
{
    public static class SharkFactory
    { 
        public static SharkSprite CreateBig(Texture2D texture, float x, float y)
        {
            return new SharkSprite(texture,
                                   new Vector2(x, y), 1.0f);
        }

        public static SharkSprite CreateSmall(Texture2D texture, float x, float y)
        {
            return new SharkSprite(texture,
                                   new Vector2(x, y),
                                   Game1.SHARK_SCALE);
        }

        public static SharkSprite CreateRandomSize(Texture2D texture, float x, float y)
        {
            if ( Random.Shared.Next(2) == 0 )
                return CreateBig(texture, x, y);
            else
                return CreateSmall(texture, x, y);
        }


    }
}

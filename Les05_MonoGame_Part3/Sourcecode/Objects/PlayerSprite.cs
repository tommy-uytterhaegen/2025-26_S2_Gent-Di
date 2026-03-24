using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Pikachu.Core.Objects;
using MonoGame_Pikachu.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Objects
{
    public class PlayerSprite : Sprite
    {
        public PlayerSprite(Texture2D texture, Vector2 position) 
            : base(texture, position, NO_SCALE)
        {
        }

    }
}

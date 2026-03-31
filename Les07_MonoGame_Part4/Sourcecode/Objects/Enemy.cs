using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Pikachu.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Objects
{
    public abstract class Enemy : Sprite
    {
        protected Enemy(Texture2D texture, Vector2 position, float scale, float speed) 
            : base(texture, position, scale, speed)
        {
        }
    }
}

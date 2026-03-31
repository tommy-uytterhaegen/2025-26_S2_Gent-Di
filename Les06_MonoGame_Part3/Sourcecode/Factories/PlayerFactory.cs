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
    public static class PlayerFactory
    {
        public static PlayerSprite Create(Texture2D texture, Vector2 position)
        {
            return new PlayerSprite(texture, position);
        }

        public static PlayerSprite Create(Texture2D texture, float x, float y)
        {
            return new PlayerSprite(texture, new Vector2(x, y));
        }

        public static PlayerSprite CreateInVerticalCenter(Texture2D texture)
        {
            return new PlayerSprite(texture, new Vector2(0, GraphicsFacade.GetWindowVerticalCenter()));
        }
    }
}

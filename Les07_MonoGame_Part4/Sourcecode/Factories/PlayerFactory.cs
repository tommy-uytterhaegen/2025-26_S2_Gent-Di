using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Pikachu.Core;
using MonoGame_Pikachu.Interfaces;
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
        public static PlayerSprite Create(Texture2D texture, float x, float y, float speed, IPlayerInputService inputService)
        {
            return Create(texture, new Vector2(x, y), speed, inputService);
        }

        public static PlayerSprite CreateInVerticalCenter(Texture2D texture, float speed, IPlayerInputService inputService)
        {
            return Create(texture, 0, GraphicsFacade.GetWindowVerticalCenter(), speed, inputService);
        }

        public static PlayerSprite Create(Texture2D texture, Vector2 position, float speed, IPlayerInputService inputService)
        {
            return new PlayerSprite(texture, position, speed, inputService);
        }

    }
}

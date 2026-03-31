using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Core
{
    public static class GraphicsFacade
    {
        private static GraphicsDeviceManager _graphics;

        public static void Initialize(Game game, int height, int width)
        {
            _graphics = new GraphicsDeviceManager(game);

            ChangeResolution(height, width);
        }

        public static void ChangeResolution(int height, int width)
        {
            _graphics.PreferredBackBufferHeight = height;
            _graphics.PreferredBackBufferWidth = width;
            _graphics.ApplyChanges();
        }

        public static float GetWindowVerticalCenter()
        {
            return _graphics.PreferredBackBufferHeight * 0.5f;
        }

        public static float GetWindowWidth()
        {
            return _graphics.PreferredBackBufferWidth;
        }
    }
}

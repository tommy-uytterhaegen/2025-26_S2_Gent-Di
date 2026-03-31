using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Core;
using MonoGame_Pikachu.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Service
{
    internal class Player2InputService : IPlayerInputService
    {
        public bool ShouldMoveRight()
        {
            return KeyboardFacade.IsKeyDown([ Keys.D ]);
        }

        public bool ShouldMoveLeft()
        {
            return KeyboardFacade.IsKeyDown([Keys.Q]);
        }

        public bool ShouldMoveUp()
        {
            return KeyboardFacade.IsKeyDown([Keys.Z]);
        }

        public bool ShouldMoveDown()
        {
            return KeyboardFacade.IsKeyDown([Keys.S]);
        }
    }
}

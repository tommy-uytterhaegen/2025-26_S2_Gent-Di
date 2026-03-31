using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Interfaces
{
    public interface IPlayerInputService
    {
        public bool ShouldMoveRight();
        public bool ShouldMoveLeft();
        public bool ShouldMoveUp();
        public bool ShouldMoveDown();
    }
}

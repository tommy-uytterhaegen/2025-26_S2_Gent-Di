using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Core;
using MonoGame_Pikachu.Core.Objects;
using MonoGame_Pikachu.Extensions;
using MonoGame_Pikachu.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Objects
{
    public class PlayerSprite : Sprite
    {
        public IPlayerInputService InputService { get; init; }

        public PlayerSprite(Texture2D texture, Vector2 position, float speed, IPlayerInputService inputService) 
            : base(texture, position, NO_SCALE, speed)
        {
            InputService = inputService;
        }

        public override void Update()
        {
            // TODO: We zouden deze toetsen kunnen uitlezen uit een bestand (denk aan wat jullie bij programmeren gedaan hebben). Dit zou het makkelijker maken om de controls aan te passen, zonder dat je de code moet aanpassen. Nu zijn de controls hardcoded in de code.
            if (InputService.ShouldMoveRight())
                UpdatePositionX( + Speed);

            // TODO: Splits deze ook af zoals de MoveRight / ShouldMoveRight
            if (InputService.ShouldMoveLeft())
                UpdatePositionX( - Speed);

            if (InputService.ShouldMoveUp())
                UpdatePositionY( - Speed);

            if (InputService.ShouldMoveDown())
                UpdatePositionY( + Speed);
        }

    }
}


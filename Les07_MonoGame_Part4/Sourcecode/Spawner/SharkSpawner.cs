using Microsoft.Xna.Framework;
using MonoGame_Pikachu.Core;
using MonoGame_Pikachu.Core.Objects;
using MonoGame_Pikachu.Factories;
using MonoGame_Pikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Spawner
{
    internal class SharkSpawner : Spawner
    {
        public GameContext Context { get; init; }

        public double _elapsedTimeForSpawnInMs;

        public double MaxSpawnTime { get; init; }

        public SharkSpawner(GameContext context, int maxSpawnTime) 
        {
            Context = context;
            _elapsedTimeForSpawnInMs = 0;

            MaxSpawnTime = maxSpawnTime;    
        }

        public override bool TrySpawn(GameTime gameTime, out Enemy enemy)
        {
            // TODO: Er is nog geen limiet aan het aantal haaien dat kan spawnen. Voeg een limiet toe van 8 haaien tegelijk.
            _elapsedTimeForSpawnInMs += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_elapsedTimeForSpawnInMs >= MaxSpawnTime)
            {
                // TODO: Geef een haai ook verschillende snelheden, nu hebben alle haaien dezelfde snelheid (wat het speelveld saai maakt). Je kan bijvoorbeeld een random snelheid geven tussen de 1 en 3.
                // TODO: Spawn elke haai op een random hoogte, nu spawnen ze altijd in het midden van het scherm.
                enemy = SharkFactory.CreateRandomSize(Context.Assets.GetTexture(AssetNames.ENEMY_TEXTURE),
                                                                  x: GraphicsFacade.GetWindowWidth(),
                                                                  y: GraphicsFacade.GetWindowVerticalCenter(),
                                                                  Const.SHARK_SPEED);

                _elapsedTimeForSpawnInMs = 0;

                return true;
            }

            enemy = null;
            return false;
        }
    }
}

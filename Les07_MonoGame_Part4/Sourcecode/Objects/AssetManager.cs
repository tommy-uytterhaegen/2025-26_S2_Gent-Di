using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Pikachu.Objects
{
    public class AssetManager
    {
        private readonly Dictionary<string, Texture2D> _textureByName;
        private readonly Dictionary<string, SpriteFont> _fontByName;

        public ContentManager Content { get; init; }

        public AssetManager(Game game)
        {
            Content = game.Content;

            _textureByName = new Dictionary<string, Texture2D>();
            _fontByName = new Dictionary<string, SpriteFont>();
        }

        public Texture2D GetTexture(string name)
        {
            if ( _textureByName.TryGetValue(name, out var texture))
                return texture;

            texture = Content.Load<Texture2D>(name);
            _textureByName.Add(name, texture);
            return texture;
        }

        public SpriteFont GetFont(string name)
        {
            if (_fontByName.TryGetValue(name, out var font))
                return font;

            font = Content.Load<SpriteFont>(name);
            _fontByName.Add(name, font);
            return font;
        }
    }
}

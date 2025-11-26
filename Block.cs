using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Summative___Breakout
{
    public class Block
    {
        private Texture2D _texture;
        private Rectangle _location;
        private Color _color;

        public Block(Texture2D texture, Rectangle location, Color color)
        {
            _texture = texture;
            _location = location;
            _color = color;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, _color);
        }

        //public Color BrickColor
        //{
        //    get {  return _color; }
        //    set { _color = value; }
        //}
    }

}

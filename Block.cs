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

        public Block(Texture2D texture, Rectangle location)
        {
            _texture = texture;
            _location = location;
            if (_location.Y - 50 < -20)
            {
                _color = Color.Purple;
            }
            else if (_location.Y - 50 < 0)
            {
                _color = Color.Indigo;
            }
            else if (_location.Y - 50 < 20)
            {
                _color = Color.DarkBlue;
            }
            else if (_location.Y - 50 < 40)
            {
                _color = Color.RoyalBlue;
            }
            else if (_location.Y - 50 < 60)
            {
                _color = Color.Teal;
            }
            else if (_location.Y - 50 < 80)
            {
                _color = Color.LimeGreen;
            }
            else if (_location.Y - 50 < 100)
            {
                _color = Color.YellowGreen;
            }
            else if (_location.Y - 50 < 120)
            {
                _color = Color.Yellow;
            }
            else if (_location.Y - 50 < 140)
            {
                _color = Color.Gold;
            }
            else if (_location.Y - 50 < 160)
            {
                _color = Color.Orange;
            }
            else if (_location.Y - 50 < 180)
            {
                _color = Color.OrangeRed;
            }
            else
            {
                _color = Color.Red;
            }
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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Summative___Breakout
{
    public class Ball
    {
        private Texture2D _texture;
        private Rectangle _location;
        private Vector2 _speed;
        private Random generator, xDirection, yDirection;
        private bool start = false;

        public Ball(Texture2D texture, Rectangle location)
        {
            _texture = texture;
            _location = location;
            generator = new Random();
            xDirection = new Random();
            yDirection = new Random();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }

        public void Update(Rectangle window)
        {
            if (xDirection.Next(2)  == 0 && !start)
            {
                if (yDirection.Next(2) == 0)
                {
                    _speed = new Vector2(-3, -3);
                    start = true;
                }
                else
                {
                    _speed = new Vector2(-3, 3);
                    start = true;
                }
            }
            else if (xDirection.Next(2) == 1 && !start)
            {
                if (yDirection.Next(2) == 0)
                {
                    _speed = new Vector2(3, -3);
                    start = true;
                }
                else
                {
                    _speed = new Vector2(3, 3);
                    start = true;
                }
            }
            if (_location.X <= window.X)
            {
                _location.X = 0;
                _speed.X *= -1;
            }
            if (_location.X + _location.Width >= window.Width)
            {
                _location.X = window.Width - _location.Width;
                _speed.X *= -1;
            }
            if (_location.Y <= window.Y)
            {
                _location.Y = 0;
                _speed.Y *= -1;
            }
            if (_location.Y + _location.Height >= window.Height)
            {
                _location.Y = window.Height - _location.Height;
                _speed.Y *= -1;
            }
            _location.Offset(_speed);
        }
    }
}

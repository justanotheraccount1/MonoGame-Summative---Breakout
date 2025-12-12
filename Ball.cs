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
        private Random xDirection, yDirection;
        private bool start = false;
        private float _seconds;

        public Ball(Texture2D texture, Rectangle location)
        {
            _texture = texture;
            _location = location;
            xDirection = new Random();
            yDirection = new Random();
            _seconds = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }

        public void Update(Rectangle window, List<Block> blocks, Paddle paddle, GameTime gameTime)
        {
            _seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (xDirection.Next(2)  == 0 && !start)
            {
                if (yDirection.Next(2) == 0)
                {
                    _speed = new Vector2(-4, -3);
                    start = true;
                }
                else
                {
                    _speed = new Vector2(-4, 3);
                    start = true;
                }
            }
            else if (xDirection.Next(2) == 1 && !start)
            {
                if (yDirection.Next(2) == 0)
                {
                    _speed = new Vector2(4, -3);
                    start = true;
                }
                else
                {
                    _speed = new Vector2(4, 3);
                    start = true;
                }
            }

            _location.X += (int)_speed.X;
            bool hitX = false;
            for (int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i].Intersects(_location))
                {
                    hitX = true;
                    blocks.RemoveAt(i);
                    i--;
                }
            }
            if (paddle.Intersects(_location))
            {
                if (_location.X + _location.Width < paddle._location.X + paddle._location.Width)
                {
                    _location.X = paddle._location.X - _location.Width - 10;
                    paddle.Speed = Vector2.Zero;
                }
                if (_location.X + _location.Width > paddle._location.X + paddle._location.Width)
                {
                    _location.X = paddle._location.X + paddle._location.Width + 10;
                    paddle.Speed = Vector2.Zero;
                }
                hitX = true;
            }
            if (hitX)
            {
                _speed.X *= -1;
                _location.X += (int)_speed.X;
                hitX = false;
            }


            bool hitY = false;
            _location.Y += (int)_speed.Y;
            for (int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i].Intersects(_location))
                {
                    hitY = true;
                    blocks.RemoveAt(i);
                    i--;
                }
            }
            if (paddle.Intersects(_location))
            {
                hitY = true;
            }
            if (hitY)
            {
                _speed.Y *= -1;
                _location.Y += (int)_speed.Y;
                hitY = false;
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


        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Summative___Breakout
{
    public class Paddle
    {
        public Texture2D _texture;
        public Rectangle _location;
        public Vector2 _speed;

        public Paddle(Texture2D texture, Rectangle loctaion)
        {
            _texture = texture;
            _location = loctaion;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }

        public void Update(KeyboardState keyboardState, Rectangle window)
        {
            _speed = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.A))
            {
                _speed.X = -4;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                _speed.X = 4;
            }
            if (_location.X <= window.X)
            {
                _location.X = window.X;
            }
            if (_location.X + _location.Width >= window.Width)
            {
                _location.X = window.Width - _location.Width;
            }
            _location.Offset(_speed);
        }
        public bool Intersects(Rectangle ball)
        {
            return _location.Intersects(ball);
        }
    }

}

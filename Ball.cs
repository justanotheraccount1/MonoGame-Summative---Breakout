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

        public Ball(Texture2D texture, Rectangle location, Vector2 speed)
        {
            _texture = texture;
            _location = location;
            _speed = speed;
            generator = new Random();
            xDirection = new Random();
            yDirection = new Random();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }

        public void Update()
        {
            if (xDirection.Next(2)  == 0)
            {
                if (yDirection.Next(2) == 0)
                {
                    _speed = new Vector2(-2, -2);
                }
                else
                {
                    _speed = new Vector2(-2, 2);
                }
            }
            else
            {
                if (yDirection.Next(2) == 0)
                {
                    _speed = new Vector2(2, -2);
                }
                else
                {
                    _speed = new Vector2(2, 2);
                }
            }

            _location.Offset(_speed);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MonoGame_Summative___Breakout
{
    enum Screen
    {
        Title,
        Game,
        Win,
        Lose
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Screen screen;
        KeyboardState keyboardState;
        Random generator = new Random();
        Texture2D blockTexture, paddleTexture, ballTexture, titleScreen;
        Rectangle window;
        List<Block> blocks = new List<Block>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            // TODO: Add your initialization logic here

            Color brickColor;

            base.Initialize();
            for (int x = 62; x < window.Width - 100; x += 45)
            {
                for (int y = 25; y < window.Height / 2; y += 20)
                {
                    if (y - 50 < 0)
                    {
                        brickColor = Color.Purple;
                    }
                    else if (y - 50 < 40)
                    {
                        brickColor = Color.Blue;
                    }
                    else if (y - 50 < 80)
                    {
                        brickColor = Color.Green;
                    }
                    else if (y - 50 < 120)
                    {
                        brickColor = Color.Yellow;
                    }
                    else if (y - 50 < 160)
                    {
                        brickColor = Color.Orange;
                    }
                    else
                    {
                        brickColor= Color.Red;
                    }
                        blocks.Add(new Block(blockTexture, new Rectangle(x, y, 40, 15), brickColor));
                }
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            blockTexture = Content.Load<Texture2D>("Images/rectangle (1)");
            paddleTexture = Content.Load<Texture2D>("Images/paddle");
            ballTexture = Content.Load<Texture2D>("Images/circle (1)");
            titleScreen = Content.Load<Texture2D>("Images/Breakout_OG-logo");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].Draw(_spriteBatch);
            }
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

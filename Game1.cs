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
        Texture2D blockTexture, paddleTexture, ballTexture, titleScreen, bottomTexture, lavaBG, wallTexture, breakingTexture, bowserTexture;
        Rectangle window, fullWindow, gameBG, wallRect;
        List<Block> blocks = new List<Block>();
        Ball ball;
        Paddle paddle;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0, 0, 800, 500);
            fullWindow = new Rectangle(0, 0, 800, 800);
            gameBG = new Rectangle(0, 0, 800, 1200);
            wallRect = new Rectangle(0, 500, 800, 50);
            _graphics.PreferredBackBufferWidth = fullWindow.Width;
            _graphics.PreferredBackBufferHeight = fullWindow.Height;
            _graphics.ApplyChanges();
            // TODO: Add your initialization logic here
            Color brickColor;
            base.Initialize();
            for (int x = 62; x < window.Width - 100; x += 45)
            {
                for (int y = 25; y < window.Height / 2; y += 20)
                {
                    
                    blocks.Add(new Block(blockTexture, new Rectangle(x, y, 40, 15), Color.DarkSlateGray));
                }
            }
            ball = new Ball(ballTexture, new Rectangle(390, 340, 20, 20));
            paddle = new Paddle(paddleTexture, new Rectangle(450, 480, 100, 10));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bottomTexture = Content.Load<Texture2D>("Images/rectangle (1)");
            blockTexture = Content.Load<Texture2D>("Images/blockBase");
            bowserTexture = Content.Load<Texture2D>("Images/bowser");
            breakingTexture = Content.Load<Texture2D>("Images/breakingTexture");
            paddleTexture = Content.Load<Texture2D>("Images/paddle");
            ballTexture = Content.Load<Texture2D>("Images/Retro Fire Ball");
            titleScreen = Content.Load<Texture2D>("Images/Breakout_OG-logo");
            wallTexture = Content.Load<Texture2D>("Images/bigWall");
            lavaBG = Content.Load<Texture2D>("Images/lavaBG");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            keyboardState = Keyboard.GetState();
            if (screen == Screen.Title)
            {
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    screen = Screen.Game;
                }
            }
            if (screen == Screen.Game)
            {
                ball.Update(window, blocks, paddle, gameTime);
                paddle.Update(keyboardState, window);
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin();
            if (screen == Screen.Title)
            {
                _spriteBatch.Draw(titleScreen, fullWindow, Color.Red);
                _spriteBatch.Draw(bowserTexture, new Rectangle(240, 160, 400, 200), Color.Red);
            }
            if (screen == Screen.Game)
            {
                _spriteBatch.Draw(lavaBG, gameBG, Color.White);
                for (int i = 0; i < blocks.Count; i++)
                {
                    blocks[i].Draw(_spriteBatch);
                }
                paddle.Draw(_spriteBatch);
                ball.Draw(_spriteBatch);
                if (ball.Health > 0)
                {
                    _spriteBatch.Draw(wallTexture, wallRect, Color.White);
                }
                if (ball.Health == 1)
                {
                    for (int x = 0; x < window.Width; x += wallRect.Height + 2)
                    {
                        _spriteBatch.Draw(breakingTexture, new Rectangle(x, wallRect.Y, wallRect.Height, wallRect.Height), Color.White);
                    }
                }
            }
            
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        Texture2D blockTexture, paddleTexture, ballTexture, titleScreen, bottomTexture, lavaBG, wallTexture, breakingTexture, bowserTexture, loseScreen, winScreen;
        Rectangle window, fullWindow, gameBG, wallRect;
        List<Block> blocks = new List<Block>();
        Ball ball;
        Paddle paddle;
        SoundEffect wallHit, blockHit, paddleHit, winSound, introSound, gameSound, loseSound;
        SoundEffectInstance wallHitInstance, blockHitInstance, paddleHitInstance, winSoundInstance, introSoundInstance, gameSoundInstance, loseSoundInstance;
        SpriteFont textFont;

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
            loseScreen = Content.Load<Texture2D>("Images/BowserFury");
            winScreen = Content.Load<Texture2D>("Images/winScreen");
            lavaBG = Content.Load<Texture2D>("Images/lavaBG");
            wallHit = Content.Load<SoundEffect>("Sounds/Thud");
            wallHitInstance = wallHit.CreateInstance();
            gameSound = Content.Load<SoundEffect>("Sounds/bossBattle");
            gameSoundInstance = gameSound.CreateInstance();
            gameSoundInstance.IsLooped = true;
            introSound = Content.Load<SoundEffect>("Sounds/introSong");
            introSoundInstance = introSound.CreateInstance();
            introSoundInstance.IsLooped = true;
            winSound = Content.Load<SoundEffect>("Sounds/WIN");
            winSoundInstance = winSound.CreateInstance();
            loseSound = Content.Load<SoundEffect>("Sounds/lOSE");
            loseSoundInstance = loseSound.CreateInstance();
            textFont = Content.Load<SpriteFont>("Fonts/gameFont");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            keyboardState = Keyboard.GetState();
            if (screen == Screen.Title)
            {
                introSoundInstance.Play();
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    screen = Screen.Game;
                }
            }
            if (screen == Screen.Game)
            {
                introSoundInstance.Stop();
                gameSoundInstance.Play();
                ball.Update(window, blocks, paddle, gameTime, wallHitInstance);
                paddle.Update(keyboardState, window);
                if (!fullWindow.Contains(ball.Rect))
                {
                    screen = Screen.Lose;
                }
                if (blocks.Count == 0)
                {
                    screen = Screen.Win;
                }
            }
            if (screen == Screen.Win)
            {
                introSoundInstance.Stop();
                gameSoundInstance.Stop();
                winSoundInstance.Play();
            }
            if (screen == Screen.Lose)
            {
                introSoundInstance.Stop();
                gameSoundInstance.Stop();
                loseSoundInstance.Play();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkRed);
            _spriteBatch.Begin();
            if (screen == Screen.Title)
            {
                _spriteBatch.Draw(titleScreen, fullWindow, Color.Red);
                _spriteBatch.Draw(bowserTexture, new Rectangle(240, 160, 400, 200), Color.Red);
                _spriteBatch.DrawString(textFont, "Hit Enter", new Vector2(200, 675), Color.Red);
            }
            if (screen == Screen.Game)
            {
                _spriteBatch.Draw(lavaBG, gameBG, Color.Gray);
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
            if (screen == Screen.Lose)
            {
                _spriteBatch.Draw(loseScreen, fullWindow, Color.DarkRed);
                _spriteBatch.DrawString(textFont, "You Lose", new Vector2(200, 450), Color.Red);
            }
            if (screen == Screen.Win)
            {
                _spriteBatch.Draw(winScreen, fullWindow, Color.White);
            }
                _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

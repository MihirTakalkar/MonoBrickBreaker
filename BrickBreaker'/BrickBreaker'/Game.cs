using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace BrickBreaker_
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont Tekton;
        List<Brick> bricks;
        Ball ball;
        Paddle paddle;
        int f;
        int n;
        int y = 145;
        bool pause = false;
        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ball = new Ball(new Vector2(1000, 900), Content.Load<Texture2D>("Ball"), new Vector2(12, 12), Color.White, new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            Texture2D paddleimage = Content.Load<Texture2D>("Paddle");
            paddle = new Paddle(new Vector2((GraphicsDevice.Viewport.Width - paddleimage.Width) / 2, (GraphicsDevice.Viewport.Height - paddleimage.Height)), paddleimage, 20, Color.White);
            Tekton = Content.Load<SpriteFont>("Tekton");
            bricks = new List<Brick>();
            for (int i = 0; i < 3; i++)
            {
                for (int g = 0; g < 12; g++)
                {
                    bricks.Add(new Brick(new Vector2(g * 160, y), Content.Load<Texture2D>("Brick"), Color.White));
                }
                y += 115;
            }
        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Left))
            {
                if (paddle.position.X > 0)
                {
                    paddle.position.X -= paddle.speedx;
                }
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                if (paddle.position.X < GraphicsDevice.Viewport.Width - paddle.image.Width)
                {
                    paddle.position.X += paddle.speedx;
                }
            }
            for (int x = 0; x < bricks.Count; x++)
            {
                if (bricks[x].hitbox.Intersects(ball.hitbox))
                {
                    bricks.RemoveAt(x);
                    ball.speed.Y *= -1;
                    n++;
                    break;
                }
            }
            if (ks.IsKeyDown(Keys.R))
            {
                f = 0;
                n = 0;
                ball.position.X = 1000;
                ball.position.Y = 900;
                paddle.position.X = (GraphicsDevice.Viewport.Width - paddle.image.Width) / 2;
                paddle.position.Y = (GraphicsDevice.Viewport.Height - paddle.image.Height);
                bricks = new List<Brick>();
                y = 145;
                for (int i = 0; i < 3; i++)
                {
                    for (int g = 0; g < 12; g++)
                    {
                        bricks.Add(new Brick(new Vector2(g * 160, y), Content.Load<Texture2D>("Brick"), Color.White));
                    }
                    y += 115;
                }
                    pause = false;
            }
            if (ball.position.Y > GraphicsDevice.Viewport.Height)
            {
                ball.position.X = 1000;
                ball.position.Y = 900;
                paddle.position.X = (GraphicsDevice.Viewport.Width - paddle.image.Width) / 2;
                paddle.position.Y = (GraphicsDevice.Viewport.Height - paddle.image.Height);
                f++;
            }
            // TODO: Add your update logic here
            if (paddle.hitbox.Intersects(ball.hitbox))
            {
                ball.speed.Y = -Math.Abs(ball.speed.Y);
            }
            if (!pause)
            {
                ball.Update();
                paddle.Update(GraphicsDevice);
                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            ball.Draw(spriteBatch);
            paddle.Draw(spriteBatch);
            for (int f = 0; f < bricks.Count; f++)
            {
                bricks[f].Draw(spriteBatch);
            }
            spriteBatch.DrawString(Tekton, $"Losses: {f}", new Vector2(30, 30), Color.Orange);
            if (f == 3)
            {
                spriteBatch.DrawString(Tekton, $"You Lose, Press R to Restart", new Vector2(1400, 30), Color.Orange);
                pause = true;

            }
            if (n == 36)
            {
                spriteBatch.DrawString(Tekton, $"You Win, Press R to Restart", new Vector2(1400, 30), Color.Orange);
                pause = true;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

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
        List<Brick> bricks;
        Ball ball;
        Paddle paddle;
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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ball = new Ball(new Vector2(30, 30), Content.Load<Texture2D>("Ball"), new Vector2(10, 10), Color.White, new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            Texture2D paddleimage = Content.Load<Texture2D>("Paddle");
            paddle = new Paddle(new Vector2((GraphicsDevice.Viewport.Width - paddleimage.Width) / 2, (GraphicsDevice.Viewport.Height - paddleimage.Height)), paddleimage, 5, Color.White);
            // TODO: use this.Content to load your game content here
            bricks = new List<Brick>();
            for (int i = 0; i <= 3;)
            {
                for (int g = 0; g < 12; g++)
                {
                  bricks.Add(new Brick(new Vector2(g * 160, 145), Content.Load<Texture2D>("Brick"), Color.White));
                    i++;
                }
                for(int t = 0; t < 12; t++)
                {
                    bricks.Add(new Brick(new Vector2(t * 160, 260), Content.Load<Texture2D>("Brick"), Color.White));
                }
                for (int z = 0; z < 12; z++)
                {
                    bricks.Add(new Brick(new Vector2(z * 160, 375), Content.Load<Texture2D>("Brick"), Color.White));
                }
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
                    paddle.position.X -= 7;
                }
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                if (paddle.position.X < GraphicsDevice.Viewport.Width - paddle.image.Width)
                {
                    paddle.position.X += 7;
                }
            }
            for (int x = 0; x < bricks.Count; x++)
            {
                if (bricks[x].hitbox.Intersects(ball.hitbox))
                {
                    bricks.RemoveAt(x);
                    ball.speed.Y *= -1;
                    break;
                }
            }


            // TODO: Add your update logic here
            if (paddle.hitbox.Intersects(ball.hitbox))
            {
                ball.speed.Y = -Math.Abs(ball.speed.Y);
            }
            ball.Update();
            paddle.Update(GraphicsDevice);
            base.Update(gameTime);
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
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}

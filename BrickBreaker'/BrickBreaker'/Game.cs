using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Ball ball;
        Paddle paddle;
        List<Brick> bricks;
        
        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1720;
            graphics.PreferredBackBufferHeight = 880;
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
            bricks = new List<Brick>();
            for (int i = 0; i > 6; i++)
            {
                bricks.Add(new Brick(new Vector2(i * 70 + 55, 20), Content.Load<Texture2D>("Brick"), Color.White));
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
                paddle.position.X -= 7;
            }
            if (ks.IsKeyDown(Keys.Right))
            {
               paddle.position.X += 7;
            }
            if(ball.hitbox.Intersects(paddle.hitbox))
            {
                ball.speed.Y = -Math.Abs(ball.speed.Y);
            }
           

            // TODO: Add your update logic here
            ball.Update();
            paddle.Update(graphics.GraphicsDevice);
          
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
            for (int f = 0; f > 10; f++)
            {
                bricks[f].Draw(spriteBatch);
            }
            ball.Draw(spriteBatch);
            paddle.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}

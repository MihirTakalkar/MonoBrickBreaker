using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_
{
    class Ball
    {
        //variables
        public Vector2 position;
        public Texture2D image;
        public Vector2 speed;
        public Color tint;
        public Vector2 bounds;
        public Rectangle hitbox;
        public bool IsDebugMode { get; set; } = true;
        private static Texture2D debugPixel;

        public Ball(Vector2 Position, Texture2D Image, Vector2 Speed, Color Tint, Vector2 Bounds)
        {
            position = Position;
            image = Image;
            speed = Speed;
            tint = Tint;
            bounds = Bounds;
            hitbox = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
            if (debugPixel == null)
            {
                debugPixel = new Texture2D(image.GraphicsDevice, 1, 1);
                debugPixel.SetData(new[] { Color.White });
            }
        }

        public void Update()
        {
            {
                position += speed;

                if (position.Y + image.Height > bounds.Y)
                {
                    speed.Y = -Math.Abs(speed.Y);
                    

                }
                if (position.X + image.Width > bounds.X)
                {
                    speed.X = -Math.Abs(speed.X);
             
                }
                if (position.X < 0)
                {
                    speed.X = Math.Abs(speed.X);
                
                }
                if (position.Y < 0)
                {
                    speed.Y = Math.Abs(speed.Y);

                }
                hitbox.X = (int)position.X;
                hitbox.Y = (int)position.Y;
            }

        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(image, position, tint);
            if (IsDebugMode)
            {
                batch.Draw(debugPixel, hitbox, Color.Orange * 0.5f);
            }
        }

    }
}

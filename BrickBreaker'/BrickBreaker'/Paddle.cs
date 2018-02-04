using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BrickBreaker_
{
    class Paddle
    {
        public Vector2 position;
        public Texture2D image;
        public Rectangle hitbox;
        public int speedx;
        public Color tint;

        public Paddle(Vector2 Position, Texture2D Image, int Speedx, Color Tint)
        {
            position = Position;
            image = Image;
            speedx = Speedx;
            tint = Tint;
            hitbox = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
        }

        public void Update(GraphicsDevice graphics)
        {
            if (position.X > 0)
            {
                position.X -= speedx;

            }
            if (position.X < graphics.Viewport.Width - image.Width)
            {
                position.X += speedx;

            }
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(image, position, tint);
        }
    }
}

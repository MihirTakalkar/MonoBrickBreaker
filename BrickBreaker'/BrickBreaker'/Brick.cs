using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_
{
    class Brick
    {
        public Vector2 position;
        public Texture2D image;
        public Color tint;
        public Rectangle hitbox;

        public Brick(Vector2 position, Texture2D image, Color tint)
        {
            this.position = position;
            this.image = image;
            this.tint = tint;
            hitbox = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spritebatch)
        {

        }
    }
}

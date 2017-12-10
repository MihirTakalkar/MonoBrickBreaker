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
    class PaddBrick
    {
        public Vector2 position;
        public Texture2D image;
        public int speedy;
        public Color tint;

        public PaddBrick(Vector2 Position, Texture2D Image, int Speedy, Color Tint)
        {
            position = Position;
            image = Image;
            speedy = Speedy;
            tint = Tint;
        }
        public void Update(GraphicsDevice graphics)
        {
         
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(image, position, tint);
        }

    }
}

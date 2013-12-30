using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Core.Handlers;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Buttons
{
    public class Button
    {
        protected Vector2 Position { get; set; }
        protected Texture2D Texture { get; set; }

        public Button(int X, int Y)
        {
            Position = new Vector2(X, Y);
        }

        virtual public void OnClick(object sender, MouseAgrs e){}

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Menu.Extensions;

namespace Menu.ListBox
{
    public class Monitor
    {
        public Rectangle Position { get; set; }
        ListBox Parent;
        Texture2D Texture;
        

        public Monitor(Rectangle position, ListBox parent)
        {
            Position = position;
            Parent = parent;
            Texture = TextureLoader.Monitor;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
            spriteBatch.DrawString(TextureLoader.Font, Parent.Value.ToString(), new Vector2(Position.X, Position.Y), Color.Red);
        }

    }
}

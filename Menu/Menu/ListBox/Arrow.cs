using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Core.Map;
using Microsoft.Xna.Framework.Graphics;
using Menu.Handlers;

namespace Menu.ListBox
{
    public class Arrow
    {
        public Rectangle Position { get; set; }
        Texture2D Texture;
        ListBox Parent;

        public delegate void Click(object sender, MouseAgrs e);

        Click A;

        public Arrow(Texture2D texture, Rectangle position, ListBox parent, Click click)
        {
            Parent = parent;
            Position = position;
            Texture = texture;
            A = click;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void OnClick(object sender, MouseAgrs e)
        {
            if (Position.Contains(e.Position))
                A(sender, e);
        }
    }
}

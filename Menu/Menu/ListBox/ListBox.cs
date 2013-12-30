using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Menu.Extensions;
using Microsoft.Xna.Framework.Graphics;
using Menu.Handlers;


namespace Menu.ListBox
{
    public class ListBox
    {
        public Rectangle Position { get; set; }
        public int Value { get; private set; }
        Arrow Up;
        Arrow Down;
        Monitor Monitor;

        public ListBox(Rectangle position, MouseHandler mouseHandler)
        {
            Position = position;
            Value = 10;
            Monitor = new Monitor(new Rectangle(position.X, position.Y, 2*Position.Width/3, position.Height), this);
            Up = new Arrow(TextureLoader.ArrowUp, new Rectangle(position.X + Monitor.Position.Width, position.Y, Position.Width / 3, position.Height / 2), this, delegate { this.Value++; });

            Down = new Arrow(TextureLoader.ArrowDown, new Rectangle(position.X + Monitor.Position.Width, position.Y + Up.Position.Height, Position.Width / 3, position.Height/2), this,  delegate { this.Value--; });
            mouseHandler.OnClick += Up.OnClick;
            mouseHandler.OnClick += Down.OnClick;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Monitor.Draw(spriteBatch);
            Up.Draw(spriteBatch);
            Down.Draw(spriteBatch);
        }

    }
}

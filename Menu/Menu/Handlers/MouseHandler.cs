using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Extensions;

namespace Menu.Handlers
{
    public class MouseHandler
    {
        MouseState previous;

        public event EventHandler<MouseAgrs> OnClick = delegate { };

        public MouseHandler()
        {
            previous = Mouse.GetState();
        }

        public void Update(GameTime gameTime)
        {
            var state = Mouse.GetState();
            if (state.LeftButton == ButtonState.Released &&
                previous.LeftButton == ButtonState.Pressed)
                    OnClick(this, new MouseAgrs(Key.Left));
            if (state.RightButton == ButtonState.Released &&
                previous.RightButton == ButtonState.Pressed)
                    OnClick(this, new MouseAgrs(Key.Right));
            previous = state;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }

    }
}

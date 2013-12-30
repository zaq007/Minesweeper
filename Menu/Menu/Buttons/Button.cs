using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Menu
{
    public class Button
    {
        Vector2 Position { get; set; }
        Texture2D texture;
        MouseState state, previous;
        
        public Button(int X, int Y, Texture2D texture)
        {
            Position = new Vector2(X, Y);
            this.texture = texture;
            previous = Mouse.GetState();
        }

        public void Update(GameTime gametime)
        {
            state = Mouse.GetState();
            if (state.LeftButton == ButtonState.Released &&
                previous.LeftButton == ButtonState.Pressed &&
                new Rectangle((int)Position.X, (int)Position.Y, (int)texture.Bounds.Width, (int)texture.Bounds.Height).Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)))
                    this.OnClick();
            previous = state;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }

        virtual public void OnClick()
        {

        }

    }
}

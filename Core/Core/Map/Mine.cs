using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Core.Handlers;
using Microsoft.Xna.Framework.Graphics;
using Core.Extensions;

namespace Core.Map
{
    public class Mine : GroundItem
    {
        public Mine(Point position)
        {
            Position = position;
            isClicked = false;
            isFlagged = false;
            isPressed = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (isClicked)
            {
                spriteBatch.Draw(TextureLoader.Opened, new Rectangle(Position.X * Ground.CellSize, Position.Y * Ground.CellSize, Ground.CellSize, Ground.CellSize), Color.White);
                spriteBatch.Draw(TextureLoader.Fun, new Rectangle(Position.X * Ground.CellSize, Position.Y * Ground.CellSize, Ground.CellSize, Ground.CellSize), Color.White);
            }
        }

   }
}

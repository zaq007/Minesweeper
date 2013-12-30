using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Handlers;
using Core.Extensions;

namespace Core.Map
{
    public class Cell : GroundItem
    {
        public int MineNumber { get; set; }

        public Cell(Point position)
        {
            MineNumber = -1;
            isClicked = false;
            isPressed = false;
            isFlagged = false;
            Position = position;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (isClicked)
            {
                spriteBatch.Draw(TextureLoader.Opened, new Rectangle(Position.X * Ground.CellSize, Position.Y * Ground.CellSize, Ground.CellSize, Ground.CellSize), Color.White);
                if (MineNumber > 0) spriteBatch.DrawString(TextureLoader.FDescr, MineNumber.ToString(), new Vector2(Position.X * Ground.CellSize+Ground.CellSize/4, Position.Y * Ground.CellSize), Color.Red);
            }            
        }

    }
}
 

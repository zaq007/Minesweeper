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
    public abstract class GroundItem
    {
        public bool isPressed { get; protected set; }
        public bool isClicked { get; protected set; }
        public bool isFlagged { get; protected set; } 
        public Point Position { get; protected set; }

        public virtual void Update(GameTime gametime)
        {

        }

        public void Flagging()
        {
            if (!this.isClicked) this.isFlagged = !this.isFlagged;
        }

        public void Open()
        {
            if (!this.isFlagged) this.isClicked = true;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!isClicked)
            {
                spriteBatch.Draw(TextureLoader.Cell, new Rectangle(Position.X * Ground.CellSize, Position.Y * Ground.CellSize, Ground.CellSize, Ground.CellSize), Color.White);
            }
            if (isFlagged)
                spriteBatch.Draw(TextureLoader.Flag, new Rectangle(Position.X * Ground.CellSize, Position.Y * Ground.CellSize, Ground.CellSize, Ground.CellSize), Color.White);
        }


    }
}

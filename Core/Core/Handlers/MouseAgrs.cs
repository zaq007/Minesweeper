using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Core.Map;

namespace Core.Handlers
{
    public class MouseAgrs : EventArgs
    {
        public Key ClickedKey { get; set; }
        public Point Position { get; set; }

        public MouseAgrs(Key key)
        {
            ClickedKey = key;
            Position = new Point(Mouse.GetState().X/Ground.CellSize, Mouse.GetState().Y/Ground.CellSize);
        }
    }
}

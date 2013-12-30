using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Menu.Extensions;

namespace Menu.Buttons
{
    public class Exit : Button
    {
        public Exit(int X, int Y, Texture2D texture)
            : base(X, Y, texture)
        {

        }
        override public void OnClick()
        {
            Return.Message = "Exit";
        }
    }
}

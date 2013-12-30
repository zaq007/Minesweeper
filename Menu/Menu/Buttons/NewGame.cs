using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Menu.Extensions;

namespace Menu.Buttons
{
    class NewGame : Button
    {
        public NewGame(int X, int Y, Texture2D texture)
            : base(X, Y, texture)
        {

        }

        public override void OnClick()
        {
            Return.Message = "New Game";
        }
    }
}

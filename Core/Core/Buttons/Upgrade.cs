using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Towers;
using Core.Controllers;
using Core.Handlers;
using Microsoft.Xna.Framework;
using Core.Extensions;

namespace Core.Buttons
{
    public class Upgrade : Button
    {
        Tower Tower;

        public Upgrade(int X, int Y, Tower tower)
            : base(X, Y)
        {
            Tower = tower;
            Texture = TextureLoader.Upgrade;
        }

        public override void OnClick(object sender, Handlers.MouseAgrs e)
        {
            if (e.ClickedKey == Key.Left && new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height).Contains(e.Position))
                Tower.Upgrade();
        }

    }
}

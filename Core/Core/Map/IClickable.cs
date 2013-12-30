using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Handlers;

namespace Core.Map
{
    public interface IClickable
    {

        void OnClick(object sender, MouseAgrs e);

    }
}

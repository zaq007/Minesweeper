using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Menu.Controllers
{
    class ButtonControler
    {
        List<Button> buttons;

        public ButtonControler()
        {
            buttons = new List<Button>();
        }

        public void NewButton(Button button)
        {
            buttons.Add(button);
        }

        public void Update(GameTime gametime)
        {
            foreach (var button in buttons)
                button.Update(gametime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var button in buttons)
                button.Draw(spriteBatch);
        }
    }
}

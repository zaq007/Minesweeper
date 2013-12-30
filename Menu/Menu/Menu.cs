using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Menu.Controllers;
using Menu.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Menu
{
    public class Menu
    {
        Controller controller;

        public Menu()
        {
            controller = new Controller();
        }

        public string Update(GameTime gametime)
        {
            Return.Message = "OK";
            controller.Update(gametime);
            return Return.Message;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLoader.Background, new Rectangle(0, 0, 800, 600), Color.White);
            controller.Draw(spriteBatch);
        }

        public int GetHeigth()
        {
            return controller.GetHeigth();
        }

        public int GetWidth()
        {
            return controller.GetWidth();
        }

        public int GetMines()
        {
            return controller.GetMines();
        }
        
    }
}

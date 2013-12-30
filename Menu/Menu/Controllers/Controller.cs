using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Menu.Buttons;
using Menu.Extensions;
using Core;
using Microsoft.Xna.Framework;
using Menu.Handlers;

namespace Menu.Controllers
{
    class Controller
    {
        ButtonControler buttonController;
        MouseHandler mouseHandler;
        ListBox.ListBox Height;
        ListBox.ListBox Width;
        ListBox.ListBox Mines;

        public Controller()
        {
            mouseHandler = new MouseHandler();
            buttonController = new ButtonControler();
            buttonController.NewButton(new NewGame(250, 100, TextureLoader.BtnNewGame));
            buttonController.NewButton(new Exit(250, 250, TextureLoader.BtnExit));
            Height = new ListBox.ListBox(new Rectangle(0, 0, 100, 50), mouseHandler);
            Width = new ListBox.ListBox(new Rectangle(0, 55, 100, 50), mouseHandler);
            Mines = new ListBox.ListBox(new Rectangle(0, 110, 100, 50), mouseHandler);
        }

        internal void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            buttonController.Update(gameTime);
            mouseHandler.Update(gameTime);
        }

        internal void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            buttonController.Draw(spriteBatch);
            Height.Draw(spriteBatch);
            Width.Draw(spriteBatch);
            Mines.Draw(spriteBatch);

        }

        public int GetHeigth()
        {
            return Height.Value;
        }

        public int GetWidth()
        {
            return Width.Value;
        }

        public int GetMines()
        {
            return Mines.Value;
        }
    }
}

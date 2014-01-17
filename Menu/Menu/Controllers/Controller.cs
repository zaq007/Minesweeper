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
            buttonController.NewButton(new NewGame(250, 150, TextureLoader.BtnNewGame));
            buttonController.NewButton(new Exit(250, 300, TextureLoader.BtnExit));
            Height = new ListBox.ListBox(new Rectangle(230, 100, 50, 25), mouseHandler, "Height");
            Width = new ListBox.ListBox(new Rectangle(380, 100, 50, 25), mouseHandler, "Width");
            Mines = new ListBox.ListBox(new Rectangle(530, 100, 50, 25), mouseHandler, "Mines");
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

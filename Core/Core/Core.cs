using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Extensions;

namespace Core
{
    public class Core
    {
        Controller controller;
        Game Game;

        public Core(Game game, SpriteBatch spriteBatch, int x, int y, int n)
        {
            Player.MinesNumber = n;
            controller = new Controller(x, y, n);
            Game = game;
        }

        public string Update(GameTime gameTime)
        {
            Return.Message = "OK";
            controller.Update(gameTime);
            return Return.Message;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            controller.Draw(spriteBatch);            
            spriteBatch.End();
        }
    }
}

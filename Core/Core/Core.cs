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
        RenderTarget2D target;
        RenderTarget2D shader;

        public Core(Game game, SpriteBatch spriteBatch, int x, int y, int n)
        {
            Player.MinesNumber = n;
            controller = new Controller(x, y, n);
            Game = game;
            target = new RenderTarget2D(game.GraphicsDevice, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);
            shader = new RenderTarget2D(game.GraphicsDevice, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);
        }

        public string Update(GameTime gameTime)
        {
            Return.Message = "OK";
            controller.Update(gameTime);
            return Return.Message;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Game.GraphicsDevice.SetRenderTarget(target);
            //Game.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, TextureLoader.Shader);
            controller.Draw(spriteBatch);
            
            spriteBatch.End();
        }
    }
}

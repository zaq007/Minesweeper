using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Core.Extensions;
using Core.Handlers;
using Core.Map;
using System.Timers;


namespace Core.Controllers
{
    public class Controller
    {
        MouseHandler mouseHandler;
        Ground ground;

        public Controller(int x, int y, int n)
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += delegate
            {
                Player.Time++;
            };
            timer.Start();
            mouseHandler = new MouseHandler();
            ground = new Ground(x, y, n, mouseHandler);
            mouseHandler.OnClick += ground.OnClick;
        }

        public void Update(GameTime gameTime)
        {
            ground.Update(gameTime);
            mouseHandler.Update(gameTime);            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(TextureLoader.Fun, new Rectangle(0, 0, 10 * Ground.CellSize, 10 * Ground.CellSize), Color.White);
            ground.Draw(spriteBatch);

        }

    }
}

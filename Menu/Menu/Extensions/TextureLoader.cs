using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Menu.Extensions
{
    public static class TextureLoader
    {
        private static ContentManager content;

        public static void Initialize(ContentManager contentManager)
        {
            content = contentManager;
        }

        private static Texture2D btnNewGame;
        public static Texture2D BtnNewGame
        {
            get
            {
                if (btnNewGame == null)
                    btnNewGame = content.Load<Texture2D>("New Game");
                return btnNewGame;
            }
        }

        private static Texture2D btnExit;
        public static Texture2D BtnExit
        {
            get
            {
                if (btnExit == null)
                    btnExit = content.Load<Texture2D>("Exit");
                return btnExit;
            }
        }

        private static Texture2D background;
        public static Texture2D Background
        {
            get
            {
                if (background == null)
                    background = content.Load<Texture2D>("Background");
                return background;
            }
        }

        private static Texture2D arrowUp;
        public static Texture2D ArrowUp
        {
            get
            {
                if (arrowUp == null)
                    arrowUp = content.Load<Texture2D>("ArrowUp");
                return arrowUp;
            }
        }

        private static Texture2D arrowDown;
        public static Texture2D ArrowDown
        {
            get
            {
                if (arrowDown == null)
                    arrowDown = content.Load<Texture2D>("ArrowDown");
                return arrowDown;
            }
        }

        private static Texture2D monitor;
        public static Texture2D Monitor
        {
            get
            {
                if (monitor == null)
                    monitor = content.Load<Texture2D>("Monitor");
                return monitor;
            }
        }

        private static SpriteFont font;
        public static SpriteFont Font
        {
            get
            {
                if (font == null)
                    font = content.Load<SpriteFont>("Font");
                return font;
            }
        }




    }
}

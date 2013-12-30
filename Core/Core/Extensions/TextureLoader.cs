using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;

namespace Core.Extensions
{
    public static class TextureLoader
    {
        private static ContentManager content;

        public static void Initialize(ContentManager contentManager)
        {
            content = contentManager;
        }

        private static Texture2D cell;
        public static Texture2D Cell
        {
            get
            {
                if (cell == null)
                    cell=content.Load<Texture2D>("cell");
                return cell;
            }

        }

        private static Texture2D opened;
        public static Texture2D Opened
        {
            get
            {
                if (opened == null)
                    opened = content.Load<Texture2D>("Opened");
                return opened;
            }

        }

        private static SpriteFont fDescr;
        public static SpriteFont FDescr
        {
            get
            {
                if (fDescr == null)
                    fDescr = content.Load<SpriteFont>("Descr_Font");
                return fDescr;
            }
        }

        private static Texture2D fun;
        public static Texture2D Fun
        {
            get
            {
                if (fun == null)
                    fun = content.Load<Texture2D>("fun");
                return fun;
            }
        }

        private static Texture2D flag;
        public static Texture2D Flag
        {
            get
            {
                if (flag == null)
                    flag = content.Load<Texture2D>("flag");
                return flag;
            }
        }

        private static Effect shader;
        public static Effect Shader
        {
            get
            {
                if (shader == null)
                {
                    shader = content.Load<Effect>("ring_halo");
                    StringBuilder a = new StringBuilder();
                    foreach (var b in shader.Parameters)
                        a.AppendLine(b.Name);
                    MessageBox.Show(a.ToString());
                }
                return shader;
            }
        }

    }
}

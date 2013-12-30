using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Core.Handlers;
using System.Windows.Forms;

namespace Core.Map
{
    public class Ground
    {
        public int MapWidth;
        public int MapHeight;
        public static int CellSize { get; private set;}
        GroundItem[,] Map { get; set; }
        public int MineNumber { get; set; }

        static Ground()
        {
            CellSize = 24;
        }

        public Ground(int heigth, int width, int number, MouseHandler mouseHandler)
        {
            MapWidth = width;
            MapHeight = heigth;
            Map = new GroundItem[width, heigth];
            while (number != 0)
            {
                Random a = new Random();
                int k = a.Next(heigth*width);
                if (Map[k % width, k / width] == null)
                {
                    Map[k % width, k / width] = new Mine(new Point(k % width, k / width));
                    number--;
                }
            }
            for (int i = 0; i < width; i++)
                for (int j = 0; j < heigth; j++)
                   if (Map[i, j]==null) 
                   {
                       Map[i, j] = new Cell(new Point(i, j));
                   }
        }

        public virtual void OnClick(object sender, MouseAgrs e)
        {
            if (e.ClickedKey == Key.Right)
                Map[e.Position.X, e.Position.Y].Flagging();
            if (e.ClickedKey == Key.Left)
                Open(e.Position.X, e.Position.Y);
        }

        public void Update(GameTime gameTime)
        {
            if (Map.OfType<Cell>().All(x => x.isClicked))
            {
                var a = MessageBox.Show(null, "Вы победили!\nВаше время - "+ Player.Time +" секунд.\nНачать сначала?", "Радость :)", MessageBoxButtons.YesNo);
                if (a == DialogResult.Yes)
                    Return.Message = "Retry";
                else Return.Message = "Exit";
            }
            if (Map.OfType<Mine>().Any(x => x.isClicked))
            {
                var a = MessageBox.Show(null, "Вы проиграли! :(\nВаше время - " + Player.Time + " секунд.\nНачать сначала?", "Печаль", MessageBoxButtons.YesNo);
                if (a == DialogResult.Yes)
                    Return.Message = "Retry";
                else Return.Message = "Exit";
            }
        }

        bool isMine(int i, int j)
        {
            if (i < 0 || i >= MapWidth || j < 0 || j >= MapHeight)
                return false;
            if (Map[i, j] is Mine)
                return true;
            else
                return false;
        }

        void OpenAll()
        {
            foreach (var a in Map.OfType<GroundItem>().Select<GroundItem, GroundItem>(x => x.isFlagged?x:null))
                if (a!=null) a.Flagging();
            foreach (var a in Map.OfType<GroundItem>())
                Open(a.Position.X, a.Position.Y);
        }
        
        void Open(int i, int j)
        {
            if (i < 0 || i >= MapWidth || j < 0 || j >= MapHeight)
                return;
            if (Map[i, j].isClicked || Map[i, j].isFlagged)
                return;
            if (Map[i, j] is Cell)
            {
                if (((Cell)Map[i, j]).MineNumber != -1)
                    return;
                    if (isMine(i-1, j-1))
                        ((Cell)Map[i, j]).MineNumber++;
                    if (isMine(i - 1, j))
                        ((Cell)Map[i, j]).MineNumber++;
                    if (isMine(i - 1, j + 1))
                        ((Cell)Map[i, j]).MineNumber++;
                    if (isMine(i, j - 1))
                        ((Cell)Map[i, j]).MineNumber++;
                    if (isMine(i, j + 1))
                        ((Cell)Map[i, j]).MineNumber++;
                    if (isMine(i + 1, j + 1))
                        ((Cell)Map[i, j]).MineNumber++;
                    if (isMine(i + 1, j - 1))
                        ((Cell)Map[i, j]).MineNumber++;
                    if (isMine(i + 1, j))
                        ((Cell)Map[i, j]).MineNumber++;
                    ((Cell)Map[i, j]).MineNumber++;
                    if (((Cell)Map[i, j]).MineNumber == 0)
                    {
                        Open(i - 1, j - 1);
                        Open(i - 1, j);
                        Open(i - 1, j + 1);
                        Open(i, j + 1);
                        Open(i, j - 1);
                        Open(i + 1, j + 1);
                        Open(i + 1, j - 1);
                        Open(i + 1, j);
                    }
                    
            }
            Map[i, j].Open();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in Map)
                item.Draw(spriteBatch);
        }

    }
}

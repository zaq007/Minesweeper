using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Extensions
{
    public static class Player
    {
        static public int MinesNumber { get; set; }
        static public int Time { get; set; }

        static Player()
        {
            Time = 0;
        }    
    }
}

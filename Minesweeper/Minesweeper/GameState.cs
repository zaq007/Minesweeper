using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    static class GameState
    {
        static string State;

        static GameState()
        {
            State = "Menu";
        }

        static public string getState()
        {
            return State;
        }

        static public void setState(string newState)
        {
            State = newState;
        }

    }
}

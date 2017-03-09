using Abstracts;
using System;
using System.Collections.Generic;

namespace ConsoleCade
{
    public class GameLoader
    {
        public IEnumerable<IGame> Games = null;
        public IList<IGame> GamesList = null;

        public GameLoader(IEnumerable<IGame> games)
        {
            Games = games;
            
        }

        public void LoadGames()
        {
            foreach (var game in Games)
            {
                //Console.WriteLine(_target.GetType());
                //Console.WriteLine("-----------------------------------");
                Console.WriteLine("Loaded Game: " + game.Name);
                Console.WriteLine(game.Description);
                Console.WriteLine("-----------------------------------");
            }
        }
    }
}

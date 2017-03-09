using System;

namespace Abstracts
{
    public abstract class GameBase
    {
        public virtual void UnLoad()
        {
            Console.WriteLine("Would you like to exit the game? y or n");
            string answer = Console.ReadLine();
            if (answer != "y")
            {
                Console.ReadLine();
            }
        }
    }
}
using System;
using System.Linq;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;

using Abstracts;
using ConsoleHotKey;
using System.Windows.Forms;
using System.IO;

namespace ConsoleCade
{
    public class ConsoleCade
    {
        private IGame _currentGame { get; set; }

        public void StartConsoleCade()
        {

            var container = ComposeHost();
            var gameLoader = container.GetExport<GameLoader>().Value;

            gameLoader.LoadGames();

            Console.WriteLine("Enter game index and hit enter");
            string gameIndexChoice = Console.ReadLine();

            Console.WriteLine($"Loading {gameIndexChoice}");

            //var theGame = gameLoader.Games.FirstOrDefault(g => g.Name == "Test Game");
            _currentGame = gameLoader.Games.ElementAt(int.Parse(gameIndexChoice));


            //also look into: http://stackoverflow.com/questions/5891538/listen-for-key-press-in-net-console-app
            // or: http://stackoverflow.com/questions/3382409/console-readkey-async-or-callback

            HotKeyManager.RegisterHotKey(Keys.A, KeyModifiers.Control, _currentGame);
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);


            http://stackoverflow.com/questions/5891538/listen-for-key-press-in-net-console-app

            Console.Clear();

            _currentGame.Load(); //send control to the game and comeback if they are done

            Console.Clear();
            Console.WriteLine("Your are back to the Main Console.");


            Console.ReadLine();
        }

        private static CompositionContainer ComposeHost()
        {
            var builder = new RegistrationBuilder();

            builder.ForTypesDerivedFrom<IGame>().Export<IGame>();
            builder.ForType<GameLoader>().Export();

            //Export types matching
            //builder.ForTypesMatching(x => x.Name.EndsWith("Game")).Export();

            var aggregateCatalog = new AggregateCatalog();

            //aggregateCatalog.Catalogs.Add(new DirectoryCatalog("Target", builder));

            aggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly, builder));

            //aggregateCatalog.Catalogs.Add(new DirectoryCatalog(@"C:\Users\RConnolly\Google Drive\dev\ConsoleCade\TestGame\bin\Debug"));
            //aggregateCatalog.Catalogs.Add(new DirectoryCatalog(@"C:\Users\RConnolly\Google Drive\dev\ConsoleCade\TestGame2\bin\Debug"));

            aggregateCatalog.Catalogs.Add(new DirectoryCatalog(Path.GetFullPath(@"..\..\Games")));

            var container = new CompositionContainer(aggregateCatalog);

            return container;
        }

        static void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            Console.WriteLine("HotKey Pressed!");
            e.CurrentGame.UnLoad();
        }
    }
}

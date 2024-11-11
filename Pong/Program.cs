using OpenTK.Windowing.GraphicsLibraryFramework;
using System;

namespace Pong {
    public class Program {
        public static void Main(string[] args) 
        {
            using (Game game = new Game(800, 600, "Maldito pong"))
            {
                game.Run();
            }

        }
    }
}
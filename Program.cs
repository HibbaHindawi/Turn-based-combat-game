using Turn_based_combat_game;

class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();

            Console.ReadKey();
        }
    }
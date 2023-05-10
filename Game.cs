namespace Turn_based_combat_game
{
    public class Game
{
    private Player player;
    private List<Enemy> enemies;
    private int currentEnemyIndex;

    public Game()
    {
        player = new Player("Player", 100, 10);
        enemies = new List<Enemy>
        {
            new Enemy("Goblin", 50, 5),
            new Enemy("Orc", 75, 8),
            new Enemy("Dragon", 200, 20)
        };
        currentEnemyIndex = 0;
    }

    public void Run()
    {
        while (player.IsAlive)
        {
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Check health");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Battle();
                    break;
                case "2":
                    Console.WriteLine($"Your health: {player.Health}/{player.MaxHealth}");
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }

        SaveScore();
        Console.WriteLine("Game over.");
    }

    private void Battle()
    {
        Console.WriteLine($"You encounter a {enemies[currentEnemyIndex].Name}.");

        while (player.IsAlive && enemies[currentEnemyIndex].IsAlive)
        {
            // Player attacks enemy
            player.Attack(enemies[currentEnemyIndex]);

            // Check if enemy is defeated
            if (!enemies[currentEnemyIndex].IsAlive)
            {
                Console.WriteLine($"You have defeated the {enemies[currentEnemyIndex].Name}.");
                player.Score += 10;
                currentEnemyIndex++;

                if (currentEnemyIndex >= enemies.Count)
                {
                    Console.WriteLine("You have defeated all the enemies!");
                    break;
                }
                else
                {
                    Console.WriteLine($"You encounter a {enemies[currentEnemyIndex].Name}.");
                }
            }
            else
            {
                // Enemy attacks player
                enemies[currentEnemyIndex].Attack(player);

                // Check if player is defeated
                if (!player.IsAlive)
                {
                    Console.WriteLine("You have been defeated.");
                    break;
                }
            }
        }
    }

    private void SaveScore()
    {
        string filename = "scores.txt";
        List<int> scores = new List<int>();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                if (int.TryParse(line, out int score))
                {
                    scores.Add(score);
                }
            }
        }

        scores.Add(player.Score);
        scores.Sort();
        scores.Reverse();
        scores = scores.Take(3).ToList();

        File.WriteAllLines(filename, scores.Select(s => s.ToString()).ToArray());
    }
}
}
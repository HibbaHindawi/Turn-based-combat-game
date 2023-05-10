namespace Turn_based_combat_game
{
    public class Player : Entity
{
    public int Score { get; set; }

    public Player(string name, int maxHealth, int attackPower) : base(name, maxHealth, attackPower)
    {
        Score = 0;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        Console.WriteLine($"You have {Health} health remaining.");
    }
}
}
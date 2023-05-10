namespace Turn_based_combat_game
{
    public abstract class Entity
    {
    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }

    public bool IsAlive => Health > 0;

    public Entity(string name, int maxHealth, int attackPower)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        AttackPower = attackPower;
    }

    public virtual void Attack(Entity target)
    {
        int damage = AttackPower;
        target.TakeDamage(damage);
        Console.WriteLine($"{Name} deals {damage} damage to {target.Name}.");
    }

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        if (!IsAlive)
        {
            Console.WriteLine($"{Name} has been defeated.");
        }
    }
}
}
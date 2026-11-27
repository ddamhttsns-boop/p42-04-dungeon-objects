// Монстр. Стоит на своей клетке и никуда не ходит.

public class Monster
{
    public string Name { get; }
    public char Symbol { get; }                 // каким символом рисуется на карте
    public int Health { get; private set; }
    public int Attack { get; }
    public int Armor { get; }                   // броня уменьшает урон от удара игрока
    public int Reward { get; }                  // сколько золота получает игрок за победу
    public int X { get; }
    public int Y { get; }

    public Monster(string name, char symbol, int health, int attack, int armor, int reward, int x, int y)
    {
        Name = name;
        Symbol = symbol;
        Health = health;
        Attack = attack;
        Armor = armor;
        Reward = reward;
        X = x;
        Y = y;
    }

    // Монстр жив, пока у него осталось здоровье. Монстр с 0 HP мёртв.
    public bool IsAlive => Health > 0;

    // Монстр получает урон. Здоровье не опускается ниже 0.
    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0)
            Health = 0;
    }
}

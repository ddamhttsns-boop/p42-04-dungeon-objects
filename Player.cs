// Игрок: где стоит, сколько у него здоровья и золота, что в руках и в сумке.

public class Player
{
    public const int MaxHealth = 20;            // здоровье в начале игры и его максимум
    public const int BaseAttack = 3;            // атака без оружия

    public int X { get; private set; }
    public int Y { get; private set; }
    public int Health { get; private set; }
    public int Gold { get; private set; }
    public Item Weapon { get; private set; }    // оружие в руках; null — оружия нет
    public Inventory Bag { get; }               // сумка с предметами

    public Player(int x, int y)
    {
        X = x;
        Y = y;
        Health = MaxHealth;
        Bag = new Inventory();
    }

    // Игрок жив, пока у него осталось здоровье.
    public bool IsAlive => Health > 0;

    // Атака игрока: своя атака плюс сила оружия в руках.
    public int Attack
    {
        get
        {
            if (Weapon == null)
                return BaseAttack;
            return BaseAttack + Weapon.Power;
        }
    }

    // Ставит игрока на клетку (x, y). Стены здесь не проверяются.
    public void MoveTo(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Игрок получает урон. Здоровье не опускается ниже 0.
    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0)
            Health = 0;
    }
    // Игрок лечится. Здоровье не поднимается выше MaxHealth.
    public void Heal(int amount)
    {
        Health += amount;
        if (Health > MaxHealth)
            Health = MaxHealth;
    }

    public void AddGold(int amount)
    {
        Gold += amount;
    }

    // Игрок платит amount золота. Если золота не хватает — возвращает false и ничего не списывает.
    public bool SpendGold(int amount)
    {
        if (amount > Gold)
            return false;
        Gold -= amount;
        return true;
    }

    // Берёт оружие в руки.
    public void Equip(Item weapon)
    {
        Weapon = weapon;
    }
}

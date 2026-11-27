// Сумка игрока: массив предметов на Capacity мест.
// Предметы лежат подряд с начала массива: занятые места — с 0 по Count - 1.

public class Inventory
{
    public const int Capacity = 5;              // сколько предметов помещается в сумку

    private readonly Item[] _items = new Item[Capacity];

    public int Count { get; private set; }      // сколько предметов сейчас в сумке

    public bool IsFull => Count == Capacity;

    // Кладёт предмет в сумку. Если места нет — возвращает false и ничего не меняет.
    public bool Add(Item item)
    {
        if (Count >= Capacity)
            return false;
        _items[Count] = item;
        Count++;
        return true;
    }

    // Предмет по индексу (индексы с 0). Если такого предмета нет — null.
    public Item Get(int index)
    {
        if (index < 0 || index >= Count)
            return null;
        return _items[index];
    }

    // Убирает предмет по индексу и возвращает его. Если такого предмета нет — null.
    // Остальные предметы сдвигаются влево, чтобы в сумке не было пустых мест.
    public Item RemoveAt(int index)
    {
        Item removed = Get(index);
        if (removed == null)
            return null;

        for (int i = index; i < Count - 1; i++)
            _items[i] = _items[i + 1];

        Count--;
        _items[Count] = null;
        return removed;
    }

    // Есть ли в сумке предмет такого вида (Item.Potion, Item.Weapon или Item.Key).
    public bool Has(string kind)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_items[i].Kind == kind)
                return true;
        }
        return false;
    }
}

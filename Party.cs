namespace TheFinalBattle;

public class Party
{
    public List<Character> Characters { get; } = new List<Character>();

    public List<Item> Items { get; } = new List<Item>();

    public List<Gear> Gear { get; } = new List<Gear>();

    public void AddCharacter(Character character) => Characters.Add(character);

    public void AddItem(Item item) => Items.Add(item);

    public void AddGear(Gear item) => Gear.Add(item);
}

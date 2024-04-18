namespace TheFinalBattle;


/// <summary>
/// A party of characters, items, and gear.
/// </summary>
public class Party
{
    /// <summary>
    /// List of characters in the party.
    /// </summary>
    public List<Character> Characters { get; } = new List<Character>();

    /// <summary>
    /// List of items in the party.
    /// </summary>
    public List<Item> Items { get; } = new List<Item>();

    /// <summary>
    /// List of gear in the party.
    /// </summary>
    public List<Gear> Gear { get; } = new List<Gear>();

    /// <summary>
    /// Adds a character to the party.
    /// </summary>
    /// <param name="character">The character to add.</param>
    public void AddCharacter(Character character) => Characters.Add(character);

    /// <summary>
    /// Adds an item to the party.
    /// </summary>
    /// <param name="item">The item to add.</param>
    public void AddItem(Item item) => Items.Add(item);

    /// <summary>
    /// Adds a gear to the party.
    /// </summary>
    /// <param name="item">The gear to add.</param>
    public void AddGear(Gear item) => Gear.Add(item);

    /// <summary>
    /// Checks if the party is dead.
    /// </summary>
    /// <returns>True if the party is dead, false otherwise.</returns>
    public bool IsDead() => Characters.Count == 0;

    /// <summary>
    /// Checks if the party has any items.
    /// </summary>
    /// <returns>True if the party has items, false otherwise.</returns>
    public bool HasItems() => Items.Count > 0;

    /// <summary>
    /// Checks if the party has any gear.
    /// </summary>
    /// <returns>True if the party has gear, false otherwise.</returns>
    public bool HasGear() => Gear.Count > 0;
}

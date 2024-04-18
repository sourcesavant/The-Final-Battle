namespace TheFinalBattle;

/// <summary>
/// Outputs text to the console.
/// </summary>
public class Renderer
{
    /// <summary>
    /// Prints a line of text to the console.
    /// </summary>
    /// <param name="text">The text to be printed.</param>
    public void PrintLine(string text)
    {
        Console.WriteLine(text);
    }

    /// <summary>
    /// Prints text to the console without a new line.
    /// </summary>
    /// <param name="text">The text to be printed.</param>
    public void Print(string text)
    {
        Console.Write(text);
    }

    /// <summary>
    /// Prints the status of the parties involved in the battle.
    /// </summary>
    /// <param name="heroes">The party of heroes.</param>
    /// <param name="monsters">The party of monsters.</param>
    public void PrintStatus(Party heroes, Party monsters)
    {
        Console.WriteLine("============================================= BATTLE ============================================");
        if (heroes != null)
            PrintPartyStatus(heroes);
        Console.WriteLine("---------------------------------------------- VS -----------------------------------------------");
        if (monsters != null)
            PrintPartyStatus(monsters);
        Console.WriteLine("=================================================================================================");
    }

    /// <summary>
    /// Prints the status of a party.
    /// 
    /// Status includes the characters in the party, HP, the gear equipped by each character, the items in the party's inventory, and the gear that is not equipped.
    /// </summary>
    /// <param name="party">The party to print the status of.</param>
    private void PrintPartyStatus(Party party)
    {
        foreach (Character character in party.Characters)
        {
            Console.WriteLine(character);
            if (character.Gear != null)
                Console.WriteLine($"Equipped gear: {character.Gear.Name}");
        }
        Console.WriteLine("Items:");
        foreach (Item item in party.Items)
            Console.WriteLine(item.Name);
        Console.WriteLine("Unequipped Gear:");
        foreach (Gear item in party.Gear)
            Console.WriteLine(item.Name);
    }

    /// <summary>
    /// Prints a menu with the provided list of menu items.
    /// </summary>
    /// <param name="menu">The list of menu items.</param>
    public void PrintMenu(List<MenuItem> menu)
    {
        for (int i = 0; i < menu.Count; i++)
            Console.WriteLine($"{i + 1} - {menu[i].Description}");
    }
}

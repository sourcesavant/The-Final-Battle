namespace TheFinalBattle;

public class Renderer
{
    public void PrintLine(string text)
    {
        Console.WriteLine(text);
    }

    public void Print(string text)
    {
        Console.Write(text);
    }

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

    private void PrintPartyStatus (Party party)
    {
        foreach (Character character in party.Characters)
            Console.WriteLine(character);
        Console.WriteLine("Items:");
        foreach (Item item in party.Items)
            Console.WriteLine(item.Name);
    }

    public void PrintMenu(List<MenuItem> menu)
    {
        for (int i = 0; i < menu.Count; i++)
            Console.WriteLine($"{i+1} - {menu[i].Description}");      
    }
}

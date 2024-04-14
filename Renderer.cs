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
        {
            foreach (Character character in heroes.Characters)
                Console.WriteLine(character);
        }
        Console.WriteLine("---------------------------------------------- VS -----------------------------------------------");
        if (monsters != null)
        {
            foreach (Character character in monsters.Characters)
                Console.WriteLine(character);
        }
        Console.WriteLine("=================================================================================================");
    }
}

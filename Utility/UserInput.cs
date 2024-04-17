namespace TheFinalBattle;

public class UserInput
{
    Renderer _renderer;
    
    public UserInput(Renderer renderer)
    {
        _renderer = renderer;
    }


    public string GetTrueProgammerName()
    {
        return AskForString("Enter the name of the True Programmer ");
    }

    public int GetMenuChoice(int menuItems)
    {
        return AskForInt("Choose an option ", 1, menuItems);
    }

    private void Prompt(string prompt)
    {
        _renderer.Print(prompt);
    }

    private string AskForString(string prompt)
    {
        while (true)
        {
            Prompt(prompt);
            string? input = Console.ReadLine();
            if (input != null)
                return input;
        }
    }

    private int AskForInt(string prompt, int min, int max)
    {
        int input;
        while(true)
        {
            Prompt(prompt);
            string inputString = Console.ReadLine();
            if (int.TryParse(inputString, out input) && input >= min && input <= max)
            {
                return input;
            }
            else
                _renderer.PrintLine($"Enter a number between {min} and {max}");
        }
    }
}

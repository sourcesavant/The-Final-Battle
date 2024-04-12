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
}

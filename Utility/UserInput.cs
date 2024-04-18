namespace TheFinalBattle;

/// <summary>
/// Handles user input.
/// </summary>
public class UserInput
{
    /// <summary>
    /// Renders output.
    /// </summary>
    Renderer _renderer;

    public UserInput(Renderer renderer)
    {
        _renderer = renderer;
    }

    /// <summary>
    /// Gets the name of the True Programmer from the user.
    /// </summary>
    /// <returns>The name of the True Programmer.</returns>
    public string GetTrueProgammerName()
    {
        return AskForString("Enter the name of the True Programmer ");
    }

    /// <summary>
    /// Gets the menu choice from the user.
    /// </summary>
    /// <param name="menuItems">The number of menu items.</param>
    /// <returns>The menu choice selected by the user.</returns>
    public int GetMenuChoice(int menuItems)
    {
        return AskForInt("Choose an option ", 1, menuItems);
    }

    /// <summary>
    /// Outputs a prompt.
    /// </summary>
    /// <param name="prompt"></param>
    private void Prompt(string prompt)
    {
        _renderer.Print(prompt);
    }

    /// <summary>
    /// Reads a string from the console.
    /// </summary>
    /// <param name="prompt"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Reads an integer from the console. The integer must be between min and max.
    /// </summary>
    /// <param name="prompt"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    private int AskForInt(string prompt, int min, int max)
    {
        int input;
        while (true)
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

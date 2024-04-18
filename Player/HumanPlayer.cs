namespace TheFinalBattle;

public class HumanPlayer : Player
{
    private readonly UserInput _userInput;

    /// <summary>
    /// Initializes a new instance of the <see cref="HumanPlayer"/> class.
    /// </summary>
    /// <param name="battle">The battle instance.</param>
    /// <param name="renderer">The renderer instance.</param>
    /// <param name="userInput">The user input instance.</param>
    public HumanPlayer(Battle battle, Renderer renderer, UserInput userInput) : base(battle, renderer)
    {
        _userInput = userInput;
    }

    /// <summary>
    /// Picks the action for the specified character based on user input and executes the action.
    /// </summary>
    /// <param name="character">The character.</param>
    /// <returns>The action to be executed.</returns>
    public override string PickAction(Character character)
    {
        Party enemy = _battle.GetEnemyPartyForCharacter(character);
        Character target = enemy.Characters.First();

        List<MenuItem> menu = BuildMenu(character);
        _renderer.PrintMenu(menu);

        int menuChoice = _userInput.GetMenuChoice(menu.Count());

        return menu[menuChoice - 1].Action.Execute(_battle);
    }

    /// <summary>
    /// Builds the menu for the specified character.
    /// </summary>
    /// <param name="character">The character.</param>
    /// <returns>The list of menu items.</returns>
    private List<MenuItem> BuildMenu(Character character)
    {
        Party enemy = _battle.GetEnemyPartyForCharacter(character);
        Character target = enemy.Characters.First();

        List<MenuItem> menu = new List<MenuItem>();
        menu.Add(new MenuItem($"Standard Attack ({GetStandardAttackName(character, target)})", GetStandardAttackAction(character, target)));

        if (character.Gear != null)
            menu.Add(new MenuItem($"Weapon Attack ({GetWeaponAttackName(character, target)})", GetWeaponAttackAction(character, target)));

        if (_battle.GetPartyForCharacter(character).Items.Any(item => item.GetType() == typeof(HealthPotion)))
        {
            menu.Add(new MenuItem($"Use Health Potion", new UseItem(new HealthPotion(), character)));
        }

        if (_battle.GetPartyForCharacter(character).Gear.Count > 0)
        {
            foreach (Gear gear in _battle.GetPartyForCharacter(character).Gear)
            {
                menu.Add(new MenuItem($"Equip Gear - {gear.Name}", new EquipGear(character, gear)));
            }
        }

        menu.Add(new MenuItem("Do Nothing", new SkipTurn(character)));

        return menu;
    }
}

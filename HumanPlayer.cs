namespace TheFinalBattle;

public class HumanPlayer : Player
{
    private readonly UserInput _userInput;
    public HumanPlayer(Battle battle, Renderer renderer, UserInput userInput) : base(battle, renderer)
    {
        _userInput = userInput;
    }

    public override string PickAction(Character character)
    {
        Party enemy = _battle.GetEnemyPartyFor(character);
        Character target = enemy.Characters.First();

        List<MenuItem> menu = BuildMenu(character);
        _renderer.PrintMenu(menu);

       int menuChoice = _userInput.GetMenuChoice(menu.Count());
                      
       return menu[menuChoice-1].Action.Execute(_battle);
    }

      private List<MenuItem> BuildMenu(Character character)
    {
        Party enemy = _battle.GetEnemyPartyFor(character);
        Character target = enemy.Characters.First();

        List<MenuItem> menu = new List<MenuItem>();
        menu.Add(new MenuItem($"Standard Attack ({GetAttackName(character)})", GetAttackAction(character, target)));
                
        if (_battle.GetPartyFor(character).Items.Any(item => item.GetType() == typeof(HealthPotion)))
        {
            menu.Add(new MenuItem($"Use Health Potion", new UseItem(new HealthPotion(), character)));
        }

        menu.Add(new MenuItem("Do Nothing", new SkipTurn(character)));
        
        return menu;
    }
}

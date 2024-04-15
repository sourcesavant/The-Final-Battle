namespace TheFinalBattle;

public class ComputerPlayer : Player
{
    private readonly Random _random = new Random();

    public ComputerPlayer(Battle battle, Renderer renderer) : base(battle, renderer) { }

    public override string PickAction(Character character)
    {
        Party party = _battle.GetPartyFor(character);
        if (party.Items.Any(item => item.GetType() == typeof(HealthPotion)) && character.HP < (float)character.MaxHP / 2)
        {
            if (_random.Next(4)  == 0)
            {
                return new UseItem(new HealthPotion(), character).Execute(_battle);
            }
        }
        
        Party enemy = _battle.GetEnemyPartyFor(character);
        Character target = enemy.Characters.First();
        return GetAttackAction(character, target).Execute(_battle);
    }
}

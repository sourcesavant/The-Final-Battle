namespace TheFinalBattle;

public class ComputerPlayer : Player
{
    public ComputerPlayer(Battle battle, Renderer renderer) : base(battle, renderer) { }

    public override string PickAction(Character character)
    {
        Party enemy = _battle.GetEnemyPartyFor(character);
        Character target = enemy.Characters.First();
        return GetAttackAction(character, target).Execute(_battle);
    }
}

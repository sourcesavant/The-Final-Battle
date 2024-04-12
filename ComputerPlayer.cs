namespace TheFinalBattle;

public class ComputerPlayer : Player
{
    public ComputerPlayer(Battle battle) : base(battle) { }

    public override string PickAction(Character character)
    {
        Party enemy = _battle.GetEnemyPartyFor(character);
        Character target = enemy.Characters.First();
        Attack attack = character switch
        {
            SKELETON       => new BoneCrunch(character, target),
            TheUncodedOne  => new Unraveling(character, target),
            TrueProgrammer => new Punch(character, target),
        };
        return attack.Execute(_battle);
    }
}

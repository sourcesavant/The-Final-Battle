namespace TheFinalBattle;

public abstract class Player
{
    protected Battle _battle;
    protected Renderer _renderer;
    
    public Player(Battle battle, Renderer renderer)
    {
        _battle = battle;
        _renderer = renderer;
    }

    public abstract string PickAction (Character character);

    protected IAction GetAttackAction (Character character, Character target) => character switch
    {
        SKELETON       => new BoneCrunch(character, target),
        TheUncodedOne  => new Unraveling(character, target),
        TrueProgrammer => new Punch(character, target),
        _              => throw new ArgumentOutOfRangeException()
    };

    protected string GetAttackName(Character character) =>  character switch
        {
            SKELETON       => BoneCrunch.AttackName,
            TheUncodedOne  => Unraveling.AttackName,
            TrueProgrammer => Punch.AttackName,
            _              => throw new ArgumentOutOfRangeException()
        };
}

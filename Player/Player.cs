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

    protected IAction GetStandardAttackAction (Character character, Character target) => character switch
    {
        SKELETON                      => new BoneCrunch(character, target),
        TheUncodedOne                 => new Unraveling(character, target),
        TrueProgrammer or VinFletcher => new Punch(character, target),
        _                             => throw new ArgumentOutOfRangeException()
    };

    protected IAction GetWeaponAttackAction(Character character, Character target) => character.Gear switch
    {
        Dagger  => new Stab(character, target),
        Sword   => new Slash(character, target),
        VinsBow => new QuickShot(character,  target),
        _       => throw new InvalidOperationException()
    };

    protected string GetStandardAttackName(Character character, Character target) =>  character switch
        {
            SKELETON                      => new BoneCrunch(character, target).AttackName,
            TheUncodedOne                 => new Unraveling(character, target).AttackName,
            TrueProgrammer or VinFletcher => new Punch(character, target).AttackName,
            _                             => throw new ArgumentOutOfRangeException()
        };

    protected string GetWeaponAttackName(Character character, Character target) => character.Gear switch
    {
        Dagger  => new Stab(character, target).AttackName,
        Sword   => new Slash(character, target).AttackName,
        VinsBow => new QuickShot(character, target).AttackName,
        _      => throw new InvalidOperationException()
    };
}

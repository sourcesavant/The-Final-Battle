namespace TheFinalBattle;

/// <summary>
/// Base class for player implementations.
/// </summary>
public abstract class Player
{
    protected Battle _battle;
    protected Renderer _renderer;

    /// <summary>
    /// Initializes a new instance of the <see cref="Player"/> class.
    /// </summary>
    /// <param name="battle">The battle handler .</param>
    /// <param name="renderer">The renderer.</param>
    public Player(Battle battle, Renderer renderer)
    {
        _battle = battle;
        _renderer = renderer;
    }

    /// <summary>
    /// Picks the action for the specified character.
    /// </summary>
    /// <param name="character">The character.</param>
    /// <returns>The action to be performed.</returns>
    public abstract string PickAction(Character character);

    /// <summary>
    /// Gets the standard attack action for the specified character and target.
    /// </summary>
    /// <param name="character">The character.</param>
    /// <param name="target">The target character.</param>
    /// <returns>The standard attack action.</returns>
    protected IAction GetStandardAttackAction(Character character, Character target) => character switch
    {
        SKELETON => new BoneCrunch(character, target),
        StoneAmarok => new Bite(character, target),
        TheUncodedOne => new Unraveling(character, target),
        TrueProgrammer or VinFletcher => new Punch(character, target),
        _ => throw new ArgumentOutOfRangeException()
    };

    /// <summary>
    /// Gets the weapon attack action for the specified character and target.
    /// </summary>
    /// <param name="character">The character.</param>
    /// <param name="target">The target character.</param>
    /// <returns>The weapon attack action.</returns>
    protected IAction GetWeaponAttackAction(Character character, Character target) => character.Gear switch
    {
        Dagger => new Stab(character, target),
        Sword => new Slash(character, target),
        VinsBow => new QuickShot(character, target),
        _ => throw new InvalidOperationException()
    };

    /// <summary>
    /// Gets the name of the standard attack for the specified character and target.
    /// </summary>
    /// <param name="character">The character.</param>
    /// <param name="target">The target character.</param>
    /// <returns>The name of the standard attack.</returns>
    protected string GetStandardAttackName(Character character, Character target) => character switch
    {
        StoneAmarok => new Bite(character, target).AttackName,
        SKELETON => new BoneCrunch(character, target).AttackName,
        TheUncodedOne => new Unraveling(character, target).AttackName,
        TrueProgrammer or VinFletcher => new Punch(character, target).AttackName,
        _ => throw new ArgumentOutOfRangeException()
    };

    /// <summary>
    /// Gets the name of the weapon attack for the specified character and target.
    /// </summary>
    /// <param name="character">The character.</param>
    /// <param name="target">The target character.</param>
    /// <returns>The name of the weapon attack.</returns>
    protected string GetWeaponAttackName(Character character, Character target) => character.Gear switch
    {
        Dagger => new Stab(character, target).AttackName,
        Sword => new Slash(character, target).AttackName,
        VinsBow => new QuickShot(character, target).AttackName,
        _ => throw new InvalidOperationException()
    };
}

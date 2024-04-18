namespace TheFinalBattle;

/// <summary>
/// Represents a character in the game.
/// </summary>
public abstract class Character
{
    /// <summary>
    /// Name of the character.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Maximum HP of the character.
    /// </summary>
    public abstract int MaxHP { get; }

    /// <summary>
    /// Gear of the character.
    /// </summary>
    public Gear? Gear { get; set; } = null;

    /// <summary>
    /// Defensive attack modifier of the character.
    /// </summary>
    public DefensiveAttackModifier? DefensiveAttackModifier { get; init; }

    private int _HP;

    /// <summary>
    /// Current HP of the character. It is clamped between 0 and <see cref="MaxHP"/>.
    /// </summary>
    public int HP
    {
        get => _HP;
        set
        {
            if (value < 0)
                _HP = 0;
            else if (value > MaxHP)
                _HP = MaxHP;
            else
                _HP = value;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Character"/> class.
    /// </summary>
    public Character()
    {
        _HP = MaxHP;
    }

    /// <summary>
    /// Checks if the character is dead.
    /// </summary>
    /// <returns><c>true</c> if the character is dead; otherwise, <c>false</c>.</returns>
    public bool IsDead() => _HP == 0;

    /// <summary>
    /// Checks if the character has gear.
    /// </summary>
    /// <returns><c>true</c> if the character has gear; otherwise, <c>false</c>.</returns>
    public bool HasGear() => Gear != null;

    /// <summary>
    /// Executes the specified action in the battle.
    /// </summary>
    /// <param name="battle">The battle.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>The result of the action execution.</returns>
    public string DoAction(Battle battle, IAction action)
    {
        return action.Execute(battle);
    }

    /// <summary>
    /// Returns a string that represents the character. The string contains the name and the current HP of the character.
    /// </summary>
    /// <returns>A string that represents the character.</returns>
    public override string ToString() => $"{Name} ( {HP}/{MaxHP} )";
}

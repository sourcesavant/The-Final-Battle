using System.Text;
namespace TheFinalBattle;

/// <summary>
/// Base class for all attacks.
/// </summary>
public abstract class Attack : IAction
{
    /// <summary>
    /// Name of the attack, used for output.
    /// </summary>
    public virtual string AttackName { get; } = "ATTACK";

    /// <summary>
    /// Hit chance of the attack, default is 100.
    /// </summary>
    protected virtual double _hitChance { get; } = 1;

    /// <summary>
    /// Damage type of the attack, default is DamageType.Normal.
    /// </summary>
    protected virtual DamageType _damageType { get; } = DamageType.Normal;

    /// <summary>
    /// The source character of the attack.
    /// </summary>
    private readonly Character _source;
    /// <summary>
    /// The target character of the attack.
    /// </summary>
    private readonly Character _target;

    /// <summary>
    /// Initializes a new instance of the <see cref="Attack"/> class.
    /// </summary>
    /// <param name="source">The source character.</param>
    /// <param name="target">The target character.</param>
    public Attack(Character source, Character target)
    {
        _source = source;
        _target = target;
    }

    /// <summary>
    /// Executes the attack.
    /// </summary>
    /// <param name="battle">The battle context.</param>
    /// <returns>Description of the result of the attack.</returns>
    public string Execute(Battle battle)
    {
        StringBuilder sb = new StringBuilder();
        sb = HandleAttack(battle, sb);

        return sb.ToString();
    }

    /// <summary>
    /// Handles the attack.
    /// Checks if the attack is successful, calculates the damage and applies it to the target.
    /// Checks if the target is dead and handles the kill.
    /// </summary>
    /// <param name="battle"></param>
    /// <param name="sb"></param>
    /// <returns></returns>
    private StringBuilder HandleAttack(Battle battle, StringBuilder sb)
    {
        sb.AppendLine($"{_source.Name} used {AttackName} on {_target.Name}.");

        if (!IsAttackSuccessful())
        {
            sb.AppendLine($"{_source.Name} MISSED!");
        }
        else
        {
            HandleDamage(sb);
            if (_target.IsDead())
                sb = HandleKill(battle, sb);
            else
                sb.AppendLine($"{_target.Name} is now at {_target.HP}/{_target.MaxHP} HP.");
        }

        return sb;
    }

    /// <summary>
    /// Handles the damage calculation and applies it to the target.
    /// Checks if the target has a defensive attack modifier and applies it.
    /// </summary>
    /// <param name="sb"></param>
    private void HandleDamage(StringBuilder sb)
    {
        int dmg = CalculateDamage();
        int modifiedDmg = dmg - GetDefensiveAttackModifier();
        if (modifiedDmg != dmg)
            sb.AppendLine($"{_target.DefensiveAttackModifier.Name} reduced the attack by {dmg - modifiedDmg} point(s).");

        _target.HP -= modifiedDmg;
    }

    /// <summary>
    /// Handles the kill of the target character.
    /// Transfers gear from the target to the source character's party.
    /// </summary>
    /// <param name="battle"></param>
    /// <param name="sb"></param>
    /// <returns></returns>
    private StringBuilder HandleKill(Battle battle, StringBuilder sb)
    {
        sb.AppendLine($"{_target.Name} has been defeated!");
        sb = TransferGearAfterCharacterKill(battle, sb);

        Party enemyParty = battle.GetPartyForCharacter(_target);
        enemyParty.Characters.Remove(_target);

        if (!enemyParty.IsDead())
            return sb;

        sb = TransferGearAfterPartyKill(battle, sb, enemyParty);
        sb = TransferItemsAfterPartyKill(battle, sb, enemyParty);
        return sb;
    }

    /// <summary>
    /// Returns the defensive attack modifier of the target character if it is of the same damage type as the attack.
    /// If not, returns 0.
    /// </summary>
    /// <returns></returns>
    private int GetDefensiveAttackModifier() => _target.DefensiveAttackModifier != null && _target.DefensiveAttackModifier.DamageTypeResistance == _damageType
                                              ? _target.DefensiveAttackModifier.Modifier
                                              : 0;

    /// <summary>
    /// Transfers items from the target party to the source party after the target party has been killed.
    /// </summary>
    /// <param name="battle"></param>
    /// <param name="sb"></param>
    /// <param name="party"></param>
    /// <returns></returns>
    private StringBuilder TransferItemsAfterPartyKill(Battle battle, StringBuilder sb, Party party)
    {
        if (party.HasItems())
        {
            sb.Append("Items acquired ");
            foreach (Item item in party.Items)
            {
                battle.GetPartyForCharacter(_source).Items.Add(item);
                sb.Append($"{item.Name}");
            }
        }
        return sb;
    }

    /// <summary>
    /// Transfers gear from the target party to the source party after the target party has been killed.
    /// </summary>
    /// <param name="battle"></param>
    /// <param name="sb"></param>
    /// <param name="party"></param>
    /// <returns></returns>
    private StringBuilder TransferGearAfterPartyKill(Battle battle, StringBuilder sb, Party party)
    {
        if (party.HasGear())
        {
            sb.Append("Gear acquired ");
            foreach (Gear gear in party.Gear)
            {
                sb.Append($"{gear.Name}");
                battle.GetPartyForCharacter(_source).Gear.Add(gear);
            }
            sb.AppendLine();
        }
        return sb;
    }

    /// <summary>
    /// Transfers gear from the target character to the source character after the target character has been killed.
    /// </summary>
    /// <param name="battle"></param>
    /// <param name="sb"></param>
    /// <returns></returns>
    private StringBuilder TransferGearAfterCharacterKill(Battle battle, StringBuilder sb)
    {
        if (_target.HasGear())
        {
            battle.GetPartyForCharacter(_source).Gear.Add(_target.Gear);
            sb.AppendLine($"{_source.Name} aquired {_target.Gear.Name}.");
        }
        return sb;
    }

    /// <summary>
    /// Checks if the attack is successful.
    /// Uses a random number generator to determine if the attack is successful according to the hit chance.
    /// </summary>
    /// <returns></returns>
    protected bool IsAttackSuccessful() => new Random().NextDouble() < _hitChance;

   /// <summary>
   /// Calculates the damage of the attack.
   /// </summary>
   /// <returns></returns>
    protected abstract int CalculateDamage();
}

namespace TheFinalBattle;

/// <summary>
/// Unraveling attack. Deals random damage between 0 and 9.
/// </summary>
public class Unraveling : Attack
{
    public override string AttackName { get; } = "UNRAVELING ATTACK";

    public Unraveling(Character source, Character target) : base(source, target) { }

    protected override DamageType _damageType { get; } = DamageType.Decoding;

    protected override int CalculateDamage()
    {
        Random random = new Random();
        return random.Next(10);
    }
}

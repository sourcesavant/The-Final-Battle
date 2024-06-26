﻿namespace TheFinalBattle;

/// <summary>
/// Punch attack. Deals 1 damage.
/// </summary>
public class Punch : Attack
{
    public override string AttackName { get; } = "PUNCH";
    
    public Punch(Character source, Character target) : base(source, target) { }

    protected override int CalculateDamage()
    {
        return 1;
    }
}

﻿namespace TheFinalBattle;

public class Unraveling : Attack
{
    public static new string AttackName { get; } = "UNRAVELING ATTACK";

    public Unraveling(Character source, Character target) : base(source, target) { }

    protected override int GetDamage()
    {
        Random random = new Random();
        return random.Next(3);
    }
}

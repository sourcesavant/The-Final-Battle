﻿namespace TheFinalBattle;

public class TrueProgrammer : Character
{
    public override string Name { get; }

    public TrueProgrammer(string name)
    {
        Name = name;
    }
    
    public override string PickAction(Battle battle)
    {
        return DoAction(battle, new SkipTurn());
    }
}
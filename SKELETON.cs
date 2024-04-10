namespace TheFinalBattle;

public class SKELETON : Character
{
    public override string Name { get; } = "SKELETON";

    public override string pickAction(Battle battle)
    {
        return doAction(battle, new SkipTurn());
    }
}

namespace TheFinalBattle;

public class SKELETON : Character
{
    public override string Name { get; } = "SKELETON";

    public override string PickAction(Battle battle)
    {
        return DoAction(battle, new SkipTurn());
    }
}

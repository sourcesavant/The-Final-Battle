namespace TheFinalBattle;

public class ComputerPlayer : IPlayer
{
    public IAction PickAction()
    {
        return new SkipTurn();
    }
}

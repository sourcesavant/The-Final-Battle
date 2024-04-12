namespace TheFinalBattle;

public abstract class Player
{
    protected Battle _battle;
    
    public Player(Battle battle)
    {
        _battle = battle;
    }

    public abstract string PickAction(Character character);
}

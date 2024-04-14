namespace TheFinalBattle;

public abstract class Player
{
    protected Battle _battle;
    protected Renderer _renderer;
    
    public Player(Battle battle, Renderer renderer)
    {
        _battle = battle;
        _renderer = renderer;
    }

    public abstract string PickAction(Character character);
}

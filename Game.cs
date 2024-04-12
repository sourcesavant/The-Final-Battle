namespace TheFinalBattle;

public class Game
{
    private Battle _battle;

    public Game(Battle battle)
    {
        _battle = battle;
    }

    public void Run()
    {
        while (true) 
        {
            _battle.doRound();
            Thread.Sleep(500);
        }
    }
}

namespace TheFinalBattle;

public class Game
{
    private Battle _battle;

    public Game(Battle battle)
    {
        _battle = battle;
    }

    public void run()
    {
        while (true) 
        {
            _battle.doRound();
            Thread.Sleep(500);
        }
    }
}

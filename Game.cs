namespace TheFinalBattle;

public class Game
{
    private Battle _battle;
    private Renderer _renderer;

    public Game(Battle battle, Renderer renderer)
    {
        _battle = battle;
        _renderer = renderer;
    }

    public void Run()
    {
        while (true) 
        {
            _battle.DoRound();
            if (_battle.HeroesParty.Characters.Count() > 0 && _battle.MonstersParty.Characters.Count() == 0)
            {
                _renderer.PrintLine("The heroes won. The Uncoded One was defeated.");
                break;
            }
            else if (_battle.HeroesParty.Characters.Count() == 0 && _battle.MonstersParty.Characters.Count() > 0)
            {
                _renderer.PrintLine("The heroes lost. The Uncoded One's forces have prevailed.");
                break;
            }

            Thread.Sleep(500);
        }
    }
}

namespace TheFinalBattle;

public abstract class Attack : IAction
{
    public virtual string AttackName { get;  } = "ATTACK";
    private Character _source;
    private Character _target;

    public Attack(Character source, Character target)
    {
        _source = source;
        _target = target;
    }

    public string Execute(Battle battle)
    {
        return GetDescription();
    }

    private string GetDescription()
    {
        return $"{_source.Name} used {AttackName} on {_target.Name}.";
    }
}

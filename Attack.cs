using System.Text;

namespace TheFinalBattle;

public abstract class Attack : IAction
{
    public string AttackName { get; init; } = "ATTACK";
    private Character _source;
    private Character _target;

    public Attack(Character source, Character target)
    {
        _source = source;
        _target = target;
    }

    public string Execute(Battle battle)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{_source.Name} used {AttackName} on {_target.Name}.");
        int dmg = GetDamage();
        _target.HP -= dmg;
        if (_target.HP == 0)
        {
            sb.AppendLine($"{_target.Name} has been defeated!");
            Party party = battle.GetPartyFor(_target);
            party.Characters.Remove(_target);
        }
        else
            sb.AppendLine($"{_target.Name} is now at {_target.HP}/{_target.MaxHP} HP.");
        return sb.ToString();
    }

    protected abstract int GetDamage();
}

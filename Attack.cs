using System.Text;

namespace TheFinalBattle;

public abstract class Attack : IAction
{
    public virtual string AttackName { get; } = "ATTACK";
    private readonly Character _source;
    private readonly Character _target;

    public Attack(Character source, Character target)
    {
        _source = source;
        _target = target;
    }

    public string Execute(Battle battle)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{_source.Name} used {AttackName} on {_target.Name}.");
        int dmg = CalculateDamage();
        _target.HP -= dmg;
        if (_target.HP == 0)
            sb = HandleKill(battle, sb);
        else
            sb.AppendLine($"{_target.Name} is now at {_target.HP}/{_target.MaxHP} HP.");
        return sb.ToString();
    }

    private StringBuilder HandleKill(Battle battle, StringBuilder sb)
    {
        sb.AppendLine($"{_target.Name} has been defeated!");
        sb = TransferGearAfterCharacterKill(battle, sb);

        Party enemyParty = battle.GetPartyFor(_target);
        enemyParty.Characters.Remove(_target);

        if (enemyParty.Characters.Count != 0)
            return sb;

        sb = TransferGearAfterPartyKill(battle, sb, enemyParty);
        sb = TransferItemsAfterPartyKill(battle, sb, enemyParty);
        return sb;
    }

    private StringBuilder TransferItemsAfterPartyKill(Battle battle, StringBuilder sb, Party party)
    {
        if (party.Items.Count > 0)
        {
            sb.Append("Items acquired ");
            foreach (Item item in party.Items)
            {
                battle.GetPartyFor(_source).Items.Add(item);
                sb.Append($"{item.Name}");
            }
        }
        return sb;
    }

    private StringBuilder TransferGearAfterPartyKill(Battle battle, StringBuilder sb, Party party)
    {
        if (party.Gear.Count > 0)
        {
            sb.Append("Gear acquired ");
            foreach (Gear gear in party.Gear)
            {
                sb.Append($"{gear.Name}");
                battle.GetPartyFor(_source).Gear.Add(gear);
            }
            sb.AppendLine();
        }
        return sb;
    }

    private StringBuilder TransferGearAfterCharacterKill(Battle battle, StringBuilder sb)
    {
        if (_target.Gear != null)
        {
            battle.GetPartyFor(_source).Gear.Add(_target.Gear);
            sb.AppendLine($"{_source.Name} aquired {_target.Gear.Name}.");
        }
        return sb;
    }

    protected abstract int CalculateDamage();
}

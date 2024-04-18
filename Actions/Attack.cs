using System.Text;

namespace TheFinalBattle;

public abstract class Attack : IAction
{
    public virtual string AttackName { get; } = "ATTACK";
    protected virtual double _hitChance { get;  } = 1;
    protected virtual DamageType _damageType { get; } = DamageType.Normal;
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
        sb = HandleAttack(battle, sb);

        return sb.ToString();
    }

    private StringBuilder HandleAttack(Battle battle, StringBuilder sb)
    {
        sb.AppendLine($"{_source.Name} used {AttackName} on {_target.Name}.");
        
        if (!IsAttackSuccessful())
        {
            sb.AppendLine($"{_source.Name} MISSED!");
        }
        else
        {
            HandleDamage(sb);
            if (_target.IsDead())
                sb = HandleKill(battle, sb);
            else
                sb.AppendLine($"{_target.Name} is now at {_target.HP}/{_target.MaxHP} HP.");
        }

        return sb;
    }

    private void HandleDamage(StringBuilder sb)
    {
        int dmg = CalculateDamage();
        int modifiedDmg = dmg - GetDefensiveAttackModifier();
        if (modifiedDmg != dmg)
            sb.AppendLine($"{_target.DefensiveAttackModifier.Name} reduced the attack by {dmg - modifiedDmg} point(s).");

        _target.HP -= modifiedDmg;
    }

    private StringBuilder HandleKill(Battle battle, StringBuilder sb)
    {
        sb.AppendLine($"{_target.Name} has been defeated!");
        sb = TransferGearAfterCharacterKill(battle, sb);

        Party enemyParty = battle.GetPartyForCharacter(_target);
        enemyParty.Characters.Remove(_target);

        if (!enemyParty.IsDead())
            return sb;

        sb = TransferGearAfterPartyKill(battle, sb, enemyParty);
        sb = TransferItemsAfterPartyKill(battle, sb, enemyParty);
        return sb;
    }

    private int GetDefensiveAttackModifier() => _target.DefensiveAttackModifier != null && _target.DefensiveAttackModifier.DamageTypeResistance == _damageType 
                                              ? _target.DefensiveAttackModifier.Modifier
                                              : 0;
    
        

    private StringBuilder TransferItemsAfterPartyKill(Battle battle, StringBuilder sb, Party party)
    {
        if (party.HasItems())
        {
            sb.Append("Items acquired ");
            foreach (Item item in party.Items)
            {
                battle.GetPartyForCharacter(_source).Items.Add(item);
                sb.Append($"{item.Name}");
            }
        }
        return sb;
    }

    private StringBuilder TransferGearAfterPartyKill(Battle battle, StringBuilder sb, Party party)
    {
        if (party.HasGear())
        {
            sb.Append("Gear acquired ");
            foreach (Gear gear in party.Gear)
            {
                sb.Append($"{gear.Name}");
                battle.GetPartyForCharacter(_source).Gear.Add(gear);
            }
            sb.AppendLine();
        }
        return sb;
    }

    private StringBuilder TransferGearAfterCharacterKill(Battle battle, StringBuilder sb)
    {
        if (_target.HasGear())
        {
            battle.GetPartyForCharacter(_source).Gear.Add(_target.Gear);
            sb.AppendLine($"{_source.Name} aquired {_target.Gear.Name}.");
        }
        return sb;
    }

    protected bool IsAttackSuccessful() => new Random().NextDouble() < _hitChance;

    protected abstract int CalculateDamage();
}

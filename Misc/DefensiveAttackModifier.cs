namespace TheFinalBattle;

public record DefensiveAttackModifier(string Name, int Modifier = 0, DamageType DamageTypeResistance = DamageType.Normal);

public record StoneArmor(string Name = "STONE ARMOR", int Modifier = 1, DamageType DamageTypeResistance = DamageType.Normal) : DefensiveAttackModifier(Name, Modifier, DamageTypeResistance);

public record ObjectSight(string Name = "OBJECT SIGHT", int Modifier = 2, DamageType DamageTypeResistance = DamageType.Decoding) : DefensiveAttackModifier(Name, Modifier, DamageTypeResistance);
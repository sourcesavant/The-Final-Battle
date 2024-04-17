namespace TheFinalBattle;

public record DefensiveAttackModifier(string Name, int Modifier = 0);

public record StoneArmor(string Name = "STONE ARMOR", int Modifier = 1) : DefensiveAttackModifier(Name, Modifier);
namespace TheFinalBattle;

public record Item(string Name);

public record HealthPotion(string Name = "Health Potion") : Item(Name);

public record MenuItem(string Description, IAction Action);

public record Gear(string Name);

public record Sword(string Name = "Sword") : Gear(Name);

public record Dagger(string Name = "Dagger") : Gear(Name);
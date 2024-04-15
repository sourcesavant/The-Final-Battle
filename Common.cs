namespace TheFinalBattle;

public record Item(string Name);

public record HealthPotion(string Name = "Health Potion") : Item(Name);

public record MenuItem(string Description, IAction Action);
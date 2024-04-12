using TheFinalBattle;

Renderer renderer = new Renderer();

Party heroes = new();
Party monsters = new();
heroes.Add(new SKELETON());
monsters.Add(new SKELETON());

Battle battle = new (heroes, monsters, renderer);
Game game = new Game(battle);
game.Run();
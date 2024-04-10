using TheFinalBattle;

Renderer renderer = new Renderer();

Party heroes = new();
Party monsters = new();
heroes.add(new SKELETON());
monsters.add(new SKELETON());

Battle battle = new (heroes, monsters, renderer);
Game game = new Game(battle);
game.run();
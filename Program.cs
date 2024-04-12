using TheFinalBattle;

Renderer renderer = new ();
UserInput userInput = new(renderer);

Game game = new Game(renderer, userInput);
game.Run();
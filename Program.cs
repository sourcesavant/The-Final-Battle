﻿using TheFinalBattle;

Renderer renderer = new ();
UserInput userInput = new(renderer);
string trueProgrammerName = userInput.GetTrueProgammerName();


Party heroes = new();
Party monsters = new();
heroes.Add(new TrueProgrammer(trueProgrammerName));
monsters.Add(new SKELETON());

Battle battle = new (heroes, monsters, new ComputerPlayer(), new ComputerPlayer(), renderer);
Game game = new Game(battle);
game.Run();
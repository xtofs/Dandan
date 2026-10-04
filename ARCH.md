# Components and responsibilities

- Card definitions (data only). Declare what a card needs from players and what it does. Fixed values like the N in "scry 2" live here.
- Announcer. Turns a definition into a committed Stack object by collecting the player's choices (X, modes, Targets, payment).
- Resolver. Takes a Stack object off the Stack, revalidates its Targets, and instantiates the effect with the concrete values.
- Actions. Carry out the rules text. They may ask a player mid-way (scry order) and produce commands.
- Game core. Applies commands through Replacement Effects, mutates state, records what happened, and queues triggers. It is the only place state changes.
- Player input port. The single channel for every question to a player. It validates answers. UI, AI, network and test script are interchangeable behind it.
  Priority loop. Drives the game: who has priority, when to resolve, when to advance.

Four core ideas

- Two kinds of parameters. Announcement-time parameters are declared up front as data, so the engine can ask generically. Resolution-time parameters are asked on demand by the action, because they depend on live state.
- One way in. Every question to a player goes through the input port, regardless of who asks.
- One way out. Every state change goes through the game core as a command, so Replacement Effects and triggers need to be understood in only one place.
- Async makes asking cheap. Asking mid-action reads like an ordinary function call, because the suspended method keeps its locals. No continuation code, no mutable answer slots.

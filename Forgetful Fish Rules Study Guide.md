# Forgetful Fish Rules Study Guide

Oct 3, 2026 · @Christof

## What Forgetful Fish is

Forgetful Fish (also called Dandân) is a two-player Magic variant where both players play from one shared 80-card, all-blue deck. It is regular Magic plus four rule changes, so you need the core Magic rules first and the variant rules second.

- The deck has 10 Dandân (the only creature) and 8 Memory Lapse, which give the format its name.
- Almost everything else is blue card draw, top-of-library manipulation, and text-changing tricks.
- Combat is simple; the hard part is the stack, priority, and who draws what off the shared library.

How to study: read Core Magic rules once, then the Rule changes, then Dandân and Memory Lapse. Use the Card reference while playing your first games, and test yourself with the questions at the end.

## Core Magic rules you need

You win by taking your opponent from 20 life to 0, or when they must draw from an empty library. Everything below is standard Magic, limited to what this deck actually uses.

### Zones

| Zone | What it is | In Forgetful Fish |
| --- | --- | --- |
| Library | Face-down draw pile | Shared by both players |
| Hand | Your cards, hidden; max 7 at end of turn | Yours alone |
| Battlefield | Lands and permanents in play | Each player controls their own |
| Stack | Spells and abilities waiting to resolve | Shared, as always |
| Graveyard | Discarded, countered, destroyed, milled cards | Shared by both players |
| Exile | Removed from the game | Rarely used |

### Mana and lands

- You may play one land per turn, during your main phase, with the stack empty.
- Tap a land to add mana. Unspent mana empties at the end of each step and phase.
- In a cost, {U} must be blue mana; {1}, {2} etc. can be any mana. Mana value is the total (Memory Lapse {1}{U} = 2).
- Some lands enter tapped, so they cannot make mana the turn you play them.

### Turn structure

1. Beginning phase: untap your permanents, upkeep, then draw a card. The player who goes first skips the draw on their first turn.
2. First main phase: play a land, cast sorcery-speed spells.
3. Combat: declare attackers, opponent declares blockers, combat damage is dealt.
4. Second main phase: same as the first main phase.
5. Ending phase: end step, then cleanup. Discard down to 7 cards, damage is removed, and "until end of turn" effects end.

### Casting spells: timing

- Sorcery speed (sorceries, creatures, enchantments, lands): only in your own main phase, with an empty stack.
- Instant speed (instants, activated abilities): any time you have priority, on either player's turn.
- To cast: put the card on the stack, choose modes and targets, then pay the cost. Targets are locked in now.
- If every target is illegal when the spell tries to resolve, it does nothing and goes to the graveyard.

### The stack and priority

This is the most important rule in the format. Most games are decided by fights on the stack.

1. The active player (whose turn it is) gets priority first in each step.
2. A player with priority may cast an instant or activate an ability, or pass.
3. When a spell or ability is cast, it goes on top of the stack and the caster gets priority again.
4. When both players pass in a row, the top object resolves. Then the active player gets priority again.
5. When both players pass with an empty stack, the game moves to the next step.

Last in, first out: a response resolves before the thing it responded to. Always ask "Pass?" before resolving anything.

### Abilities

- Activated: "Cost: Effect" (cycling, sacrificing Svyelunite Temple). Usable at instant speed.
- Triggered: start with "when", "whenever" or "at". They go on the stack the next time a player would get priority, and can be responded to.
- Static: always on, never on the stack (Dandân's attack restriction).

### Creatures and combat

- A creature can't attack (or use a tap ability) unless you have controlled it since the start of your turn ("summoning sickness").
- Attacking taps the creature. Each untapped creature can block one attacker.
- Blocked creatures deal damage to each other; unblocked ones damage the defending player.
- A creature with damage equal to its toughness dies. Dandân vs. Dandân (4/1 each) means both die.

### State-based actions

The game checks these automatically whenever a player would get priority:

- A player at 0 or less life loses.
- A player who tried to draw from an empty library since the last check loses.
- A creature with lethal damage or 0 toughness goes to the graveyard.
- An Aura (Control Magic) whose creature left play goes to the graveyard.

### Words to know

- Mill: put cards from the top of the library into the graveyard.
- Bounce: return a permanent or spell to its owner's hand.
- Counter: cancel a spell on the stack.
- Owner vs. controller: owner is who the card belongs to; controller is who currently runs it. Forgetful Fish redefines owner (next section).

## Forgetful Fish rule changes

There are two rule sets: the official Secret Lair Dandân rules (March 2026) and Nick Floyd's original variant. Both start at 20 life with 7-card hands, a 7-card maximum hand size, and loss on drawing from an empty library (the original's optional Remember the Fish rule changes that, see below).

| Rule | Official Secret Lair (2026) | Nick Floyd original |
| --- | --- | --- |
| Library and graveyard | Shared. "Your library" or "your graveyard" means the shared one. | Same |
| Owner of a card | Whoever cast it (spell on the stack or permanent on the battlefield) | Whoever played it from their hand |
| Simultaneous draws (opening hands, both-draw effects) | Dealt one card at a time, active player first | Dealt one at a time like a card game; first player or active player deals |
| Free mulligan | A hand with fewer than two lands or fewer than two spells may be revealed and redrawn at 7. Not available once you have taken a normal mulligan. | A hand with fewer than two lands may be revealed and redrawn at 7, repeatedly |
| Normal mulligan | Standard Magic mulligan | Draw one fewer card each time; no scry |
| Life tracking | 20 life | 20 life, often tracked as 5 counters, since Dandân hits for 4 |

### Optional house rules (original variant)

Agree on these before the game:

- Finding Dory: Dandân counts as every card type, so Mystic Retrieval and Mystical Tutor can find it.
- Fish Eyes: a card both players know is on top of the library (e.g. a spell hit by Memory Lapse) is placed face up.
- In the Minds Island: remove four Islands; each player starts with two untapped Islands in play, and the game starts in the first player's main phase. Normal mulligans only.
- Remember the Fish: if the library is empty when a player must draw, shuffle the graveyard into the library first. You only lose to decking if both are empty.
- Thanks for the Fish: "owner" means controller, so stolen Dandâns can be kept permanently.

The owner rule matters most in practice. If you cast a spell and it is bounced or countered "to its owner", it comes back to you. A Dandân you cast and your opponent steals with Control Magic still returns to your hand if bounced.

## Dandân and Memory Lapse

The whole format revolves around these two cards: Dandân is the only way to deal damage, and Memory Lapse decides which spells actually resolve.

### Dandân

Dandân costs {U}{U} and is a 4/1 Fish. It has two abilities:

- It can't attack unless the defending player controls an Island. This is a static restriction, checked when attackers are declared.
- When you control no Islands, sacrifice it. This is a triggered ability (a "state trigger"); it goes on the stack and can be responded to.

What counts as an Island: any land with the Island subtype. Basic Island and Mystic Sanctuary are Islands. Halimar Depths, Lonely Sandbar, Remote Isle, Svyelunite Temple and the other utility lands are not.

Four hits of 4 damage take you from 20 to 4; the fifth hit kills. A blocked Dandân trades with a blocking Dandân.

Ways to get rid of a Dandân:

1. Block it with your own Dandân (both die).
2. Change the word "Island" on it to another basic land type (Crystal Spray, Mind Bend, Magical Hack). Its controller now controls "no Swamps", so it is sacrificed, and it can only attack someone with a Swamp.
3. Leave its controller with no Islands, for example by turning their Islands into another land type (Vision Charm in the original list, or text-changing their only Island).
4. Bounce it (Unsubstantiate), put it on top of the library (Metamorphose), or steal it (Control Magic).

The sacrifice trigger has no "intervening if": once it is on the stack, giving the player an Island back does not save the Dandân. To save it, you must respond by removing the Dandân (bounce it) or stop the effect that took the Islands away.

Defensive trick: a player who controls no Islands cannot be attacked by any Dandân. If your early hand has non-Island lands, holding back Islands can buy time, but you can't keep your own Dandâns either.

### Memory Lapse

Memory Lapse costs {1}{U}: counter target spell, and if it is countered this way, put it on top of its owner's library instead of into the graveyard. In Forgetful Fish that is the shared library, so the next player to draw gets the countered card.

| When the Lapsed spell was cast | Who draws it next (if nothing else changes the top) |
| --- | --- |
| Your upkeep, before your draw | You, in your draw step |
| Your turn, after your draw | Your opponent, in their draw step |
| Opponent's turn, after their draw | You, in your draw step |

Rules of thumb:

- Cast important spells on your opponent's turn after their draw step, or in your own upkeep. If they get Lapsed, you redraw them.
- Expect a Lapse whenever your opponent has two untapped mana. With 8 in the deck, they usually have one.
- Top-of-library effects (Brainstorm, Predict, cycling, Telling Time) let either player take or bury a Lapsed card.

## Card reference

The Secret Lair Dandân deck (released March 16, 2026) is 80 cards: 10 Dandân, 8 Memory Lapse, 4 Accumulated Knowledge, 20 Islands, and two each of everything else. Card text below is paraphrased; check the physical card for exact wording.

### Secret Lair list: spells

| Card | Qty | Cost | Type | What it does | Fish note |
| --- | --- | --- | --- | --- | --- |
| Dandân | 10 | {U}{U} | Creature 4/1 | See previous section | The only creature and only damage source |
| Memory Lapse | 8 | {1}{U} | Instant | Counter target spell; put it on top of the library | Next drawer gets the card |
| Accumulated Knowledge | 4 | {1}{U} | Instant | Draw 1, plus 1 per Accumulated Knowledge in the graveyard | Shared graveyard: wait until others are in it |
| Brainstorm | 2 | {U} | Instant | Draw 3, put 2 from hand back on top | Set up or deny the next draw |
| Magical Hack | 2 | {U} | Instant | Permanently change one basic land type word on a spell or permanent | Turns a Dandân's "Island" into another type: it dies |
| Crystal Spray | 2 | {2}{U} | Instant | Until end of turn, change one color word or basic land type word; draw a card | Same Dandân kill, temporary but replaces itself |
| Telling Time | 2 | {1}{U} | Instant | Look at top 3: one to hand, one on top, one on bottom | Also chooses what the next player draws |
| Predict | 2 | {1}{U} | Instant | Name a card; target player mills 1; draw 2 if it was the named card, else draw 1 | Mill a known top card you don't want them to draw |
| Mental Note | 2 | {U} | Instant | Mill 2, then draw a card | Fills the graveyard for Accumulated Knowledge |
| Metamorphose | 2 | {1}{U} | Instant | Put an opponent's permanent on top of the library; they may put an artifact, creature, enchantment or land from hand onto the battlefield; you draw | Removes a Dandân, but you will draw it back if it stays on top |
| Unsubstantiate | 2 | {1}{U} | Instant | Return target spell or creature to its owner's hand | Save your spell from a Lapse, or bounce a Dandân |
| Chart a Course | 2 | {1}{U} | Sorcery | Draw 2, then discard 1 unless you attacked this turn | Rewards attacking with Dandân first |
| Control Magic | 2 | {2}{U}{U} | Enchantment, Aura | You control the enchanted creature | Steal a Dandân; you need an Island to keep it |
| Day's Undoing | 2 | {2}{U} | Sorcery | Everyone shuffles hand and graveyard into the library, then draws 7; ends the turn if it is yours | Resets card advantage; draws are dealt one at a time |
| Capture of Jingzhou | 2 | {3}{U}{U} | Sorcery | Take an extra turn | Expensive, so hard to resolve through Lapse |

### Secret Lair list: lands

| Land | Qty | Island? | Enters tapped? | Ability |
| --- | --- | --- | --- | --- |
| Island | 20 | Yes | No | {T}: add {U} |
| Mystic Sanctuary | 2 | Yes | Unless you control 3+ other Islands | If it enters untapped, may put an instant or sorcery from the graveyard on top of the library |
| Halimar Depths | 2 | No | Yes | On entering, look at the top 3 and reorder them |
| Lonely Sandbar | 2 | No | Yes | Cycling {U} (discard it to draw a card) |
| Remote Isle | 2 | No | Yes | Cycling {2} |
| Svyelunite Temple | 2 | No | Yes | {T}, sacrifice it: add {U}{U} |
| The Surgical Bay | 2 | No | Yes | {1}{U}, {T}, sacrifice it: draw a card |
| Haunted Fengraf | 2 | No | No | Taps for colorless; {3}, {T}, sacrifice: return a random creature card from the graveyard to hand |

Haunted Fengraf is not random in practice here: the only creature card is Dandân.

### Original list only (Nick Floyd)

The original list shares the core (Dandân, Memory Lapse, Accumulated Knowledge, Islands) but swaps in these cards. The Secret Lair designers cut Vision Charm and Mystic Retrieval on purpose.

| Card | Qty | Cost | What it does | Fish note |
| --- | --- | --- | --- | --- |
| Vision Charm | 2 | {U} | Choose one: target player mills 4; or turn one land type into a basic land type until end of turn; or phase out an artifact | Islands into Swamps kills every Dandân on the table |
| Mind Bend | 2 | {U} | Permanently change one color word or basic land type word | Same role as Magical Hack |
| Dance of the Skywise | 2 | {1}{U} | Your creature becomes a 4/4 flying Dragon Illusion with no other abilities until end of turn | Loses the sacrifice trigger: a save against Vision Charm |
| Mystical Tutor | 2 | {U} | Search for an instant or sorcery and put it on top of the library | Cast before your own draw |
| Ray of Command | 2 | {3}{U} | Gain control of an opponent's creature until end of turn; untap it, it gains haste | Steal a blocker or attacker for one turn |
| Supplant Form | 2 | {4}{U}{U} | Bounce a creature; you get a token copy of it | Removal plus a Dandân of your own |
| Diminishing Returns | 2 | {2}{U}{U} | Everyone shuffles hand and graveyard into the library, exile the top 10, each player draws up to 7 | The original reset button |
| Mystic Retrieval | 2 | {3}{U} | Return an instant or sorcery from the graveyard to hand; flashback {2}{R} | Flashback needs red from the two red lands |
| Izzet Boilerworks | 2 | land | Enters tapped, return a land you control to hand; taps for {U}{R} | Not an Island |
| Temple of Epiphany | 2 | land | Enters tapped, scry 1; taps for {U} or {R} | Not an Island |

The original also runs Lonely Sandbar, Remote Isle, Halimar Depths and Svyelunite Temple, but not Mystic Sanctuary, Haunted Fengraf, The Surgical Bay, Magical Hack, Telling Time, Mental Note, Chart a Course, Control Magic, Day's Undoing or Capture of Jingzhou.

## Tricky interactions

These are the situations new players most often get wrong.

1. Text-changing words are chosen on resolution. Crystal Spray, Mind Bend and Magical Hack target the Dandân when cast, but the words to swap are picked when the spell resolves. Changing something in response does not dodge it.
2. Text-changing a land changes its type. Hacking a basic Island's "Island" to "Swamp" makes it a Swamp. If that was its controller's last Island, all their Dandâns are sacrificed.
3. The sacrifice trigger can't be undone by restoring an Island. Once "When you control no Islands" triggers, it resolves and sacrifices regardless. Respond by bouncing the Dandân instead.
4. Control Magic and Islands. If you steal a Dandân while you control no Islands, it triggers and you sacrifice it.
5. Owner means caster. A bounced spell or Dandân goes to the hand of whoever cast it, even if the other player now controls it.
6. Memory Lapse on your own spell. Late in the game, with the library nearly empty, Lapsing your own spell guarantees a card to draw.
7. Unsubstantiate vs. Memory Lapse. When your spell is about to be Lapsed, bounce your own spell to hand and recast it later instead of losing it to the library.
8. Accumulated Knowledge counts every copy in the shared graveyard, including your opponent's.
9. Cycling and "draw" effects take the top card. If both players know a Lapsed card is on top, the first to draw (or cycle) gets it.
10. Day's Undoing (or Diminishing Returns) draws are dealt one at a time, starting with the active player.
11. Can't attack vs. can't be attacked. Dandân checks the defending player's Islands when attackers are declared. Removing their Islands mid-combat does not remove an attack already declared.
12. Summoning sickness applies to stolen creatures. A Dandân taken with Control Magic can't attack until your next turn.

## Self-test

Cover the answer column and work through these before your first game.

| # | Question | Answer |
| --- | --- | --- |
| 1 | Your opponent controls only Halimar Depths and Lonely Sandbar. Can your Dandân attack them? | No. Neither land is an Island. |
| 2 | You cast Brainstorm on your opponent's turn. Who receives priority after it is cast? | You do; then it passes to your opponent. It resolves only after both pass. |
| 3 | You cast Capture of Jingzhou and it gets Memory Lapsed during your main phase. Who will likely draw it? | Your opponent, in their next draw step. |
| 4 | Your opponent Crystal Sprays your Dandân. In response you play an extra Island. Does Dandân survive? | No. Lands can't be played in response, and the swapped word is chosen on resolution anyway. |
| 5 | The sacrifice trigger is on the stack. How can you keep the Dandân? | Bounce it to hand (Unsubstantiate). Restoring an Island does not help. |
| 6 | Two Accumulated Knowledge are in the graveyard. You cast a third. How many cards do you draw? | 3 (1 + 2 in the graveyard). |
| 7 | You steal your opponent's Dandân with Control Magic; it is then bounced. Whose hand does it go to? | Your opponent's, since they cast it (official owner rule). |
| 8 | Your opponent attacks with Dandân. You block with your untapped Dandân. Result? | Both are 4/1, so both die. |
| 9 | When is the safest time to cast an important instant? | In your upkeep, or on your opponent's turn after their draw step, so a Lapse puts it back in your draw. |
| 10 | Your opening hand has 1 land and 6 spells. What can you do under the official rules? | Reveal it and take a free mulligan back to 7, if you haven't taken a normal mulligan yet. |
| 11 | How many unblocked Dandân hits does it take to win from 20 life? | Five. |
| 12 | The library is empty and it's your draw step. What happens? | Official rules: you lose. With Remember the Fish: shuffle the graveyard in and draw. |

## Sources

- [From the Chaos Vault: Secret Lair Dandân Decklist](https://magic.wizards.com/en/news/announcements/from-the-chaos-vault-secret-lair-dandan-decklist), Wizards of the Coast, March 15, 2026: official rules and the 80-card list
- [Magic Variant: Forgetful Fish](https://tappedout.net/mtg-decks/magic-forgetful-fish-1), Nick Floyd: original rules, optional rules, strategy notes
- [The Surgical Bay, Secret Lair printing](https://facetofacegames.com/en-us/products/the-surgical-bay-2163-retro-frame-dandan-deck-secret-lair-drop-non-foil): card text
- [Magic Comprehensive Rules](https://magic.wizards.com/en/rules): the full rules of the game

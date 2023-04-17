# StationDefense

Tower defense game made in Unity.

## About

This is a demo game consisting of three levels. Note that it lacks an in-game economy, so the player can build defensive structures at no cost. Despite this, the project is considered finished.

## Gameplay

As stated above, the game has three levels. All of them present a timed goal of surviving for two minutes, so that either you win and complete the level, or your station is destroyed, and you're given the option to retry.

### Level 1

In Level 1, there is a single type of enemy. The creatures spawn in three-second intervals along a clear path, and there are plenty of build platforms on which the player can construct their defenses. This level introduces the game's format in a way that, as long as the player makes an attempt, victory is practically guaranteed. My goal in its design was for the player to be able to load the level and intuitively understand what to do. Even so, the Start Menu includes means for accessing instructions on how to play. 

### Level 2

Level 2 introduces a second type of enemy that is faster and hardier than those found in Level 1. The player must manage the same influx of L1 critters in addition to the new enemy type. It's definitely doable (especially since the player is able to construct defenses for free), but more damage is likely to be inflicted on the station that the player is tasked with protecting. 

### Level 3

Level 3 includes the enemy types from both prior levels, plus a surprise boss that will inflict considerable damage to the player's base if not quickly taken out. The enemy type that was introduced in L2 spawns faster and has a shorter path to the station, but has lower health to balance this out. 

## Look and Feel

### Graphics and Animation

The game is completely 3D in design. All assets are low-poly, making for an undemanding (yet visually charming) game — a decision largely influenced by the game's intended platform: mobile devices. The placeable towers, projectiles, and enemies are all animated (the latter of which is done through <code>Animators</code>). There is a live countdown timer on-screen so that the player always knows how much longer they need to survive to complete the current level. Every projectile sent out by the defensive towers leaves a particle trail behind it as it flies through the air. Enemy AI relies on <code>NavMesh</code>, so that they stick to their proper paths. <code>Colliders</code> are used for many features, such as each tower's enemy-detection radius and the dealing of damage to enemies by tower projectiles, and to the station through enemy collision. 

### Sound

There are two different music tracks: one for all menu scenes and another which plays during each level. Every menu button plays a "thud" sound when clicked/tapped on. Each type of object and creature capable of taking damage has a corresponding sound effect. The defensive towers also play sounds upon firing projectiles. 

### Theme

The game has a sci-fi/space theme. This is made apparent throughout the game's various features.

#### Menus
Galaxy background image, hand-drawn button sprites with sharp, slanted edges, and imported sci-fi fonts. The music also has a galactic vibe to it.

#### Levels

The environment has a rocky-planet feel. In-game assets were chosen to match. Alien beetles, rock golems, and space pods are all the kinds of stuff an astronaut may "reasonably" find on such a planet. Asteroids are scattered throughout the landscape, and funky, space music plays while you defend against your enemies. 

## Controls and UI

### Mobile-Focused Design

The game's controls were developed with simplicity in mind. It's all point-and-click — or point-and-tap, rather, when played on mobile. As written in the "Look and Feel" section above, the target of mobile devices was a large factor in my decision to use low-poly assets. At the time of development, my smartphone was relatively old and slow, and thus limited in what it could reasonably run. Unrelated to the game's performance: when designing the menus, I stayed away from serif fonts, as those are often more difficult to read on small, digital screens. 

### Main Menu

The Main Menu includes five buttons: Start, Continue (level select), Instructions, Options, and Exit. The <code>Canvas Render Mode</code> is <code>Screen Space — Overlay</code>. The menu styles stick mainly to a single-column format with all the buttons in a tidy line down the center, so that they fit nicely within mobile viewports.

### Intuitive UI

All buttons are labeled, and the in-game controls are simplistic. The UI overlay features the countdown timer mentioned in "Graphics and Animation" above, placed in the top-left corner of the screen, and a "Menu" button placed in the bottom-right corner. As one would expect, opening the menu pauses the game and temporarily freezes the timer. 

## Conclusion: Room for Improvement

As stated at the very start of this README, the game does not include an economy system — a component which is arguably vital to the tower-defense genre. If I were to continue this game's development, that would be priority number one. Other possible improvements include the incorporation of additional animations (e.g., unique enemy attacks) and in-game volume sliders. 

## Asset Use

All assets were used in accordance with their individual copyrights. The game's 3D assets, as well as the two music tracks and Main Menu background image, are available for free on the [Unity Asset Store](https://assetstore.unity.com/). Sound effects were selected from [freesound](https://freesound.org/). 

## License

This work is published under the GNU General Public License v3.0.


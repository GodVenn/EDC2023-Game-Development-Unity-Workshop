# EDC - Game Development in Unity

This is a hands-on workshop where we explore Unity as a tool and develop a simple **3D platformer local-multiplayer game** from empty project to deployed .exe file.

## Projects

The "Final Project" in the 2022 folder contains the target game for last year.  
The EDC 2023 contains the WIP / target game for 2023.

## Preparation (Before the workshop begins)

- I strongly recommend having a **mouse** (not mousepad)
- Those that have a gamepad 🎮 (wireless or otherwise), please bring it if you can, we need as many as possible.
- I recommend a windows machine beacuse that is what i will be using, but Unity also works on MacOS and Linux.
- I recommend Visual Studio (Community/Entreprise/Professional) as the IDE as this works well with Unity debugging and C# programming, but any code editor will do the trick.
- For VS Code users:
  - Install the C# extension from the VS Code Marketplace: https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp
  - Documentation: https://code.visualstudio.com/docs/other/unity

### Pre-install process

- Create a **Unity User** - Use your Equinor e-mail
- Install the latest version of **Unity Hub** for your OS from [here](https://unity.com/download)
- **After installing Unity Hub**: Install **Unity Editor** [v2021.3.29f](https://unity.com/releases/editor/whats-new/2021.3.29) (click **Install this version with Unity Hub.**).
- We will activate trial licenses for each participant the first day of the workshop

## Workshop Outline

- Introduction, Setup - Open empty Unity Project
  - Use 3D URP Template
  - Vs code users: Add VS Code Unity Package to project
    - https://docs.unity3d.com/Manual/com.unity.ide.vscode.html
  - Set external editor -> Regenerate project files
- Interface overview of Unity
  - Windows, Layout, Buttons, Shortcuts
- `Game Objects`
  - What is a Mesh?
  - What is a Texture and how much can we use it for?
  - Physics in Unity
  - Hierarchy
  - `Prefabs`
  - Game Objects - Conclusion
- Outline of the game
- Creating the game Prototype
  - The first cube
    - Painting the cube (`Material`)
  - Creating a player prototype
    - Using the `Character Controller` component
    - Getting user input
    - Handling movement & gravity
  - `Input Manager` (Unity input magic)
  - `Collider` Interaction - Painting the world using the player
    - Scripting platforms
  - Level Design and Creation
  - Local Multiplayer Setup
    - `Player Input Manager`
  - UI For scoretracking
    - Creating a game manager
    - Using the Unity `Canvas`
  - Implementing the game timer
    - Ending and reseting game
- **Playtesting with Prototype - Game assessment**
- Adding the Bop, Pop and Zap ✨
  - Player Model (Dragon or other)
    - Import model, check animations
    - Configuring animations using the `Animator`
    - Link animations to character controller
  - Sounds
    - Unity `Audio Listener` and `Audio Source`
    - Adding sound effects and background music
  - Visual Polish
    - Glow effect using HDR and Bloom after effect
    - VFX ?
  - Add skybox to the world
- If extra time:
  - Add powerups / attacks
  - Add UI / Main Menu
  - Character Selection?
  - End game animation?
- If a lot of extra time:
  - Online multiplayer

## Resources for reference:

Free textures and more:  
https://polyhaven.com/

Free animations and rigs (create user but free to use):  
https://www.mixamo.com/

Unity Asset Store:

- Dragon package: https://assetstore.unity.com/packages/3d/characters/creatures/dragon-for-boss-monster-hp-79398
- Sound effects: https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116
- Skybox: https://assetstore.unity.com/packages/2d/textures-materials/sky/starfield-skybox-92717
- Third Person Character Controller: https://assetstore.unity.com/packages/essentials/starter-assets-third-person-character-controller-urp-196526

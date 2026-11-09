# CardGame – A Card-Based RPG

# CardGame is a console-based RPG where the player selects a character and engages in turn-based combat against a random enemy. Damage is dealt using cards drawn from a specific deck belonging to the chosen character.
The game utilizes JSON files to store cards, character attributes, and character lists.

## Author
Developer: Illia
Programming Language: C# (.NET 9.0)
Project Type: Console Game

## Key Features
- Character selection via a menu
- Character selection saved to AppData
- Random enemy generation
- Loading of cards and attributes from JSON files
- Statistics tracking
- Turn-based combat system
- User-friendly card formatting

## How to Run the Project
1. Open the project in Visual Studio or JetBrains Rider.
2. Ensure .NET 9.0 is installed.
3. Run the project in Debug or Release mode.

## How to Run the .exe
> Note: The `bin/` and `obj/` directories are not included in the repository. You must build the project locally to run it.
1. Navigate to the folder: `bin/Release/net9.0/win-x64/publish/`
2. Run `CardGame.exe`.
3. Upon the first launch, a save file will be created at:
`%AppData%/CardGame/UserChoices.json`

## Technical Details
- All paths to JSON files are constructed using `AppContext.BaseDirectory`.
- A custom `PathResolver` is used to ensure the `.exe` functions correctly.
- Character and card data are loaded via `JsonLoader`.
- User save data is stored in `AppData`, allowing for separate settings on each device.

## Potential Improvements
- Add a player profile system.
- Add a combat log and turn history.
- Add a colored interface (e.g., using `Console.ForegroundColor`).
- Add multiple enemy types with varying difficulty levels.
- Add automatic progress saving.
- Add combat statistics.
- Add bot logic (to allow the bot to "decide" which card is best to play).
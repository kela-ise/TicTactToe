# Tic Tac Toe Game

## Introduction
This is a classic Tic Tac Toe game where a user can play against an AI opponent. The game is played on a 3x3 grid, and the user places their symbol (X or O) to compete against the AI. The game continues until there is a winner or a tie.

### Features

User vs. AI Gameplay: Take turns against an AI opponent.

Grid-Based Play Area: Users place their symbols in a structured grid.

Win Detection: The game detects when a player wins or when a tie occurs.

Separation of Concerns: The game is structured using separate files for UI and logic.

### Core Technical Concepts/Inspiration

This project follows software design best practices by ensuring a clean separation between UI and game logic:

UI.cs: Handles user interaction and displays the game board.

Logic.cs: Manages game rules, AI moves, and win detection.

The AI employs a simple strategy to place symbols logically in an empty grid space.

### Getting Started

#### Prerequisites

.NET SDK (for compiling and running the C# program)

A C# compiler (if running manually)

#### Installation & Running

Clone the repository:

git clone https://github.com/yourusername/tic-tac-toe-game.git
cd tic-tac-toe-game

Build the project:
Run the game:

dotnet run

How to Play

The game will display a 3x3 grid.

The user will be prompted to enter a position to place their symbol (X or O).

The AI will make its move after the user.

The game will check for a winner or a tie after each move.

The game ends when either the user or AI wins, or when the grid is full.

### Versioning

Current version: 1.0.0

Future updates may include an improved AI and a graphical user interface.

### Common Errors

Invalid Input: Entering an out-of-range position or an already occupied spot will prompt the user to enter a valid move.

Game Not Exiting Properly: Ensure you follow on-screen prompts to quit the game correctly.

### Contributing Guidelines

Follow C# coding conventions.

Submit pull requests for improvements and bug fixes.

Report issues in the repository’s issue tracker.

### TODO / Future Enhancements

Improve AI strategy using Minimax algorithm.

Add support for multiplayer mode.

Implement a graphical user interface.

### Contact

GitHub:


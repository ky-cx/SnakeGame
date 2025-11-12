# 🐍 Snake Game - C# Console Application

Classic Snake game built with C# for the terminal, demonstrating OOP principles, game loops, and collision detection algorithms.

![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat-square&logo=dotnet&logoColor=white)

## ✨ Features

- 🎮 Classic snake gameplay with smooth controls
- 🎯 Score tracking system
- ⚡ Progressive difficulty (speed increases)
- ⏸️ Pause functionality
- 🎨 Clean ASCII art interface
- 📊 Real-time stats display

## 🛠️ Technologies

- **Language**: C# 10.0
- **Framework**: .NET 10.0
- **Platform**: Cross-platform (Windows, macOS, Linux)

## 🚀 Getting Started

### Prerequisites
- .NET 10.0 SDK or later

### Installation & Running
```bash
# Clone the repository
git clone https://github.com/ky-cx/snake-game-csharp.git

# Navigate to project directory
cd snake-game-csharp

# Run the game
dotnet run
```

## 🎮 How to Play

### Controls
- **W / ↑** - Move Up
- **S / ↓** - Move Down
- **A / ←** - Move Left
- **D / →** - Move Right
- **P** - Pause/Resume
- **Q** - Quit

### Rules
1. Control the snake to eat food (★)
2. Each food increases score by 10 points
3. Snake grows with each food eaten
4. Speed increases every 50 points
5. Avoid hitting walls or yourself!

## 🎯 Technical Highlights

### Object-Oriented Design
- Encapsulation of game state and logic
- Type-safe direction handling with enums
- Clean separation of concerns

### Key Algorithms
- **Collision Detection**: O(n) self-collision, O(1) boundary checks
- **Game Loop**: Event-driven with fixed time steps
- **Snake Movement**: Deque-like operations using List<T>

### Code Quality
- Comprehensive XML documentation
- SOLID principles applied
- Clean, maintainable code structure

## 📊 Project Stats

- **Lines of Code**: ~400
- **Development Time**: ~6 hours
- **Complexity**: Medium (junior-mid level)

## 💼 Why This Project?

This project demonstrates several key software engineering concepts:

- **OOP Principles**: Encapsulation, abstraction, separation of concerns
- **Algorithm Skills**: Collision detection, state management
- **Game Development**: Game loop, real-time input handling
- **Code Quality**: Documentation, naming conventions, clean code

Perfect for technical interviews to discuss:
- Design patterns and architecture
- Performance optimization strategies
- Testing approaches
- Potential enhancements

## 🔮 Future Enhancements

- [ ] High score persistence
- [ ] Multiple difficulty levels
- [ ] Sound effects
- [ ] Multiplayer mode
- [ ] Power-ups and obstacles

## 👨‍💻 Author

**Conghui Xu**
- 📧 Email: hsuconghui@gmail.com
- 💼 LinkedIn: [linkedin.com/in/cx27](https://linkedin.com/in/cx27)
- 🐙 GitHub: [@ky-cx](https://github.com/ky-cx)
- 🌐 Portfolio: [ky-cx.github.io](https://ky-cx.github.io)

## 📄 License

This project is open source and available under the MIT License.

---

**Built with 💚 by Conghui Xu**
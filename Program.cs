using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SnakeGame
{
    /// <summary>
    /// Console-based Snake Game
    /// Demonstrates OOP, game loops, collision detection, and state management
    /// </summary>
    class Program
    {
        // Game constants
        private const int Width = 40;
        private const int Height = 20;
        private const int InitialSpeed = 150;
        
        // Game objects
        private static List<Position> snake;
        private static Position food;
        private static Direction currentDirection;
        private static Direction nextDirection;
        
        // Game state
        private static int score;
        private static int speed;
        private static bool isGameOver;
        private static Random random;
        
        /// <summary>
        /// Position structure for grid coordinates
        /// </summary>
        struct Position
        {
            public int X { get; set; }
            public int Y { get; set; }
            
            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }
            
            public override bool Equals(object obj)
            {
                if (obj is Position other)
                    return X == other.X && Y == other.Y;
                return false;
            }
            
            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }
        }
        
        /// <summary>
        /// Direction enumeration
        /// </summary>
        enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Clear();
            
            ShowWelcomeScreen();
            InitializeGame();
            GameLoop();
        }
        
        /// <summary>
        /// Display welcome screen
        /// </summary>
        static void ShowWelcomeScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
    ╔═══════════════════════════════════════╗
    ║                                       ║
    ║        🐍  SNAKE GAME  🐍            ║
    ║                                       ║
    ║     C# Console Game Project           ║
    ║     by Conghui Xu                     ║
    ║                                       ║
    ╚═══════════════════════════════════════╝
            ");
            Console.ResetColor();
            Console.WriteLine("\n    Controls:");
            Console.WriteLine("    ↑ W - Move Up");
            Console.WriteLine("    ↓ S - Move Down");
            Console.WriteLine("    ← A - Move Left");
            Console.WriteLine("    → D - Move Right");
            Console.WriteLine("    P - Pause");
            Console.WriteLine("    Q - Quit");
            Console.WriteLine("\n    Press any key to start...");
            Console.ReadKey(true);
        }
        
        /// <summary>
        /// Initialize game state
        /// </summary>
        static void InitializeGame()
        {
            random = new Random();
            
            // Initialize snake at center
            snake = new List<Position>
            {
                new Position(Width / 2, Height / 2),
                new Position(Width / 2 - 1, Height / 2),
                new Position(Width / 2 - 2, Height / 2)
            };
            
            currentDirection = Direction.Right;
            nextDirection = Direction.Right;
            score = 0;
            speed = InitialSpeed;
            isGameOver = false;
            
            GenerateFood();
        }
        
        /// <summary>
        /// Generate food at random position
        /// </summary>
        static void GenerateFood()
        {
            do
            {
                food = new Position(random.Next(1, Width - 1), random.Next(1, Height - 1));
            }
            while (snake.Any(s => s.Equals(food)));
        }
        
        /// <summary>
        /// Main game loop
        /// </summary>
        static void GameLoop()
        {
            while (!isGameOver)
            {
                // Handle input
                if (Console.KeyAvailable)
                {
                    HandleInput(Console.ReadKey(true).Key);
                }
                
                // Update game state
                Update();
                
                // Render
                Draw();
                
                // Control speed
                Thread.Sleep(speed);
            }
            
            ShowGameOver();
        }
        
        /// <summary>
        /// Handle keyboard input
        /// </summary>
        static void HandleInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (currentDirection != Direction.Down)
                        nextDirection = Direction.Up;
                    break;
                    
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (currentDirection != Direction.Up)
                        nextDirection = Direction.Down;
                    break;
                    
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (currentDirection != Direction.Right)
                        nextDirection = Direction.Left;
                    break;
                    
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (currentDirection != Direction.Left)
                        nextDirection = Direction.Right;
                    break;
                    
                case ConsoleKey.P:
                    Pause();
                    break;
                    
                case ConsoleKey.Q:
                    isGameOver = true;
                    break;
            }
        }
        
        /// <summary>
        /// Pause game
        /// </summary>
        static void Pause()
        {
            Console.SetCursorPosition(Width / 2 - 5, Height + 3);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("⏸ PAUSED - Press any key to continue");
            Console.ResetColor();
            Console.ReadKey(true);
        }
        
        /// <summary>
        /// Update game state
        /// </summary>
        static void Update()
        {
            currentDirection = nextDirection;
            
            // Calculate new head position
            Position head = snake[0];
            Position newHead = currentDirection switch
            {
                Direction.Up => new Position(head.X, head.Y - 1),
                Direction.Down => new Position(head.X, head.Y + 1),
                Direction.Left => new Position(head.X - 1, head.Y),
                Direction.Right => new Position(head.X + 1, head.Y),
                _ => head
            };
            
            // Check wall collision
            if (newHead.X <= 0 || newHead.X >= Width - 1 || 
                newHead.Y <= 0 || newHead.Y >= Height - 1)
            {
                isGameOver = true;
                return;
            }
            
            // Check self collision
            if (snake.Any(s => s.Equals(newHead)))
            {
                isGameOver = true;
                return;
            }
            
            // Add new head
            snake.Insert(0, newHead);
            
            // Check if food eaten
            if (newHead.Equals(food))
            {
                score += 10;
                GenerateFood();
                
                // Increase speed
                if (score % 50 == 0 && speed > 50)
                {
                    speed -= 10;
                }
            }
            else
            {
                // Remove tail
                snake.RemoveAt(snake.Count - 1);
            }
        }
        
        /// <summary>
        /// Draw game to console
        /// </summary>
        static void Draw()
        {
            Console.Clear();
            
            // Draw border
            Console.ForegroundColor = ConsoleColor.White;
            for (int x = 0; x < Width; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("═");
                Console.SetCursorPosition(x, Height - 1);
                Console.Write("═");
            }
            for (int y = 0; y < Height; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("║");
                Console.SetCursorPosition(Width - 1, y);
                Console.Write("║");
            }
            Console.SetCursorPosition(0, 0);
            Console.Write("╔");
            Console.SetCursorPosition(Width - 1, 0);
            Console.Write("╗");
            Console.SetCursorPosition(0, Height - 1);
            Console.Write("╚");
            Console.SetCursorPosition(Width - 1, Height - 1);
            Console.Write("╝");
            
            // Draw snake
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var segment in snake)
            {
                Console.SetCursorPosition(segment.X, segment.Y);
                Console.Write(segment.Equals(snake[0]) ? "●" : "○");
            }
            
            // Draw food
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(food.X, food.Y);
            Console.Write("★");
            
            // Draw score
            Console.ResetColor();
            Console.SetCursorPosition(2, Height);
            Console.Write($"Score: {score}   Speed: {InitialSpeed - speed + 100}   Length: {snake.Count}");
            
            Console.ResetColor();
        }
        
        /// <summary>
        /// Show game over screen
        /// </summary>
        static void ShowGameOver()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
    ╔═══════════════════════════════════════╗
    ║                                       ║
    ║          💀 GAME OVER 💀             ║
    ║                                       ║
    ╚═══════════════════════════════════════╝
            ");
            Console.ResetColor();
            Console.WriteLine($"\n    Final Score: {score}");
            Console.WriteLine($"    Snake Length: {snake.Count}");
            Console.WriteLine("\n    Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
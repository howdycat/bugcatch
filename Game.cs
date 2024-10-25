
using System.ComponentModel;
using System.Numerics;
using Raylib_cs;

namespace Game;

class Game {

    public static Dictionary<KeyboardKey, Vector2> inputMapp1 = new();
    public static Dictionary<KeyboardKey, Vector2> inputMapp2 = new();
    public static Player player;
    public static Player player2;
    // Main game loop
    public static void Main() {
        Init();

        while (!Raylib.WindowShouldClose())
        {
            Update();
            Draw();
        }

        Raylib.CloseWindow();
    }

    // Init Function
    public static void Init() {
        Raylib.InitWindow(800,480, "buggame");

        player = new Player( new(Raylib.GetScreenWidth()/2, Raylib.GetScreenHeight()/2), Color.Red);

        Dictionary<KeyboardKey, Action> p1bindings = new Dictionary<KeyboardKey, Action>{
            {KeyboardKey.A, player.MoveLeft},
            {KeyboardKey.D, player.MoveRight},
            {KeyboardKey.S, player.MoveDown},
            {KeyboardKey.W, player.MoveUp}
        };

        player.RegisterBindings(p1bindings);

        player2 = new Player( new(Raylib.GetScreenWidth()/2, Raylib.GetScreenHeight()/2 + 100), Color.Blue);
        Dictionary<KeyboardKey, Action> p2bindings = new Dictionary<KeyboardKey, Action>{
            {KeyboardKey.Left, player2.MoveLeft},
            {KeyboardKey.Right, player2.MoveRight},
            {KeyboardKey.Down, player2.MoveDown},
            {KeyboardKey.Up, player2.MoveUp}
        };
        player2.RegisterBindings(p2bindings);

    }

    // Update function
    public static void Update() {
        player.Update();
        player2.Update();
    }

    // Draw function
    public static void Draw() {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);
        player.Draw();
        player2.Draw();
        Raylib.EndDrawing();
    }
}
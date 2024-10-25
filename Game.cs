
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
        player = new Player( new(Raylib.GetScreenWidth()/2, Raylib.GetScreenHeight()/2));
        player2 = new Player( new(Raylib.GetScreenWidth()/2, Raylib.GetScreenHeight()/2 + 100), Color.Blue);
        
        inputMapp1[KeyboardKey.A] = new(-1,0);
        inputMapp1[KeyboardKey.D] = new(1,0);
        inputMapp1[KeyboardKey.W] = new(0,-1);
        inputMapp1[KeyboardKey.S] = new(0,1);

        inputMapp2[KeyboardKey.Left] = new(-1,0);
        inputMapp2[KeyboardKey.Right] = new(1,0);
        inputMapp2[KeyboardKey.Up] = new(0,-1);
        inputMapp2[KeyboardKey.Down] = new(0,1);
    }

    // Update function
    public static void Update() {
        player.Update(inputMapp1);
        player2.Update(inputMapp2);
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
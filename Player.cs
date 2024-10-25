
using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs;

class Player {

    public Dictionary<KeyboardKey, Action> keyMappings;

    public Vector2 position;
    public Vector2 velocity;

    public Vector2 spawnPoint;

    public Color playerColor;

    public Player(Vector2 start, Color color){
        // initialize our properties
        position = start;
        velocity = new(0,0);
        playerColor = color;
    }

    public void RegisterBindings(Dictionary<KeyboardKey, Action> mappings) {
        keyMappings = mappings;
    }

    public void MoveUp() {
        velocity.Y -= 1;
    }

    public void MoveDown() {
        velocity.Y += 1;
    }

    public void MoveLeft() {
        velocity.X -= 1;
    }

    public void MoveRight() {
        velocity.X += 1;
    }

    public void Update() {
        velocity.X = 0;
        velocity.Y = 0;

       foreach(KeyValuePair<KeyboardKey, Action> entry in keyMappings){
        if(Raylib.IsKeyDown(entry.Key)){
            entry.Value.Invoke();
        }
       }

        if (velocity.X != 0 || velocity.Y != 0) {
            position += 0.02f * Vector2.Normalize(velocity);
        }
    }

    public void Draw() {
        Raylib.DrawCircleV(position, 10, playerColor);
    }


}
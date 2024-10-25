
using System.Numerics;
using Raylib_cs;

class Player {

    public Vector2 position;
    public Vector2 velocity;

    public Vector2 spawnPoint;

    public Color playerColor;

    public Player(Vector2 start){
        // initialize our properties
        position = start;
        velocity = new(0,0);
        playerColor = Color.Red;
    }

    public Player(Vector2 start, Color color){
        // initialize our properties
        position = start;
        velocity = new(0,0);
        playerColor = color;
    }

    public void MovePlayer() {

    }

    public void Update(Dictionary<KeyboardKey, Vector2> inputMap) {
        velocity.X = 0;
        velocity.Y = 0;

       foreach(KeyValuePair<KeyboardKey, Vector2> entry in inputMap){
        if(Raylib.IsKeyDown(entry.Key)){
            velocity += entry.Value;
        }
       }

        // if (Raylib.IsKeyDown(KeyboardKey.D)) {
        //    velocity.X = 1;
        // }
        // if (Raylib.IsKeyDown(KeyboardKey.A)) {
        //    velocity.X = -1;
        // }
        // if (Raylib.IsKeyDown(KeyboardKey.W)) {
        //    velocity.Y = -1;
        // }
        // if (Raylib.IsKeyDown(KeyboardKey.S)) {
        //    velocity.Y = 1;
        // }

        // check collisions here?

        if (velocity.X != 0 || velocity.Y != 0) {
            position += 0.02f * Vector2.Normalize(velocity);
        }
    }

    public void Draw() {
        Raylib.DrawCircleV(position, 10, playerColor);
    }


}
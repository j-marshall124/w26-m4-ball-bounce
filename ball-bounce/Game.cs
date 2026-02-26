// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Vector2 position = new Vector2(200, 50);
        Vector2 velocity;
        float radius = 25;
        Vector2 gravity = new Vector2(0, 8);

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Ball Bounce");
            Window.SetSize(400, 800);
        }
        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            // Move ball
            velocity += gravity;
            position += velocity * Time.DeltaTime;

            // Draw ball
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Red;
            Draw.Circle(position, radius);
        }
    }

}

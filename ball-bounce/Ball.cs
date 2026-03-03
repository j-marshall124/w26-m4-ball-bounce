using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MohawkGame2D
{
    public class Ball
    {
        // Ball
        Vector2 position = new Vector2(200, 50);
        Vector2 velocity;
        float radius = 25;
        Color color;
        // Physics
        Vector2 gravity = new Vector2(0, 8);
        float forceKept = 0.75f; // 75%
        float minRandomSpeed = 1000;
        float maxRandomSpeed = 3000;

        // Constructor
        public Ball()
        {
            // This is what happens when a new Ball is created
            color = Random.Color();
        }

        public void AddRandomForceToBall()
        {
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                velocity = Random.Direction();
                velocity *= Random.Float(minRandomSpeed, maxRandomSpeed);
            }
        }

        public void MoveBall()
        {
            // Move ball
            velocity += gravity;
            position += velocity * Time.DeltaTime;

            // CONSTRAIN TO X
            if (position.X + radius > Window.Width)
            {
                // Move ball up to touching right edge
                position.X = Window.Width - radius;
                // Invert velocity
                velocity.X = -velocity.X * forceKept;
            }
            else if (position.X - radius < 0)
            {
                // Move ball up to touching left edge
                position.X = 0 + radius;
                //Invert velocity
                velocity.X = -velocity.X * forceKept;
            }

            // CONSTRAIN TO Y
            //Check if we are below the screen height / bottom edge
            if (position.Y + radius > Window.Height)
            {
                // Move ball up to bottom edge
                position.Y = Window.Height - radius;
                // Invert velocity to bounce up, scale velocity down a bit
                velocity.Y = -velocity.Y * forceKept;
            }
            // Check if we are above the creen top / top edge
            else if (position.Y - radius < 0)
            {
                // Move ball up to bottom edge
                position.Y = 0 + radius;
                // Invert velocity to bounce up, scale velocity down a bit
                velocity.Y = -velocity.Y * forceKept;
            }
        }

        public void DrawBall()
        {
            // Draw ball
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = color;
            Draw.Circle(position, radius);
        }
    }
}

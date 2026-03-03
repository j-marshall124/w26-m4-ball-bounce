using MohawkGame2D;
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
        // Physics
        Vector2 gravity = new Vector2(0, 8);
        float forceKept = 0.75f; // 75%

        public void MoveBall()
        {
            // Move ball
            velocity += gravity;
            position += velocity * Time.DeltaTime;

            //Check if we are below the screen height / bottom edge
            if (position.Y + radius > Window.Height)
            {
                // Move ball up to bottom edge
                position.Y = Window.Height - radius;
                // Invert velocity to bounce up, scale velocity down a bit
                velocity.Y = -velocity.Y * forceKept;
            }
        }

        public void DrawBall()
        {
            // Draw ball
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Red;
            Draw.Circle(position, radius);
        }
    }
}

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
        float forceKeptWall = 0.75f; // 75%
        float forceKeptBall = 0.90f; // 90%
        float minRandomSpeed = 1000;
        float maxRandomSpeed = 3000;

        // Constructor
        public Ball()
        {
            // This is what happens when a new Ball is created
            color = Random.Color();
            position = Random.Vector2(Window.Size);
            radius = Random.Integer(2, 25);
        }

        public void AddRandomForceToBall()
        {
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                velocity = Random.Direction();
                velocity *= Random.Float(minRandomSpeed, maxRandomSpeed);
            }
        }

        public void CollideWithOthers(Ball[] others, int count)
        {
            for (int i = 0; i < count; i++)
            {
                // Pull on item out of array
                Ball other = others[i];
                // If we are trying to collide this ball with itself
                if (other == this)
                    continue;
                
                // Are we colliding?
                // Get vector from this Ball to the other
                Vector2 difference = other.position - position;
                Vector2 direction = Vector2.Normalize(difference);
                float distance = difference.Length();
                // Get minimum distance for collision to happen
                float minDistance = this.radius + other.radius;
                bool isColliding = distance < minDistance;

                if (isColliding == true)
                {
                    // How far overlapped are these two objects?
                    float depth = minDistance - distance;
                    float depthHalf = depth / 2;
                    // Move objects so they are no longer colliding
                    other.position += direction * depthHalf;
                    this.position -= direction * depthHalf;
                    // Adjust velocity to point in direction we collided in
                    other.velocity = other.velocity.Length() * +direction * forceKeptBall;
                    this.velocity = this.velocity.Length() * -direction * forceKeptBall;
                }
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
                velocity.X = -velocity.X * forceKeptWall;
            }
            else if (position.X - radius < 0)
            {
                // Move ball up to touching left edge
                position.X = 0 + radius;
                //Invert velocity
                velocity.X = -velocity.X * forceKeptWall;
            }

            // CONSTRAIN TO Y
            //Check if we are below the screen height / bottom edge
            if (position.Y + radius > Window.Height)
            {
                // Move ball up to bottom edge
                position.Y = Window.Height - radius;
                // Invert velocity to bounce up, scale velocity down a bit
                velocity.Y = -velocity.Y * forceKeptWall;
            }
            // Check if we are above the creen top / top edge
            else if (position.Y - radius < 0)
            {
                // Move ball up to bottom edge
                position.Y = 0 + radius;
                // Invert velocity to bounce up, scale velocity down a bit
                velocity.Y = -velocity.Y * forceKeptWall;
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

﻿using System;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            double rIn = radius - 0.4;
            double rOut = radius + 0.4;

            for (double y = radius; y >= -radius; y--)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    Console.Write(value >= rIn * rIn && value <= rOut * rOut ? "*" : " ");
                }

                Console.WriteLine();
            }
        }
    }
}

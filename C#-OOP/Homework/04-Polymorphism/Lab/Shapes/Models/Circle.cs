﻿namespace Shapes.Models
{
    using System;

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculatePerimeter() => 2 * Math.PI * radius;

        public override double CalculateArea() => Math.PI * radius * radius;
    }
}

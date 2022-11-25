namespace Shapes
{
    using System;
    
    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape[] shapes = { new Rectangle(10, 20), new Circle(5) };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.Draw());
                Console.WriteLine(shape.CalculateArea());
                Console.WriteLine(shape.CalculatePerimeter());
                Console.WriteLine();
            }
        }
    }
}

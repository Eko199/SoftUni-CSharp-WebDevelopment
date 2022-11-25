namespace Shapes.Models
{
    public class Rectangle : Shape
    {
        private double height, width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculatePerimeter() => 2 * (height + width);

        public override double CalculateArea() => height * width;
    }
}

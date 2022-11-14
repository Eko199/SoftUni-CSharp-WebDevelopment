using System;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBoxFieldMessage, nameof(Length)));

                length = value;
            }
        }

        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBoxFieldMessage, nameof(Width)));

                width = value;
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBoxFieldMessage, nameof(Height)));

                height = value;
            }
        }

        private double SurfaceArea() => 2 * Length * Width + LateralSurfaceArea();

        private double LateralSurfaceArea() => 2 * (Length + Width) * Height;

        private double Volume() => Length * Width * Height;

        public override string ToString()
            => $"Surface Area - {SurfaceArea():F2}" + Environment.NewLine +
               $"Lateral Surface Area - {LateralSurfaceArea():F2}" + Environment.NewLine +
               $"Volume - {Volume():F2}";
    }
}

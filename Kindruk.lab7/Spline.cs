using System;

namespace Kindruk.lab7
{
    public class Spline
    {
        public double A { get; set; }

        public double B { get; set; }

        public double C { get; set; }

        public double D { get; set; }

        public double Left { get; set; }

        public double Right { get; set; }

        public double Calculate(double x)
        {
            if (x < Left || x > Right)
                throw new ArgumentOutOfRangeException("x", "Spline is not builded for this value");
            var dx = x - Left;
            return A + dx*(B + dx*(C + dx*D));
        }

    }
}

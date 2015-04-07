using System;
using System.Collections.Generic;
using MathBase;

namespace Kindruk.lab3
{
    public static class NleSolver
    {

        public const double Epsilon = 0.0001;

        public static int ShturmNumber(Polynom p, double x)
        {
            var result = 0;
            var previous = p;
            var current = p.Derivative(1);
            result += current.Calculate(x) * previous.Calculate(x) > 0 ? 0 : 1;
            while (!current.IsZero())
            {
                var temp = -previous%current;
                previous = current;
                current = temp;
                result += current.Calculate(x) * previous.Calculate(x) > 0 ? 0 : 1;
            }
            return result;
        }

        public static int ShturmRootCount(Polynom p, double a, double b)
        {
            return ShturmNumber(p, a) - ShturmNumber(p, b);
        }

        public static double[] FindRoutes(Polynom p,double a, double b, double stepSize)
        {
            var result = new List<double>();
            for (var x = a; b - x > Epsilon; x += stepSize)
            {
                if (p.Calculate(x)*p.Calculate(x + stepSize) < 0)
                {
                    result.Add(x);
                }
            }
            return result.ToArray();
        }

        public static double FindRootBinarySearchMethod(Polynom p, double x, double stepSize)
        {
            var l = x;
            var r = x + stepSize;
            while (Math.Abs(r - l) > Epsilon)
            {
                var m = (l + r)/2;
                if (p.Calculate(l)*p.Calculate(m) < 0)
                    r = m;
                else l = m;
            }
            return (l + r)/2;
        }

        public static double FindRootChordsMethod(Polynom p, double x, double stepSize)
        {
            var b = x + stepSize;
            double ans;
            if (p.Calculate(x)*p.CalculateDerivative(x, 2) > 0)
            {
                var prevAns = b;
                ans = prevAns - p.Calculate(prevAns)/(p.Calculate(x) - p.Calculate(prevAns))*(x - prevAns);
                while (Math.Abs(prevAns - ans) > Epsilon)
                {
                    prevAns = ans;
                    ans = prevAns - p.Calculate(prevAns) / (p.Calculate(x) - p.Calculate(prevAns)) * (x - prevAns);
                }
            }
            else
            {
                var prevAns = x;
                ans = prevAns - p.Calculate(prevAns)/(p.Calculate(b) - p.Calculate(prevAns))*(b - prevAns);
                while (Math.Abs(prevAns - ans) > Epsilon)
                {
                    prevAns = ans;
                    ans = prevAns - p.Calculate(prevAns) / (p.Calculate(b) - p.Calculate(prevAns)) * (b - prevAns);
                }
            }
            return ans;
        }

        public static double FindRootNewtonMethod(Polynom p, double x)
        {
            var prevAns = x;
            var ans = prevAns - p.Calculate(prevAns)/p.CalculateDerivative(prevAns, 1);
            while (Math.Abs(prevAns - ans) > Epsilon)
            {
                prevAns = ans;
                ans = prevAns - p.Calculate(prevAns) / p.CalculateDerivative(prevAns, 1);
            }
            return ans;
        }
    }
}

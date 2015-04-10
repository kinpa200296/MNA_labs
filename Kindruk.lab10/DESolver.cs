using System;
using MathBase;

namespace Kindruk.lab10
{
    public static class DeSolver
    {
        public static void AdamsMethod(double left, double right, double eps, Func<double, double, double> f,
            out DoubleVector x, out DoubleVector y, double y0, double y1)
        {
            var h = Math.Sqrt(eps);
            var n = (int)((right - left) / h);
            x = new DoubleVector(n + 1);
            y = new DoubleVector(n + 1);
            for (var i = 0; i <= n; i++)
                x[i] = left + h * i;
            y[0] = y0;
            y[1] = y1;
            for (var i = 2; i <= n; i++)
                y[i] = y[i - 1] + h*(1.5*f(x[i - 1], y[i - 1]) - 0.5*f(x[i - 2], y[i - 2]));
        }
    }
}

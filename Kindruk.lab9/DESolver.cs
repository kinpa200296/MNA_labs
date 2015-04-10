using System;
using MathBase;

namespace Kindruk.lab9
{
    public static class DeSolver
    {
        public static void EilerMethod(double left, double right, double eps, Func<double, double, double> f,
            out DoubleVector x, out DoubleVector y, double y0)
        {
            var h = eps;
            var n = (int)((right - left)/h);
            x = new DoubleVector(n + 1);
            y = new DoubleVector(n + 1);
            for (var i = 0; i <= n; i++)
                x[i] = left + h*i;
            y[0] = y0;
            for (var i = 1; i <= n; i++)
                y[i] = y[i - 1] + h*f(x[i - 1] + h/2, y[i - 1] + h/2*f(x[i - 1], y[i - 1]));
        }

        public static void RungeKuttMethod(double left, double right, double eps, Func<double, double, double> f,
            out DoubleVector x, out DoubleVector y, double y0)
        {
            var h = Math.Sqrt(eps);
            var n = (int)((right - left) / h);
            x = new DoubleVector(n + 1);
            y = new DoubleVector(n + 1);
            for (var i = 0; i <= n; i++)
                x[i] = left + h * i;
            y[0] = y0;
            for (var i = 1; i <= n; i++)
            {
                var k1 = h*f(x[i - 1], y[i - 1]);
                var k2 = h*f(x[i - 1] + h/2, y[i - 1] + k1/2);
                var k3 = h*f(x[i - 1] + h/2, y[i - 1] + k2/2);
                var k4 = h*f(x[i - 1] + h, y[i - 1] + k3);
                y[i] = y[i - 1] + (k1 + 2*k2 + 2*k3 + k4)/6.0;
            }
        }
    }
}

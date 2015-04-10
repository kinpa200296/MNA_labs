using System;

namespace Kindruk.lab8
{
    public static class FunctionCalculator
    {
        public static double CalculateFirstDerivative(double x, double eps, Func<double, double> f)
        {
            return (f(x + eps) - f(x - eps)) / (2 * eps);
        }

        public static double CalculateSecondDerivative(double x, double eps, Func<double, double> f)
        {
            return (f(x + eps) - 2 * f(x) + f(x - eps)) / (eps * eps);
        }

        public static double IntegrateSimpsonMethod(double left, double right, double eps, Func<double, double> f)
        {
            var h = Math.Sqrt(eps)/10;
            var n = (int) (right - left)/(2*h);
            var result = f(left) + f(left + h*2*n);
            for (var i = 2; i <= 2*n - 2; i++)
                result += 2*f(left + h*i);
            for (var i = 1; i <= 2*n - 1; i++)
                result += 4*f(left + h*i);
            result *= h/6.0;
            return result;
        }

        public static double IntegrateTrapezoidsMethod(double left, double right, double eps, Func<double, double> f)
        {
            var result = f(left)/2;
            var h = Math.Sqrt(eps) / 10;
            for (var x = left + h; x < right - h; x += h)
            {
                if (x + h > right)
                    result += f(x)/2;
                else result += f(x);
            }
            result *= h;
            return result;
        }

        public static double IntegrateAveragesMethod(double left, double right, double eps, Func<double, double> f)
        {
            var result = 0.0;
            var h = Math.Sqrt(eps)/10;
            for (var x = left; x < right; x += h)
            {
                result += f(x + h/2);
            }
            result *= h;
            return result;
        }
    }
}

using System;
using System.Linq;
using MathBase;

namespace Kindruk.lab4
{
    public static class SnleSolver
    {
        public delegate DoubleVector FunctionMatrix(DoubleVector x);

        public delegate DoubleMatrix JacobiMatrix(DoubleVector x);

        public const double Epsilon = 0.0001;
        public static double[] InitialSolution = {1.0, 0.35};

        public static DoubleVector Phi(DoubleVector x)
        {
            return new DoubleVector(new[]
            {
                Math.Sqrt((1 - 2*x[1]*x[1])/0.7),
                (Math.Atan(x[0]) - 0.4)/x[0]
            });
        }

        public static DoubleVector F(DoubleVector x)
        {
            return new DoubleVector(new[]
            {
                Math.Tan(x[0]*x[1] + 0.4) - x[0],
                0.7*x[0]*x[0] + 2*x[1]*x[1] - 1
            });
        }

        public static DoubleMatrix J(DoubleVector x)
        {
            return new DoubleMatrix(new[,]
            {
                {
                    -(10*x[1]*(Math.Cos(2*x[0]*x[1] + 0.8) + 1))/
                    (10*x[1] + 7*x[0]*x[0] - 20*x[1]*x[1] + 10*x[1]*Math.Cos(2*x[0]*x[1] + 0.8)),
                    (5*x[0])/(20*x[1]*Math.Cos(x[0]*x[1] + 0.4)*Math.Cos(x[0]*x[1] + 0.4) + 7*x[0] - 20*x[1]*x[1])
                },
                {
                    (7*x[0]*(Math.Cos(2*x[0]*x[1] + 0.8) + 1))/
                    (20*x[1] + 14*x[0] - 40*x[1]*x[1] + 20*x[1]*Math.Cos(2*x[0]*x[1] + 0.8)),
                    (5*(Math.Cos(2*x[0]*x[1] + 0.8) - 2*x[1] + 1))/
                    (20*x[1] + 14*x[0] - 40*x[1]*x[1] + 20*x[1]*Math.Cos(2*x[0]*x[1] + 0.8))
                }
            }
                );
        }

        public static DoubleVector SolveWithSimpleIterationsMethod(FunctionMatrix phi)
        {
            var ans = new DoubleVector(InitialSolution);
            DoubleVector prevAns;
            do
            {
                prevAns = ans;
                ans = phi(prevAns);
            } while ((prevAns - ans).Select(x => Math.Abs(x)).Sum() > Epsilon);
            return ans;
        }

        public static DoubleVector SolveWithNewtonMethod(FunctionMatrix f, JacobiMatrix j)
        {
            var ans = new DoubleVector(InitialSolution);
            DoubleVector prevAns;
            do
            {
                prevAns = ans;
                ans = prevAns - j(prevAns)*f(prevAns);
            } while ((prevAns - ans).Select(x => Math.Abs(x)).Sum() > Epsilon);
            return ans;
        }
    }
}

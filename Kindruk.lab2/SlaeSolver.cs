using System;
using System.Linq;
using MathBase;

namespace Kindruk.lab2
{
    public static class SlaeSolver
    {
        public const double Epsilon = 10e-4;

        public enum SolutionStatus
        {
            Solved, NoConvergence
        }

        public static SolutionStatus SimpleIterationMethod(DoubleMatrix matrix, DoubleVector values,
            out DoubleVector answers)
        {
            answers = new DoubleVector(values.Length);
            var b = 1 - matrix;
            var c = values;
            if (b.CubicNorm() < 1 || b.PseudoEuclidNorm() < 1 || b.TetrahedralNorm() < 1)
            {
                return SolutionStatus.NoConvergence;
            }
            DoubleVector prevAns;
            var newAns = new DoubleVector(answers.Length);
            do
            {
                prevAns = new DoubleVector(newAns);
                newAns = b * prevAns + c;
            } while ((newAns - prevAns).Select(val => Math.Abs(val)).Max() > Epsilon);
            answers = newAns;
            return SolutionStatus.Solved;
        }

        public static SolutionStatus ZeidelMethod(DoubleMatrix matrix, DoubleVector values, out DoubleVector answers)
        {
            answers = new DoubleVector(values.Length);
            var temp1 = true;
            var temp2 = true;
            for (var i = 0; i < matrix.RowCount; i++)
            {
                temp1 = temp1 &&
                        (2*Math.Abs(matrix[i, i]) > matrix.GetHorizontalVector(i).Select(val => Math.Abs(val)).Sum());
            }
            for (var j = 0; j < matrix.RowCount; j++)
            {
                temp2 = temp2 &&
                        (2 * Math.Abs(matrix[j, j]) > matrix.GetVerticalVector(j).Select(val => Math.Abs(val)).Sum());
            }
            if (!(temp1 && temp2))
            {
                return SolutionStatus.NoConvergence;
            }
            var b = 1 - matrix;
            var c = values;
            DoubleVector prevAns;
            var newAns = new DoubleVector(answers.Length);
            do
            {
                prevAns = new DoubleVector(newAns);
                for (var i = 0; i < b.RowCount; i++)
                {
                    newAns[i] = c[i];
                    for (var j = 0; j <= i - 1; j++)
                    {
                        newAns[i] += b[i, j]*newAns[j];
                    }
                    for (var j = i; j < b.ColumnCount; j++)
                    {
                        newAns[i] += b[i, j]*prevAns[j];
                    }
                }
            } while ((newAns - prevAns).Select(val => Math.Abs(val)).Max() > Epsilon);
            answers = newAns;
            return SolutionStatus.Solved;
        }
    }
}

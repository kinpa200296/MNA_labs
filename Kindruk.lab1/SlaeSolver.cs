﻿using System;
using System.Linq;
using MathBase;

namespace Kindruk.lab1
{
    public static class SlaeSolver
    {
        public const double Epsilon = 1e-6;

        public enum SolutionStatus
        {
            Solved, TooManySolutions, NoSolution
        }

        public static SolutionStatus SolveGaussMethod(DoubleMatrix matrix, DoubleVector values, out DoubleVector answers)
        {
            answers = new DoubleVector(values.Length);
            for (var i = 0; i < matrix.RowCount; i++)
            {
                if (Math.Abs(matrix[i, i]) < Epsilon)
                {
                    int k;
                    for (k = i + 1; k < matrix.RowCount && Math.Abs(matrix[k, i]) < Epsilon; k++) { }
                    if (k == matrix.RowCount)
                    {
                        for (var k1 = i - 1; k1 >= 0; k1--)
                        {
                            answers[k1] = (values[k1] - matrix[k1] * answers) / matrix[k1, k1];
                        }
                        for (var k1 = 0; k1 < matrix.RowCount; k1++)
                            if (Math.Abs(matrix[k1] * answers - values[k1]) > Epsilon)
                            {
                                return SolutionStatus.NoSolution;
                            }
                        return SolutionStatus.TooManySolutions;
                    }
                    var temp = matrix[k];
                    matrix[k] = matrix[i];
                    matrix[i] = temp;
                }
                var vector = matrix[i];
                for (var j = i + 1; j < matrix.RowCount; j++)
                {
                    values[j] -= values[i] * matrix[j, i] / vector[i];
                    matrix[j] -= vector*matrix[j, i]/vector[i];
                }
            }
            for (var i = matrix.RowCount - 1; i >= 0; i--)
            {
                answers[i] = (values[i] - matrix[i]*answers) / matrix[i,i];
            }
            var ans = answers;
            if ((new DoubleVector(matrix.Select(vector => vector * ans)) - values).Select(val => Math.Abs(val)).Max() >
                Epsilon)
            {
                return SolutionStatus.NoSolution;
            }
            return SolutionStatus.Solved;
        }

        public static SolutionStatus SolveGaussMethodWithSelection(DoubleMatrix matrix, DoubleVector values, out DoubleVector answers)
        {
            answers = new DoubleVector(values.Length);
            for (var i = 0; i < matrix.RowCount; i++)
            {
                var num = i;
                for (var k = i + 1; k < matrix.RowCount; k++)
                {
                    if (Math.Abs(matrix[k, i]) > Math.Abs(matrix[num, i]))
                    {
                        num = k;
                    }
                }
                if (Math.Abs(matrix[num, i]) < Epsilon)
                {
                    for (var k1 = i - 1; k1 >= 0; k1--)
                    {
                        answers[k1] = (values[k1] - matrix[k1] * answers) / matrix[k1, k1];
                    }
                    for (var k1 = 0; k1 < matrix.RowCount; k1++)
                        if (Math.Abs(matrix[k1] * answers - values[k1]) > Epsilon)
                        {
                            return SolutionStatus.NoSolution;
                        }
                    return SolutionStatus.TooManySolutions;
                }
                var temp = matrix[num];
                matrix[num] = matrix[i];
                matrix[i] = temp;
                var temp1 = values[num];
                values[num] = values[i];
                values[i] = temp1;
                var vector = matrix[i];
                for (var j = i + 1; j < matrix.RowCount; j++)
                {
                    values[j] -= values[i] * matrix[j, i] / vector[i];
                    matrix[j] -= vector * matrix[j, i] / vector[i];
                }
            }
            for (var i = matrix.RowCount - 1; i >= 0; i--)
            {
                answers[i] = (values[i] - matrix[i] * answers) / matrix[i, i];
            }
            var ans = answers;
            if ((new DoubleVector(matrix.Select(vector => vector * ans)) - values).Select(val => Math.Abs(val)).Max() >
                Epsilon)
            {
                return SolutionStatus.NoSolution;
            }
            return SolutionStatus.Solved;
        }
    }
}

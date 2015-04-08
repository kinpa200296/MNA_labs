using System;
using System.Linq;
using MathBase;

namespace Kindruk.lab5
{
    public static class EigenSolver
    {
        public const double Epsilon = 0.0001;

        public static void FindEigenValues(DoubleMatrix matrix, out DoubleMatrix eigenVectors,
            out DoubleVector eigenValues)
        {
            var vMatrix = DoubleMatrix.One(matrix.RowCount);
            do
            {
                var vk = DoubleMatrix.One(matrix.RowCount);
                int imax = 0, jmax = 1;
                for (var i = 0; i < matrix.RowCount; i++)
                    for (var j = i + 1; j < matrix.ColumnCount; j++)
                    {
                        if (!(Math.Abs(matrix[i, j]) > Math.Abs(matrix[imax, jmax]))) continue;
                        imax = i;
                        jmax = j;
                    }
                var pk = 2*matrix[imax, jmax]/(matrix[imax,imax] - matrix[jmax, jmax]);
                var cosPhi = Math.Sqrt(0.5*(1 + 1/Math.Sqrt(1 + pk*pk)));
                var sinPhi = Math.Sign(pk)*Math.Sqrt(0.5*(1 - 1/Math.Sqrt(1 + pk*pk)));
                vk[imax, imax] = cosPhi;
                vk[jmax, jmax] = cosPhi;
                vk[imax, jmax] = -sinPhi;
                vk[jmax, imax] = sinPhi;
                vMatrix *= vk;
                var b = new DoubleMatrix(matrix);
                for (var s = 0; s < matrix.RowCount; s++)
                {
                    b[s, imax] = matrix[s, imax]*cosPhi + matrix[s, jmax]*sinPhi;
                    b[s, jmax] = -matrix[s, imax]*sinPhi + matrix[s, jmax]*cosPhi;
                }
                matrix = new DoubleMatrix(b);
                for (var s = 0; s < matrix.RowCount; s++)
                {
                    matrix[imax, s] = b[imax, s]*cosPhi + b[jmax, s]*sinPhi;
                    matrix[jmax, s] = -b[imax, s]*sinPhi + b[jmax, s]*cosPhi;
                }
            } while (matrix.Select(x => x.Select(y => y*y).Sum()).Sum() - matrix.Select((x, i) => x[i]*x[i]).Sum() >
                     Epsilon);
            eigenValues = new DoubleVector(matrix.Select((x, i) => x[i]));
            eigenVectors = vMatrix;
        }

    }
}

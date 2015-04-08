using System;
using System.Globalization;
using System.IO;
using System.Linq;
using MathBase;

namespace MNA_labs.Model
{
    public static class MatrixIoManager
    {
        public static DoubleMatrix LoadMatrix(StreamReader reader)
        {
            var s = reader.ReadLine();
            if (s == null)
            {
                throw new FormatException("File format doesn't match");
            }
            int n;
            if (!int.TryParse(s, out n))
            {
                throw new FormatException("File format doesn't match");
            }
            var matrix = new DoubleMatrix(n, n);
            for (var i = 0; i < n; i++)
            {
                s = reader.ReadLine();
                if (s == null)
                {
                    throw new FormatException("File format doesn't match");
                }
                var c = s.Split(' ').Where(str => !string.IsNullOrWhiteSpace(str)).ToArray();
                if (c.Length != n)
                {
                    throw new FormatException("File format doesn't match");
                }
                for (var j = 0; j < n; j++)
                {
                    double temp;
                    if (!double.TryParse(c[j], NumberStyles.Float, CultureInfo.InvariantCulture, out temp))
                    {
                        throw new FormatException("File format doesn't match");
                    }
                    matrix[i, j] = temp;
                }
            }
            return matrix;
        }

        public static void SaveMatrix(StreamWriter writer, DoubleMatrix matrix)
        {
            foreach (var vector in matrix)
            {
                foreach (var val in vector)
                {
                    writer.Write("{0} ", val.ToString("F6", CultureInfo.InvariantCulture));
                }
                writer.WriteLine();
            }
        }
    }
}

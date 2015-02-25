using System;
using System.Globalization;
using System.IO;
using System.Linq;
using MathBase;

namespace MNA_labs.Model
{
    public static class SlaeIOManager
    {
        public static void LoadSlae(StreamReader reader, out DoubleMatrix matrix, out DoubleVector values)
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
            matrix = new DoubleMatrix(n, n);
            values = new DoubleVector(n);
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
            s = reader.ReadLine();
            if (s == null)
            {
                throw new FormatException("File format doesn't match");
            }
            var c1 = s.Split(' ').Where(str => !string.IsNullOrWhiteSpace(str)).ToArray();
            if (c1.Length != n)
            {
                throw new FormatException("File format doesn't match");
            }
            for (var j = 0; j < n; j++)
            {
                double temp;
                if (!double.TryParse(c1[j], NumberStyles.Float, CultureInfo.InvariantCulture, out temp))
                {
                    throw new FormatException("File format doesn't match");
                }
                values[j] = temp;
            }
        }

        public static void SaveAnswer(StreamWriter writer, DoubleVector answerVector, string solutionResult)
        {
            writer.WriteLine(solutionResult);
            foreach (var val in answerVector)
            {
                writer.Write("{0} ", val.ToString("F4", CultureInfo.InvariantCulture));
            }
        }
    }
}

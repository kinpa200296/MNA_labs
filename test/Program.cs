using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Kindruk.lab3;
using MathBase;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            var p = new Polynom(new[] { 21.9032, -28.064, 2.65804, 1 });
            Console.WriteLine(NleSolver.ShturmRootCount(p, -10, 10));
            var roots = NleSolver.FindRoutes(p, -10, 10, 0.001);
            Console.WriteLine(NleSolver.FindRootBinarySearchMethod(p, roots[0], 0.001));
            Console.WriteLine(NleSolver.FindRootChordsMethod(p, roots[1], 0.001));
            Console.WriteLine(NleSolver.FindRootNewtonMethod(p, roots[2]));
            Console.ReadKey();
            //DoubleMatrix matrix;
            //DoubleVector values;

            ////var C = new DoubleMatrix(new double[,]
            ////{
            ////    {0.2, 0, 0.2, 0, 0},
            ////    {0, 0.2, 0, 0.2, 0},
            ////    {0.2, 0, 0.2, 0, 0.2},
            ////    {0, 0.2, 0, 0.2, 0},
            ////    {0, 0, 0.2, 0, 0.2}
            ////});
            //var C = new DoubleMatrix(new double[,]
            //{
            //    {0.01, 0, -0.02, 0, 0},
            //    {0.01, 0.01, -0.02, 0, 0},
            //    {0, 0.01, 0.01, 0, -0.02},
            //    {0, 0, 0.01, 0.01, 0},
            //    {0, 0, 0, 0.01, 0.01}
            //});
            //var k = 9;
            ////var D = new DoubleMatrix(new double[,]
            ////{
            ////    {2.33, 0.81, 0.67, 0.92, -0.53},
            ////    {-0.53, 2.33, 0.81, 0.67, 0.92},
            ////    {0.92, -0.53, 2.33, 0.81, 0.67},
            ////    {0.67, 0.92, -0.53, 2.33, 0.81},
            ////    {0.81, 0.67, 0.92, -0.53, 2.33}
            ////});
            //var D = new DoubleMatrix(new double[,]
            //{
            //    {1.33, 0.21, 0.17, 0.12, -0.13},
            //    {-0.13, -1.33, 0.11, 0.17, 0.12},
            //    {0.12, -0.13, -1.33, 0.11, 0.17},
            //    {0.17, 0.12, -0.13, -1.33, 0.11},
            //    {0.11, 0.67, 0.12, -0.13, -1.33},
            //});
            //D += k*C;
            ////var b = new DoubleVector(new double[] {4.2, 4.2, 4.2, 4.2, 4.2});
            //var b = new DoubleVector(new double[] { 1.2, 2.2, 4.0, 0.0, -1.2 });
            //using (var file = File.Create(args[0]))
            //{
            //    using (var writer = new StreamWriter(file))
            //    {
            //        writer.WriteLine(D.RowCount);
            //        for (var i = 0; i < D.RowCount; i++)
            //        {
            //            foreach (var val in D[i])
            //            {
            //                writer.Write("{0} ", val.ToString("F4", CultureInfo.InvariantCulture));
            //            }
            //            writer.WriteLine();
            //        }
            //        foreach (var val in b)
            //        {
            //            writer.Write("{0} ", val.ToString("F4", CultureInfo.InvariantCulture));
            //        }
            //    }
            //}
            // /*using (var file = File.OpenRead(args[0]))
            //{
            //    using (var reader = new StreamReader(file))
            //    {
            //        var s = reader.ReadLine();
            //        if (s == null)
            //        {
            //            throw new FormatException("File format doesn't match");
            //        }
            //        int n;
            //        if (!int.TryParse(s, out n))
            //        {
            //            throw new FormatException("File format doesn't match");
            //        }
            //        matrix = new DoubleMatrix(n, n);
            //        values = new DoubleVector(n);
            //        for (var i = 0; i < n; i++)
            //        {
            //            s = reader.ReadLine();
            //            if (s == null)
            //            {
            //                throw new FormatException("File format doesn't match");
            //            }
            //            var c = s.Split(' ').Where(str => !string.IsNullOrWhiteSpace(str)).ToArray();
            //            if (c.Length != n)
            //            {
            //                throw new FormatException("File format doesn't match");
            //            }
            //            for (var j = 0; j < n; j++)
            //            {
            //                double temp;
            //                if (!double.TryParse(c[j], NumberStyles.Float, CultureInfo.InvariantCulture, out temp))
            //                {
            //                    throw new FormatException("File format doesn't match");
            //                }
            //                matrix[i,j] = temp;
            //            }
            //        }
            //        s = reader.ReadLine();
            //        if (s == null)
            //        {
            //            throw new FormatException("File format doesn't match");
            //        }
            //        var c1 = s.Split(' ').Where(str => !string.IsNullOrWhiteSpace(str)).ToArray();
            //        if (c1.Length != n)
            //        {
            //            throw new FormatException("File format doesn't match");
            //        }
            //        for (var j = 0; j < n; j++)
            //        {
            //            double temp;
            //            if (!double.TryParse(c1[j], NumberStyles.Float, CultureInfo.InvariantCulture, out temp))
            //            {
            //                throw new FormatException("File format doesn't match");
            //            }
            //            values[j] = temp;
            //        }
            //    }
            //}
            //DoubleVector ans;
            //var status = Kindruk.lab1.SlaeSolver.SolveGaussMethod(matrix, values, out ans);
            //using (var file = File.Create(args[1]))
            //{
            //    using (var writer = new StreamWriter(file))
            //    {
            //        writer.WriteLine(status);
            //        foreach (var val in ans)
            //        {
            //            writer.Write("{0} ", val.ToString("F4", CultureInfo.InvariantCulture));
            //        }
            //    }
            //}*/
        }
    }
}

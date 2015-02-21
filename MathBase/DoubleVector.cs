using System;
using System.Collections.Generic;
using System.Linq;

namespace MathBase
{
    public class DoubleVector : Vector<double>
    {
        public DoubleVector()
        {
            
        }

        public DoubleVector(int length)
        {
            _data = new double[length];
        }

        public DoubleVector(IEnumerable<double> data)
        {
            _data = data.ToArray();
        }

        public DoubleVector(double[] data)
        {
            _data = new double[data.Length];
            data.CopyTo(_data, 0);
        }

        public static DoubleVector operator +(DoubleVector vector1, DoubleVector vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new ArgumentException("Vector sizes do not match!!!");
            }
            var vector = new DoubleVector(vector1.Length);
            for (var i = 0; i < vector.Length; i++)
            {
                vector[i] = vector1[i] + vector2[i];
            }
            return vector;
        }

        public static DoubleVector operator -(DoubleVector vector1, DoubleVector vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new ArgumentException("Vector sizes do not match!!!");
            }
            var vector = new DoubleVector(vector1.Length);
            for (var i = 0; i < vector.Length; i++)
            {
                vector[i] = vector1[i] - vector2[i];
            }
            return vector;
        }

        public static double operator *(DoubleVector vector1, DoubleVector vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new ArgumentException("Vector sizes do not match!!!");
            }
            return vector1.Select((t, i) => t*vector2[i]).Sum();
        }

        public static DoubleVector operator +(DoubleVector vector, double val)
        {
            return new DoubleVector(vector.Select(t => t + val));
        }

        public static DoubleVector operator -(DoubleVector vector, double val)
        {
            return new DoubleVector(vector.Select(t => t - val));
        }

        public static DoubleVector operator *(DoubleVector vector, double val)
        {
            return new DoubleVector(vector.Select(t => t * val));
        }
        public static DoubleVector operator +(double val, DoubleVector vector)
        {
            return new DoubleVector(vector.Select(t => val + t));
        }

        public static DoubleVector operator -(double val, DoubleVector vector)
        {
            return new DoubleVector(vector.Select(t => val - t));
        }

        public static DoubleVector operator *(double val, DoubleVector vector)
        {
            return new DoubleVector(vector.Select(t => val * t));
        }

        public static DoubleVector operator /(DoubleVector vector, double val)
        {
            return new DoubleVector(vector.Select(t => t / val));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace MathBase
{
    public class IntVector : Vector<int>
    {
        public IntVector()
        {
            
        }

        public IntVector(int length)
        {
            _data = new int[length];
        }

        public IntVector(IEnumerable<int> data)
        {
            _data = data.ToArray();
        }

        public IntVector(int[] data)
        {
            _data = new int[data.Length];
            data.CopyTo(_data, 0);
        }

        public static IntVector operator +(IntVector vector1, IntVector vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new ArgumentException("Vector sizes do not match!!!");
            }
            var vector = new IntVector(vector1.Length);
            for (var i = 0; i < vector.Length; i++)
            {
                vector[i] = vector1[i] + vector2[i];
            }
            return vector;
        }

        public static IntVector operator -(IntVector vector1, IntVector vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new ArgumentException("Vector sizes do not match!!!");
            }
            var vector = new IntVector(vector1.Length);
            for (var i = 0; i < vector.Length; i++)
            {
                vector[i] = vector1[i] - vector2[i];
            }
            return vector;
        }

        public static int operator *(IntVector vector1, IntVector vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new ArgumentException("Vector sizes do not match!!!");
            }
            return vector1.Select((t, i) => t * vector2[i]).Sum();
        }

        public static IntVector operator +(IntVector vector, int val)
        {
            return new IntVector(vector.Select(t => t + val));
        }

        public static IntVector operator -(IntVector vector, int val)
        {
            return new IntVector(vector.Select(t => t - val));
        }

        public static IntVector operator *(IntVector vector, int val)
        {
            return new IntVector(vector.Select(t => t * val));
        }

        public static IntVector operator +(int val, IntVector vector)
        {
            return new IntVector(vector.Select(t => val + t));
        }

        public static IntVector operator -(int val, IntVector vector)
        {
            return new IntVector(vector.Select(t => val - t));
        }

        public static IntVector operator *(int val, IntVector vector)
        {
            return new IntVector(vector.Select(t => val * t));
        }

        public static IntVector operator /(IntVector vector, int val)
        {
            return new IntVector(vector.Select(t => t / val));
        } 
    }
}

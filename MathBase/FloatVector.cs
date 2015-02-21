using System;
using System.Collections.Generic;
using System.Linq;

namespace MathBase
{
    public class FloatVector : Vector<float>
    {
        public FloatVector()
        {
            
        }

        public FloatVector(int length)
        {
            _data = new float[length];
        }

        public FloatVector(IEnumerable<float> data)
        {
            _data = data.ToArray();
        }

        public FloatVector(float[] data)
        {
            _data = new float[data.Length];
            data.CopyTo(_data, 0);
        }

        public static FloatVector operator +(FloatVector vector1, FloatVector vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new ArgumentException("Vector sizes do not match!!!");
            }
            var vector = new FloatVector(vector1.Length);
            for (var i = 0; i < vector.Length; i++)
            {
                vector[i] = vector1[i] + vector2[i];
            }
            return vector;
        }

        public static FloatVector operator -(FloatVector vector1, FloatVector vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new ArgumentException("Vector sizes do not match!!!");
            }
            var vector = new FloatVector(vector1.Length);
            for (var i = 0; i < vector.Length; i++)
            {
                vector[i] = vector1[i] - vector2[i];
            }
            return vector;
        }

        public static float operator *(FloatVector vector1, FloatVector vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new ArgumentException("Vector sizes do not match!!!");
            }
            return vector1.Select((t, i) => t * vector2[i]).Sum();
        }

        public static FloatVector operator +(FloatVector vector, float val)
        {
            return new FloatVector(vector.Select(t => t + val));
        }

        public static FloatVector operator -(FloatVector vector, float val)
        {
            return new FloatVector(vector.Select(t => t - val));
        }

        public static FloatVector operator *(FloatVector vector, float val)
        {
            return new FloatVector(vector.Select(t => t * val));
        }
        public static FloatVector operator +(float val, FloatVector vector)
        {
            return new FloatVector(vector.Select(t => val + t));
        }

        public static FloatVector operator -(float val, FloatVector vector)
        {
            return new FloatVector(vector.Select(t => val - t));
        }

        public static FloatVector operator *(float val, FloatVector vector)
        {
            return new FloatVector(vector.Select(t => val * t));
        }

        public static FloatVector operator /(FloatVector vector, float val)
        {
            return new FloatVector(vector.Select(t => t / val));
        }
    }
}

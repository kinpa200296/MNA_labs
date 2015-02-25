using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MathBase
{
    public class FloatMatrix : Matrix<float>, IEnumerable<FloatVector>
    {
        public FloatMatrix()
        {
        }

        public FloatMatrix(int rowCount, int columnCount)
        {
            _data = new float[rowCount, columnCount];
        }

        public FloatMatrix(float[,] data)
        {
            _data = new float[data.GetLength(0), data.GetLength(1)];
            for (var i = 0; i < data.GetLength(0); i++)
                for (var j = 0; j < data.GetLength(1); j++)
                {
                    _data[i, j] = data[i, j];
                }
        }

        public FloatVector this[int rowNumber]
        {
            get { return GetHorizontalVector(rowNumber); }
            set { SetHorizontalVector(rowNumber, value); }
        }

        public void SetHorizontalVector(int rowNumber, FloatVector vector)
        {
            if (rowNumber < 0 || rowNumber >= RowCount)
            {
                throw new IndexOutOfRangeException("Matrix row number out of range");
            }
            if (vector.Length != ColumnCount)
            {
                throw new ArgumentException("Matrix and vector sizes do not match");
            }
            for (var i = 0; i < ColumnCount; i++)
            {
                _data[rowNumber, i] = vector[i];
            }
        }

        public void SetVerticalVector(int columnNumber, FloatVector vector)
        {
            if (columnNumber < 0 || columnNumber >= RowCount)
            {
                throw new IndexOutOfRangeException("Matrix column number out of range");
            }
            if (vector.Length != RowCount)
            {
                throw new ArgumentException("Matrix and vector sizes do not match");
            }
            for (var i = 0; i < ColumnCount; i++)
            {
                _data[i, columnNumber] = vector[i];
            }
        }

        public FloatVector GetHorizontalVector(int rowNumder)
        {
            if (rowNumder < 0 || rowNumder >= RowCount)
            {
                throw new IndexOutOfRangeException("Matrix row number out of range");
            }
            var vector = new FloatVector(ColumnCount);
            for (var i = 0; i < ColumnCount; i++)
            {
                vector[i] = _data[rowNumder, i];
            }
            return vector;
        }

        public FloatVector GetVerticalVector(int columnNumder)
        {
            if (columnNumder < 0 || columnNumder >= ColumnCount)
            {
                throw new IndexOutOfRangeException("Matrix column number out of range");
            }
            var vector = new FloatVector(RowCount);
            for (var i = 0; i < RowCount; i++)
            {
                vector[i] = _data[i, columnNumder];
            }
            return vector;
        }

        public static FloatMatrix operator +(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            if (matrix1.RowCount != matrix2.RowCount || matrix1.ColumnCount != matrix2.ColumnCount)
            {
                throw new ArgumentException("Matrix size doesn't match. Cannot sum.");
            }
            var matrix = new FloatMatrix(matrix1.RowCount, matrix1.ColumnCount);
            for (var i = 0; i < matrix.RowCount; i++)
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            return matrix;
        }

        public static FloatMatrix operator -(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            if (matrix1.RowCount != matrix2.RowCount || matrix1.ColumnCount != matrix2.ColumnCount)
            {
                throw new ArgumentException("Matrix size doesn't match. Cannot sum.");
            }
            var matrix = new FloatMatrix(matrix1.RowCount, matrix1.ColumnCount);
            for (var i = 0; i < matrix.RowCount; i++)
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            return matrix;
        }

        public static FloatMatrix operator *(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            if (matrix1.ColumnCount != matrix2.RowCount)
            {
                throw new ArgumentException("Matrices are inconsistent. Cannot multiply.");
            }
            var matrix = new FloatMatrix(matrix1.RowCount, matrix2.ColumnCount);
            for (var i = 0; i < matrix.RowCount; i++)
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] = matrix1.GetHorizontalVector(i) * matrix2.GetVerticalVector(j);
                }
            return matrix;
        }

        public static FloatVector operator *(FloatMatrix matrix, FloatVector vector)
        {
            if (matrix.ColumnCount != vector.Length)
            {
                throw new ArgumentException("Matrix and vector are inconsistent. Cannot multiply.");
            }
            return new FloatVector(matrix.Select(v => v * vector));
        }

        public static FloatVector operator *(FloatVector vector, FloatMatrix matrix)
        {
            return matrix * vector;
        }

        public static FloatMatrix operator +(FloatMatrix matrix, float val)
        {
            var result = new FloatMatrix(matrix.RowCount, matrix.ColumnCount);
            for (var i = 0; i < result.RowCount; i++)
                for (var j = 0; j < result.ColumnCount; j++)
                {
                    result[i, j] = matrix[i, j] + val;
                }
            return result;
        }

        public static FloatMatrix operator +(float val, FloatMatrix matrix)
        {
            return matrix + val;
        }

        public static FloatMatrix operator -(FloatMatrix matrix, float val)
        {
            var result = new FloatMatrix(matrix.RowCount, matrix.ColumnCount);
            for (var i = 0; i < result.RowCount; i++)
                for (var j = 0; j < result.ColumnCount; j++)
                {
                    result[i, j] = matrix[i, j] - val;
                }
            return result;
        }

        public static FloatMatrix operator -(float val, FloatMatrix matrix)
        {
            var result = new FloatMatrix(matrix.RowCount, matrix.ColumnCount);
            for (var i = 0; i < result.RowCount; i++)
                for (var j = 0; j < result.ColumnCount; j++)
                {
                    result[i, j] = val - matrix[i, j];
                }
            return result;
        }

        public static FloatMatrix operator *(FloatMatrix matrix, float val)
        {
            var result = new FloatMatrix(matrix.RowCount, matrix.ColumnCount);
            for (var i = 0; i < result.RowCount; i++)
                for (var j = 0; j < result.ColumnCount; j++)
                {
                    result[i, j] = matrix[i, j] * val;
                }
            return result;
        }

        public static FloatMatrix operator *(float val, FloatMatrix matrix)
        {
            return matrix * val;
        }

        public static FloatMatrix operator /(FloatMatrix matrix, float val)
        {
            var result = new FloatMatrix(matrix.RowCount, matrix.ColumnCount);
            for (var i = 0; i < result.RowCount; i++)
                for (var j = 0; j < result.ColumnCount; j++)
                {
                    result[i, j] = matrix[i, j] / val;
                }
            return result;
        }

        public IEnumerator<FloatVector> GetEnumerator()
        {
            return new HorizontalVectorEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class HorizontalVectorEnumerator : IEnumerator<FloatVector>
        {
            private int _index = -1;
            private FloatMatrix _matrix;

            public HorizontalVectorEnumerator(FloatMatrix matrix)
            {
                _matrix = matrix;
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                _index++;
                return _index < _matrix.RowCount;
            }

            public void Reset()
            {
                _index = -1;
            }

            public FloatVector Current { get { return _matrix.GetHorizontalVector(_index); } }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }

        public float CubicNorm()
        {
            return this.Select(vector => vector.Select(val => Math.Abs(val)).Sum()).Max();
        }

        public float PseudoEuclidNorm()
        {
            return this.Select(vector => vector.Select(val => val * val).Sum()).Sum();
        }

        public float TetrahedralNorm()
        {
            float result = 0;
            for (var j = 0; j < ColumnCount; j++)
            {
                var temp = GetVerticalVector(j).Select(val => Math.Abs(val)).Sum();
                if (temp > result)
                {
                    result = temp;
                }
            }
            return result;
        }
    }
}

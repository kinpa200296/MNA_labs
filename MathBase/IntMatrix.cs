using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MathBase
{
    public class IntMatrix : Matrix<int>, IEnumerable<IntVector>
    {
        public IntMatrix()
        {
        }

        public IntMatrix(int rowCount, int columnCount)
        {
            _data = new int[rowCount, columnCount];
        }

        public IntMatrix(int[,] data)
        {
            _data = new int[data.GetLength(0), data.GetLength(1)];
            for (var i = 0; i < data.GetLength(0); i++)
                for (var j = 0; j < data.GetLength(1); j++)
                {
                    _data[i,j] = data[i,j];
                }
        }

        public IntVector this[int rowNumber]
        {
            get { return GetHorizontalVector(rowNumber); }
            set { SetHorizontalVector(rowNumber, value); }
        }

        public void SetHorizontalVector(int rowNumber, IntVector vector)
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

        public void SetVerticalVector(int columnNumber, IntVector vector)
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

        public IntVector GetHorizontalVector(int rowNumder)
        {
            if (rowNumder < 0 || rowNumder >= RowCount)
            {
                throw new IndexOutOfRangeException("Matrix row number out of range");
            }
            var vector = new IntVector(ColumnCount);
            for (var i = 0; i < ColumnCount; i++)
            {
                vector[i] = _data[rowNumder, i];
            }
            return vector;
        }

        public IntVector GetVerticalVector(int columnNumder)
        {
            if (columnNumder < 0 || columnNumder >= ColumnCount)
            {
                throw new IndexOutOfRangeException("Matrix column number out of range");
            }
            var vector = new IntVector(RowCount);
            for (var i = 0; i < RowCount; i++)
            {
                vector[i] = _data[i, columnNumder];
            }
            return vector;
        }

        public static IntMatrix operator +(IntMatrix matrix1, IntMatrix matrix2)
        {
            if (matrix1.RowCount != matrix2.RowCount || matrix1.ColumnCount != matrix2.ColumnCount)
            {
                throw new ArgumentException("Matrix size doesn't match. Cannot sum.");
            }
            var matrix = new IntMatrix(matrix1.RowCount, matrix1.ColumnCount);
            for (var i = 0; i < matrix.RowCount; i++)
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            return matrix;
        }

        public static IntMatrix operator -(IntMatrix matrix1, IntMatrix matrix2)
        {
            if (matrix1.RowCount != matrix2.RowCount || matrix1.ColumnCount != matrix2.ColumnCount)
            {
                throw new ArgumentException("Matrix size doesn't match. Cannot sum.");
            }
            var matrix = new IntMatrix(matrix1.RowCount, matrix1.ColumnCount);
            for (var i = 0; i < matrix.RowCount; i++)
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            return matrix;
        }

        public static IntMatrix operator *(IntMatrix matrix1, IntMatrix matrix2)
        {
            if (matrix1.ColumnCount != matrix2.RowCount)
            {
                throw new ArgumentException("Matrices are inconsistent. Cannot multiply.");
            }
            var matrix = new IntMatrix(matrix1.RowCount, matrix2.ColumnCount);
            for (var i = 0; i < matrix.RowCount; i++)
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] = matrix1.GetHorizontalVector(i)*matrix2.GetVerticalVector(j);
                }
            return matrix;
        }

        public static IntVector operator *(IntMatrix matrix, IntVector vector)
        {
            if (matrix.ColumnCount != vector.Length)
            {
                throw new ArgumentException("Matrix and vector are inconsistent. Cannot multiply.");
            }
            return new IntVector(matrix.Select(v => v*vector));
        }

        public static IntVector operator *(IntVector vector, IntMatrix matrix)
        {
            return matrix*vector;
        }


        public static IntMatrix operator +(IntMatrix matrix, int val)
        {
            var result = new IntMatrix(matrix.RowCount, matrix.ColumnCount);
            for (var i = 0; i < result.RowCount; i++)
                for (var j = 0; j < result.ColumnCount; j++)
                {
                    result[i, j] = matrix[i, j] + val;
                }
            return result;            
        }

        public static IntMatrix operator +(int val, IntMatrix matrix)
        {
            return matrix + val;
        }

        public static IntMatrix operator -(IntMatrix matrix, int val)
        {
            var result = new IntMatrix(matrix.RowCount, matrix.ColumnCount);
            for (var i = 0; i < result.RowCount; i++)
                for (var j = 0; j < result.ColumnCount; j++)
                {
                    result[i, j] = matrix[i, j] - val;
                }
            return result;
        }

        public static IntMatrix operator -(int val, IntMatrix matrix)
        {
            var result = new IntMatrix(matrix.RowCount, matrix.ColumnCount);
            for (var i = 0; i < result.RowCount; i++)
                for (var j = 0; j < result.ColumnCount; j++)
                {
                    result[i, j] = val - matrix[i, j];
                }
            return result;
        }

        public static IntMatrix operator *(IntMatrix matrix, int val)
        {
            var result = new IntMatrix(matrix.RowCount, matrix.ColumnCount);
            for (var i = 0; i < result.RowCount; i++)
                for (var j = 0; j < result.ColumnCount; j++)
                {
                    result[i, j] = matrix[i, j] * val;
                }
            return result;
        }

        public static IntMatrix operator *(int val,IntMatrix matrix)
        {
            return matrix*val;
        }

        public static IntMatrix operator /(IntMatrix matrix, int val)
        {
            var result = new IntMatrix(matrix.RowCount, matrix.ColumnCount);
            for (var i = 0; i < result.RowCount; i++)
                for (var j = 0; j < result.ColumnCount; j++)
                {
                    result[i, j] = matrix[i, j]/val;
                }
            return result;
        }

        public IEnumerator<IntVector> GetEnumerator()
        {
            return new HorizontalVectorEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class HorizontalVectorEnumerator : IEnumerator<IntVector>
        {
            private int _index = -1;
            private IntMatrix _matrix;

            public HorizontalVectorEnumerator(IntMatrix matrix)
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

            public IntVector Current { get { return _matrix.GetHorizontalVector(_index); } }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }

        public int CubicNorm()
        {
            return this.Select(vector => vector.Select(val => Math.Abs(val)).Sum()).Max();
        }

        public int PseudoEuclidNorm()
        {
            return this.Select(vector => vector.Select(val => val*val).Sum()).Sum();
        }

        public int TetrahedralNorm()
        {
            var result = 0;
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

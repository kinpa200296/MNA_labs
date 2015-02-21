using System;

namespace MathBase
{
    public class FloatMatrix : Matrix<float>
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
            for (var i = 0; i < matrix1.RowCount; i++)
                for (var j = 0; j < matrix2.ColumnCount; j++)
                {
                    matrix1[i, j] += matrix2[i, j];
                }
            return matrix1;
        }

        public static FloatMatrix operator -(FloatMatrix matrix1, FloatMatrix matrix2)
        {
            if (matrix1.RowCount != matrix2.RowCount || matrix1.ColumnCount != matrix2.ColumnCount)
            {
                throw new ArgumentException("Matrix size doesn't match. Cannot deduct.");
            }
            for (var i = 0; i < matrix1.RowCount; i++)
                for (var j = 0; j < matrix2.ColumnCount; j++)
                {
                    matrix1[i, j] -= matrix2[i, j];
                }
            return matrix1;
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

        public static FloatMatrix operator +(FloatMatrix matrix, int val)
        {
            for (var i = 0; i < matrix.RowCount; i++)
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] += val;
                }
            return matrix;
        }

        public static FloatMatrix operator +(int val, FloatMatrix matrix)
        {
            for (var i = 0; i < matrix.RowCount; i++)
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] += val;
                }
            return matrix;
        }

        public static FloatMatrix operator -(FloatMatrix matrix, int val)
        {
            for (var i = 0; i < matrix.RowCount; i++)
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] -= val;
                }
            return matrix;
        }

        public static FloatMatrix operator -(int val, FloatMatrix matrix)
        {
            for (var i = 0; i < matrix.RowCount; i++)
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] = val - matrix[i, j];
                }
            return matrix;
        }

        public static FloatMatrix operator *(FloatMatrix matrix, int val)
        {
            for (var i = 0; i < matrix.RowCount; i++)
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] *= val;
                }
            return matrix;
        }

        public static FloatMatrix operator *(int val, FloatMatrix matrix)
        {
            for (var i = 0; i < matrix.RowCount; i++)
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] += val;
                }
            return matrix;
        }

        public static FloatMatrix operator /(FloatMatrix matrix, int val)
        {
            for (var i = 0; i < matrix.RowCount; i++)
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] /= val;
                }
            return matrix;
        }
    }
}

using System;

namespace CW03
{
    class Matrix<T>
    {
        private T[][] _matrix;
        private int _height;
        private int _width;
        protected ICalculator<T> _calculator;              //dla obliczeń na każdym typie

        public int Height { get { return _height; } }
        public int Width { get { return _width; } }

        public Matrix(int height, int width)     //zezwalamy na generowanie macierzy o typach wartości wyłącznie int, double, float i Complex<T>
        {
            Type matrixType = typeof(T);

            if (matrixType == typeof(int) || matrixType == typeof(double) || matrixType == typeof(float) || matrixType == typeof(Complex<int>)
                || matrixType == typeof(Complex<double>) || matrixType == typeof(Complex<float>))
            {
                _height = height;
                _width = width;
                _matrix = new T[_height][];
                _calculator = Calculator.GetInstance<T>();

                for (int i = 0; i < _height; i++)
                {
                    _matrix[i] = new T[_width];
                    for(int j=0; j<_width; j++ )
                    {
                        _matrix[i][j] = _calculator.GetZero();
                    }
                }
            }
            else throw new ApplicationException("Not allowed type of matrix arguments");
        }

        public T Element(int row, int column)
        {
            if (row >= 0 && row <= _height && column >= 0 && column <= _width)
                return _matrix[row][column];
            else throw new ArgumentOutOfRangeException();
        }

        public void Put(int row, int column, T element)
        {
            if (row >= 0 && row <= _height && column >= 0 && column <= _width)
                _matrix[row][column] = element;
            else
            {
                Console.WriteLine("Out of range row or column ! ");
            }
        }

        public void Add(int row, int column, T addition)
        {
            if (row >= 0 && row <= _height && column >= 0 && column <= _width)
            {
               _matrix[row][column] = _calculator.Add(_matrix[row][column], addition);
            }
            else
            {
                Console.WriteLine("Out of range row or column ! ");
            }
        }

        public void Multiply(int row, int column, T addition)
        {
            if (row >= 0 && row <= _height && column >= 0 && column <= _width)
            {
                _matrix[row][column] = _calculator.Multiply(_matrix[row][column], addition);
            }
            else
            {
                Console.WriteLine("Out of range row or column ! ");
            }
        }

        public Matrix<T> Add(Matrix<T> adder)
        {
            if (this._height == adder._height && this._width == adder._width)
            {
                Matrix<T> newMatrix = new Matrix<T>(this._height, this._width);

                for (int i=0; i<this._height; i++)
                {
                    for(int j=0; j<this._width; j++)
                    {
                        newMatrix.Put(i, j, _calculator.Add(this._matrix[i][j], adder._matrix[i][j]));
                    }
                }

                return newMatrix;
            }
            else
            {
                Console.WriteLine("Different sizes of matrixes!");
                return null;
            }
        }

        public Matrix<T> Multiply(Matrix<T> multiplier)
        {

            if(this._height == multiplier._width && this._width == multiplier._height)
            {
                Matrix<T> newMatrix = new Matrix<T>(this._height, multiplier._width);
                for (int i = 0; i < newMatrix._height; i++)
                {
                    for (int j = 0; j < newMatrix._width; j++)
                    {
                        newMatrix._matrix[i][j] = newMatrix._calculator.GetZero();

                        for (int x = 0; x < this._width; x++)
                        {
                            newMatrix._matrix[i][j] = this._calculator.Add( newMatrix._matrix[i][j],
                                this._calculator.Multiply(this._matrix[i][x], multiplier._matrix[x][j]));
                        }
                    }
                }

                return newMatrix;
            }
            else
            {
                Console.WriteLine("Not proper sizes of matrixes for multiplication");
                return null;
            }
        }

        public void Display()
        {
            for (int i = 0; i < _height; i++)
            {
                for(int j = 0; j < _width; j++)
                {
                    Console.Write(_matrix[i][j]+" ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();

        }

    }

    class SquareMatrix<T> : Matrix<T>
    {
        public SquareMatrix(int size) : base(size, size){}

        public bool IsDiagonal()
        { 

            for(int i=0; i<base.Height; i++)
            {
                for(int j=0; j<base.Width; j++)
                {
                    if (i != j && !base._calculator.IsZero(base.Element(i, j)))
                        return false;
                }
            }

            return true;
        }
    }

    class TestFor5
    {
        public static void Test()
        {
            TestAddMultiply();
            Test1();
            Test2();
            Test3();
            Test5();
            Test6();
           // Test4();
        }

        private static void Test1()
        {
            Console.WriteLine("Sprawdzenie macierzy na <int>");
            Matrix<int> matint = new Matrix<int>(5, 6);
            matint.Display();
            
            matint.Put(1, 1, 5);
            matint.Put(2, 3, 6);
            matint.Put(4, 5, 10);

            matint.Display();

            matint.Add(2, 2, 18);
            matint.Add(1, 1, 3);
            matint.Multiply(3, 3, 7);
            matint.Multiply(4, 5, 2);

            matint.Display();

        }

        private static void Test2()
        {
            Console.WriteLine("Sprawdzenie macierzy na <double>");
            Matrix<double> matdouble = new Matrix<double>(4, 4);
            matdouble.Display();

            matdouble.Put(1, 1, 5.6);
            matdouble.Put(2, 3, 6.6);
            matdouble.Put(0, 1, 0.5);
            matdouble.Put(4, 5, 10.3);

            matdouble.Display();

            matdouble.Add(2, 2, 18);
            matdouble.Add(1, 1, 3);
            matdouble.Multiply(3, 3, 7);
            matdouble.Multiply(0, 1, 4);
            matdouble.Multiply(4, 5, 2);

            matdouble.Display();

        }

        private static void Test3()
        {
            Console.WriteLine("Sprawdzenie macierzy kwadratowej na <int>");
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(5);

            squareMatrix.Put(1, 1, 5);
            squareMatrix.Put(2, 2, 4);
            squareMatrix.Put(3, 3, 6);
            squareMatrix.Put(0, 0, 3);

            squareMatrix.Display();
            Console.WriteLine("Square Matrix is diagonal ? = " + squareMatrix.IsDiagonal());

            squareMatrix.Add(2, 3, 6);
            squareMatrix.Multiply(1, 1, 5);

            squareMatrix.Display();
            Console.WriteLine("Square Matrix is diagonal ? = " + squareMatrix.IsDiagonal());

        }

        private static void Test5()
        {
            Console.WriteLine("Sprawdzenie macierzy na  <Complex<int>>");
            Matrix<Complex<int>> matint = new Matrix<Complex<int>>(5, 6);
            matint.Display();

            matint.Put(1, 1, new Complex<int>(4,5));
            matint.Put(2, 3, new Complex<int>(2,2));
            matint.Put(4, 5, new Complex<int>(1,1));

            matint.Display();

            matint.Add(2, 2, new Complex<int>(10,10));
            matint.Add(1, 1, new Complex<int>(11,11));
            matint.Multiply(3, 3, new Complex<int>(6,6));
            matint.Multiply(4, 5, new Complex<int>(9,9));

            matint.Display();
        }

        private static void Test6()
        {
            Console.WriteLine("Sprawdzenie macierzy kwadratowej na <Complex<double>>");
            SquareMatrix<Complex<double>> squareMatrix = new SquareMatrix<Complex<double>>(5);

            squareMatrix.Put(1, 1, new Complex<double>(3,3));
            squareMatrix.Put(2, 2, new Complex<double>(1,2));
            squareMatrix.Put(3, 3, new Complex<double>(7,8));
            squareMatrix.Put(0, 0, new Complex<double>(0,8));

            squareMatrix.Display();
            Console.WriteLine("Square Matrix is diagonal ? = " + squareMatrix.IsDiagonal());

            squareMatrix.Add(2, 3, new Complex<double>(2,2));
            squareMatrix.Multiply(1, 1, new Complex<double>(4,4));

            squareMatrix.Display();
            Console.WriteLine("Square Matrix is diagonal ? = " + squareMatrix.IsDiagonal());

        }

        private static void TestAddMultiply()
        {
            Matrix<int> add1 = new Matrix<int>(3, 3);
            add1.Put(1, 1, 4);
            add1.Put(1, 2, 5);
            add1.Put(0, 0, 3);
            Console.WriteLine("add1 : ");
            add1.Display();

            Matrix<int> add2 = new Matrix<int>(3, 3);
            add2.Put(1, 1, 2);
            add2.Put(1, 2, 3);
            add2.Put(0, 0, 6);
            add2.Put(0, 1, -4);

            Console.WriteLine("add2 : ");
            add2.Display();

            Console.WriteLine("add1 + add2 : ");
            var add = add1.Add(add2);
            add.Display();

            Matrix<int> mult1 = new Matrix<int>(3, 2);
            mult1.Put(0, 0, 1);
            mult1.Put(0, 1, 1);
            mult1.Put(1, 0, 2);
            mult1.Put(1, 1, 2);
            mult1.Put(2, 0, 3);
            mult1.Put(2, 1, 3);

            Console.WriteLine("mult1 : ");
            mult1.Display();

            Matrix<int> mult2 = new Matrix<int>(2, 3);
            mult2.Put(0, 0, 1);
            mult2.Put(0, 1, 1);
            mult2.Put(0, 2, 1);
            mult2.Put(1, 0, 2);
            mult2.Put(1, 1, 2);
            mult2.Put(1, 2, 2);

            Console.WriteLine("mult2 : ");
            mult2.Display();

            Console.WriteLine("mult1*mult2 = ");
            var mult = mult1.Multiply(mult2);
            mult.Display();

            add2.Multiply(mult1);
            var add3 = add1.Multiply(add2);
            add3.Display();

        }

        private static void Test4()
        {
            Console.WriteLine("Sprawdzenie podania w macierz niedozwolonego typu");
           // Matrix<String> stringmatrix = new Matrix<string>(3, 4);
            SquareMatrix<bool> boolmatrix = new SquareMatrix<bool>(5);
        }


    }
}

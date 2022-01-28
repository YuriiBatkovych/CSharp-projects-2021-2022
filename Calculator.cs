using System;

namespace CW03
{
    interface ICalculator<T>
    {
        T Add(T x, T y);
        T Multiply(T x, T y);

        bool IsZero(T x);
        T GetZero();
    }

    class CalculatorInt : ICalculator<int>
    {
        public int Add(int x, int y) { return x + y; }
        public int Multiply(int x, int y) { return x * y; }

        public bool IsZero(int x) { return x == 0; }

        public int GetZero() { return 0; }


    }

    class CalculatorDouble : ICalculator<double>
    {
        public double Add(double x, double y) { return x + y; }
        public double Multiply(double x, double y) { return x * y; }
        public bool IsZero(double x) { return x == 0; }

        public double GetZero() { return 0; }
    }

    class CalculatorFloat : ICalculator<float>
    {
        public float Add(float x, float y) { return x + y; }
        public float Multiply(float x, float y) { return x * y; }

        public bool IsZero(float x) { return x == 0; }

        public float GetZero() { return 0; }
    }

    class CalculatorComplexI : ICalculator<Complex<int>>
    {
        public Complex<int> Add(Complex<int> x, Complex<int> y)
        {
            int newReal = x.Real() + y.Real();
            int newImaginary = x.Imaginary() + y.Imaginary();

            return new Complex<int>(newReal, newImaginary);
        }

        public bool IsZero(Complex<int> x)
        {
            return (x.Real() == 0) && (x.Imaginary() == 0);
        }

        public Complex<int> Multiply(Complex<int> x, Complex<int> y)
        {
            int newReal = x.Real() * y.Real() - x.Imaginary()*y.Imaginary();
            int newImaginary = x.Real() * y.Imaginary() + x.Imaginary() * y.Real();

            return new Complex<int>(newReal, newImaginary);
        }

        public Complex<int> GetZero() { return new Complex<int>(0,0); }
    }

    class CalculatorComplexD : ICalculator<Complex<double>>
    {
        public Complex<double> Add(Complex<double> x, Complex<double> y)
        {
            double newReal = x.Real() + y.Real();
            double newImaginary = x.Imaginary() + y.Imaginary();

            return new Complex<double>(newReal, newImaginary);
        }

        public bool IsZero(Complex<double> x)
        {
            return (x.Real() == 0) && (x.Imaginary() == 0);
        }

        public Complex<double> Multiply(Complex<double> x, Complex<double> y)
        {
            double newReal = x.Real() * y.Real() - x.Imaginary() * y.Imaginary();
            double newImaginary = x.Real() * y.Imaginary() + x.Imaginary() * y.Real();

            return new Complex<double>(newReal, newImaginary);
        }

        public Complex<double> GetZero() { return new Complex<double>(0, 0); }
    }

    class CalculatorComplexF : ICalculator<Complex<float>>
    {
        public Complex<float> Add(Complex<float> x, Complex<float> y)
        {
            float newReal = x.Real() + y.Real();
            float newImaginary = x.Imaginary() + y.Imaginary();

            return new Complex<float>(newReal, newImaginary);
        }

        public bool IsZero(Complex<float> x)
        {
            return (x.Real() == 0) && (x.Imaginary() == 0);
        }

        public Complex<float> Multiply(Complex<float> x, Complex<float> y)
        {
            float newReal = x.Real() * y.Real() - x.Imaginary() * y.Imaginary();
            float newImaginary = x.Real() * y.Imaginary() + x.Imaginary() * y.Real();

            return new Complex<float>(newReal, newImaginary);
        }

        public Complex<float> GetZero() { return new Complex<float>(0, 0); }
    }

    static class Calculator
    {
        public static ICalculator<T> GetInstance<T>()
        {
            Type matrixType = typeof(T);

            if (matrixType == typeof(int)) return (ICalculator<T>)new CalculatorInt();
            if (matrixType == typeof(double)) return (ICalculator<T>)new CalculatorDouble();
            if (matrixType == typeof(float)) return (ICalculator<T>)new CalculatorFloat();
            if (matrixType == typeof(Complex<int>)) return (ICalculator<T>)new CalculatorComplexI();
            if (matrixType == typeof(Complex<double>)) return (ICalculator<T>)new CalculatorComplexD();
            /*if (matrixType == typeof(Complex<float>))*/ return (ICalculator<T>)new CalculatorComplexF();
        }
    }
}

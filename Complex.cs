using System;

namespace CW03
{
    class Complex <T> 
    {
        private T _real;
        private T _imaginary;                   //jako że Complex to liczby zespolone , i ,ponadto, ta klasa musi być potem wykorzystana
                                                //w zadaniu z macierzami gdzie wymagane jest zdefiniowanie mnorzenia i dodawania na elementach macierzy
        public Complex(T real, T imaginary)     //i zezwolenie tylko na sensowne typy numeryczne (int , double, float), to tutaj też zezwalam tylko na int      
        {                                                           // double i float
            Type argumetType = typeof(T);
            if(argumetType == typeof(int) || argumetType == typeof(double) || argumetType == typeof(float))
            {
                _real = real;
                _imaginary = imaginary;
            }
            else throw new ApplicationException("Not allowed type of complex number arguments");
        }

        public T Real() { return _real; }
        public T Imaginary() { return _imaginary; }

        public override string ToString()
        {
            String s = _real + " + " + _imaginary + "i ";
            return s;
        }
    }


    class TestFor4
    {
        public static void Test()
        {
            Complex<int> c1 = new Complex<int>(2, 3);
            Complex<double> c2 = new Complex<double>(2, 3.7888);
            Complex<float> c3 = new Complex<float>(1.45f, 1.5f);
            //Complex<string, string> c4 = new Complex<string, string>("complex_real", "complex_imaginary");

            Console.WriteLine("C1 real = " + c1.Real() + " imaginary = " + c1.Imaginary());
            Console.WriteLine("C2 real = " + c2.Real() + " imaginary = " + c2.Imaginary());
            Console.WriteLine("C3 real = " + c3.Real() + " imaginary = " + c3.Imaginary());
            //Console.WriteLine("C4 real = " + c4.Real() + " imaginary = " + c4.Imaginary());
        }
    }
}

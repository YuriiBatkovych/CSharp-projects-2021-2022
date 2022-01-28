using System;

//proponowane projektowanie klas Rectangle i Square, żeby nie naruszały zasady Liskov - wprowaszenie nowej własności side
//do klasy Square oraz zrobienie Rectangle niemutowalnym (nie jest dozwolona zmiana długości i szyrokości Rectangle)



namespace CW03
{

    class Rectangle 
    {
        protected int _height;
        protected int _width;
        public virtual int Height { get { return _height; } }
        public virtual int Width { get { return _width; } }

        public Rectangle(int height, int width)
        {
            this._width = width;
            this._height = height;
        }

        public int GetArea()
        {
            return Width * Height;
        }
    }


    class Square : Rectangle
    {
        private int _side;

        public Square(int side) : base(side, side)
        {
            this._side = side;
        }
        public virtual int Side
        {
            get => _side;
            set => _side = base._width = base._height =  value;
        }
    }

    class TestFor1
    {
        public static void Method(Rectangle r)
        {
         
            int area = r.GetArea();
            Console.WriteLine("Area of the rectangle is " + area);
        }

    }

}
using System;
using System.Collections;


namespace CW03
{
    class QueueInheritAL : ArrayList                          //kolejka dziedzicząca po ArrayLiscie (inherit ArrayList)
    {

        public void Enqueue(Object value) 
        {
            base.Add(value);
        }
        
        public Object Dequeue() 
        {
            Object o = base[0];
            base.RemoveAt(0);
            return o;
        }

        public int Length()
        {
            return base.Count;
        }
    }

    class QueueBasedOnAL                                   //kolejka działająca na ArrayLiscie przez kompozycję (based on ArrayList)
    {
        private ArrayList _arrayList;

        public QueueBasedOnAL()
        {
            _arrayList = new ArrayList();
        }

        public void Enqueue(Object value)
        {
            _arrayList.Add(value);
        }

        public Object Dequeue()
        {
            Object o = _arrayList[0];
            _arrayList.RemoveAt(0);
            return o;
        }

        public int Length()
        {
            return _arrayList.Count;
        }

    }

    //ponieważ dziedziczenie po System.Array (przy próbie dziedziczenia otrzymujemy błąd :
    //"Queue cannot derive from special class System.Array)
    //nie jest dozwolone w C#, w obu przypadkach musimy implementować kolejkę działającą na tablicy poprzez 
    //kompozycję 

    class QueueOnArray
    {
        private Object[] _array;
        private int _max;
        private int _length;

        public int Length { get { return _length; } }
        
        public QueueOnArray()
        {
            _length = 0;
            _max = 2;
            _array = new Object[_max];
        }

        private void _inLarge()
        {
            _max *= 2;
            Object[] _newArray = new Object[_max];

            for(int i=0; i<_length; i++)
            {
                _newArray[i] = _array[i];
            }

            _array = _newArray;
        }

        public void Enqueue(Object value)
        {
            _array[_length] = value;
            _length++;

            if (_length == _max) _inLarge();
        }

        public Object Dequeue()
        {
            Object o = _array[0];
            _length--;
            for(int i=0; i<_length; i++)
            {
                _array[i] = _array[i + 1];
            }

            return o;
        }
    }

    
    class TestFor2and3
    {
        public static void Test1()
        {
            Console.WriteLine("Sprawdzanie działania kolejki dziedziczącej po ArrayLiscie");

            QueueInheritAL q = new QueueInheritAL();
            q.Enqueue(2);
            q.Enqueue(4);
            q.Enqueue(6.6);
            q.Enqueue(new Rectangle(3,4));

            int lenght = q.Length();

            while (q.Length() > 0)
            {
                Console.WriteLine(q.Dequeue());
            }
        }

        public static void Test2()
        {
            Console.WriteLine("Sprawdzanie działania kolejki działającej na ArrayLiscie przez kompozycję");

            QueueBasedOnAL q = new QueueBasedOnAL();
            q.Enqueue(2);
            q.Enqueue(4);
            q.Enqueue(6.6);
            q.Enqueue(new Rectangle(3,4));

            int lenght = q.Length();

            while(q.Length()>0)
            {
                Console.WriteLine(q.Dequeue());
            }
        }

        public static void Test3()
        {
            Console.WriteLine("Sprawdzanie działania kolejki działającej na tablicy");

            QueueOnArray q = new QueueOnArray();

            q.Enqueue(2);
            q.Enqueue(4);
            q.Enqueue(6.6);
            q.Enqueue(new Rectangle(3,4));
            q.Enqueue(true);

            int lenght = q.Length;

            while (q.Length > 0)
            {
                Console.WriteLine(q.Dequeue());
            }
        }

        public static void Test()
        {
            Test1();
            Test2();
            Test3();
        }

    }


}

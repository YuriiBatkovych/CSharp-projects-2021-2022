using System;

namespace CW01
{
    class Hero
    {
        private string _name;
        private EHeroClass _type;

        public Hero(string name, int type)
        {
            _name = name;
            _type = (EHeroClass)type;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value is string)
                {
                    _name = value;
                }
                else
                {
                    throw new InvalidCastException
                        ("Nazwa bohatera musi byc typu string");
                }
            }
        }

        public EHeroClass Type
        {
            get { return _type; }

            set
            {
                try
                {
                    _type = (EHeroClass)value;
                }
                catch
                {
                    throw new InvalidCastException
                        ("Typ bochatera misi byc typu EHeroClass");
                }
            }
        }

        public void Display()
        {
            Console.WriteLine("Name : " + Name + " " + Type);
        }
    }
}
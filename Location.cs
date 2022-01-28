using System;
using System.Collections.Generic;
using System.Text;

namespace CW01
{
    class Location
    {
        private string _name;
        private List<NonPlayerCharacter> _npcs = new List<NonPlayerCharacter>();
        private bool _isUnlocked;

        public Location(string name, bool isUnlocked)
        {
            _name = name;
            _isUnlocked = isUnlocked;
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
                        ("Nazwa lokacji musi byc typu string");
                }
            }
        }

        public bool IsUnlocked
        {
            get { return _isUnlocked; }
            set { _isUnlocked = value; }
        }

        public List<NonPlayerCharacter> NPCs
        {
            get { return _npcs; }
        }

        public void AddNPC(NonPlayerCharacter npc)
        {
            _npcs.Add(npc);
        }
    }
}
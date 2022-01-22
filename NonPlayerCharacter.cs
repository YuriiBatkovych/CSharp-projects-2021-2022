using System;
using System.Collections.Generic;
using System.Text;

namespace CW01
{
    class NonPlayerCharacter
    {
        private string _name;
        private NpcDialogPart _start;

        public NonPlayerCharacter(string name, string start_statement)
        {
            _name = name;
            _start = new NpcDialogPart(start_statement);
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
                        ("Nazwa NonPlayerCharacter musi byc typu string");
                }
            }
        }

        public NpcDialogPart Start
        {
            get { return _start; }
        }

        public NpcDialogPart NpcDialogPartStartTalking()     //matoda zaczyna dialog zwracając początkowy NonPlayerCharekterDialogPart 
        {                                                           // do metody TalkTo, relizującej całą logike dialogu
            return _start;
        }
    }
}

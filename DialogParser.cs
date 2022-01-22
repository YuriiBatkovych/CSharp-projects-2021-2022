using System;
using System.Collections.Generic;
using System.Text;

namespace CW01
{
    class DialogParser
    {
        private Hero _hero;

        public DialogParser(Hero hero)
        {
            _hero = hero;
        }
        
        public string ParseDialog(IDialogPart dp)                     //wstawiamy imie bohatera do zdań dialogu
        {
           return String.Format(dp.GetStatement(), _hero.Name);
        }

        public List<string> ParseMenu(List<HeroDialogPart> collection)    //wstawiamy imie bohatera do listy wariantów odpowiedzi, miedzy którymi
        {                                                                          // wybiera gracz
            List<string> parsedMenu = new List<string>();

            foreach(HeroDialogPart h in collection)
            {
                parsedMenu.Add(String.Format(h.GetStatement(), _hero.Name));
            }

            return parsedMenu;
        }

    }
}
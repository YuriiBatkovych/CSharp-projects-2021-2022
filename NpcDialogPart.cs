using System;
using System.Collections.Generic;

namespace CW01
{
    public class NpcDialogPart : IDialogPart
    {
        private string _statement;
        private List<HeroDialogPart> _collection = new List<HeroDialogPart>();

        public NpcDialogPart(string s)
        {
            _statement = s;
        }

        public void AddHeroStatement(HeroDialogPart h)
        {
            _collection.Add(h);
        }

        public string GetStatement()
        {
            return _statement;
        }

        public List<HeroDialogPart> GetCollection()
        {
            return _collection;
        }
    }

}
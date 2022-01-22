using System;

namespace CW01
{
    public class HeroDialogPart : IDialogPart
    {
        private string _statement;
        private NpcDialogPart _ndp;

        public HeroDialogPart(string s)
        {
            _statement = s;
        }

        public void SetNpcDialogPart(NpcDialogPart ndp)
        {
            _ndp = ndp;
        }

        public string GetStatement()
        {
            return _statement;
        }

        public NpcDialogPart GetNDP()
        {
            return _ndp;
        }
    }
}

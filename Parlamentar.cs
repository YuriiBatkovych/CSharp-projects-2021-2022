using System;

namespace CW02
{
    class Parlamentar
    {
        private Parlament _parlament;
        private bool VotingAllowed;

        public delegate void Voted(bool result);

        public event Voted Decision;                  //parlamentarz przekazuje swoją decyzje w głosowaniu 

        public Parlamentar(Parlament p)
        {
            _parlament = p;
            VotingAllowed = false;
            _parlament.EndOfVoting += _forbitVoting;        //parlamentarzysta słucha zdarzenia Początek
            _parlament.StartOfVoting += _alloweVoting;          //głosowania i koniec głosowania
        }

        public void Vote()
        {
            if (VotingAllowed)
            {
                var rand = new Random();
                Decision(rand.Next(2) == 0);
                VotingAllowed = false;                       //parlamentarz nie może głosować 2 razy w jednym głosowaniu
            }
            else Console.WriteLine("Głosowanie nie dozwolone");
        }

        private void _alloweVoting()
        {
            VotingAllowed = true; 
        }

        private void _forbitVoting()
        {
            VotingAllowed = false;
        }

        
    }
}

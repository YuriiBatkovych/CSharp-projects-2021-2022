using System;

namespace CW02
{
    class Parlament
    {
        private Parlamentar[] _parlamentars;

        private string _votingTopic = "";
        private int _numberOfVotesForTrue = 0;
        private int _numberOfVotesForFalse = 0;

        public delegate void EndingVoting();
        public delegate void StartingVoting();

        public event StartingVoting StartOfVoting;
        public event EndingVoting EndOfVoting;

        public Parlament(int NumberOfParlamentars)
        {
            _parlamentars = new Parlamentar[NumberOfParlamentars];

            for(int i=0; i<NumberOfParlamentars; i++)
            {
                _parlamentars[i] = new Parlamentar(this);
                _parlamentars[i].Decision += CountVotes;         //parlament nasłuchuje oddanie głosu przez parlamentarzystów
            } 
        }

        public Parlamentar[] Parlamentars 
        {
            get { return _parlamentars; }
        }

        private void CountVotes(bool result)
        {
            if (result) _numberOfVotesForTrue++;
            else _numberOfVotesForFalse++;
        }

        

        public void StartVoting(string topic)
        {
            Console.WriteLine("Początek głosowania na temat " + topic);

            _numberOfVotesForTrue = 0;
            _numberOfVotesForFalse = 0;
            _votingTopic = topic;
            StartOfVoting();
        }

        public void EndVoting()
        {
            EndOfVoting();
            Console.WriteLine("Koniec Głosowania");
            Console.Clear();
        }

        public string GetLastVotingResults()
        {
            return "Głosowanie nad : "+_votingTopic+". Głosów za : " + _numberOfVotesForTrue + ",  przeciw : " + _numberOfVotesForFalse;
        }
    }
}

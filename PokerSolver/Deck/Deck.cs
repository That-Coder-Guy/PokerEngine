using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PokerSolver.Deck
{
    public class Deck
    {
        private List<Card?> _dealtCards = new();

        public static uint TotalCards = 52;

        public uint CardsInDeck { get; set; } = TotalCards;

        public uint CardsOutOfDeck => TotalCards - CardsInDeck;

        public void DrawRandom()
        {
            CardsInDeck--;
            _dealtCards.Add(null);
        }

        public double DrawProbability(Card card)
        {
            if (_dealtCards.Contains(card))
            {
                return 0;
            }
            else
            {
                double chanceDealt = _dealtCards.Count(card => card == null) / TotalCards;
                double chanceNotDealt = (CardsInDeck + _dealtCards.Count(card => card != null)) / TotalCards;
            }
        }
    }
}

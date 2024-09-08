using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PokerSolver.Deck
{
    public class Deck
    {
        private const int SuitCount = 4;

        private const int RankCount = 13;

        private List<Card?> _knownDealtCards = new();

        public const int TotalCards = 52;

        public int CardsInDeck { get; private set; } = TotalCards;

        public int CardsOutOfDeck => TotalCards - CardsInDeck;

        public void DrawRandom()
        {
            if (CardsInDeck > 0)
            {
                CardsInDeck--;
                //_dealtCards.Add(null);
            }
            throw new InvalidOperationException("No cards left in deck.");
        }

        public void DrawCard(Card card)
        {
            if (CardsInDeck > 0)
            {
                CardsInDeck--;
                _knownDealtCards.Add(card);
            }
            throw new InvalidOperationException("No cards left in deck.");
        }

        public double DrawProbability(Card card)
        {
            if (_knownDealtCards.Contains(card))
            {
                return 0;
            }
            else if (CardsInDeck == 0)
            {
                return 0;
            }
            else
            {
                double chanceToDraw = 1.0 / CardsInDeck;
                int unknownCardCount = CardsOutOfDeck - _knownDealtCards.Count();

                if (unknownCardCount == 0)
                {
                    return chanceToDraw;
                }
                else
                {
                    double chanceDealt = unknownCardCount / TotalCards;
                    double chanceNotDealt = (CardsInDeck + _knownDealtCards.Count()) / TotalCards;
                    return chanceNotDealt * chanceToDraw;
                }
            }
        }
        public double DrawProbability(Rank rank)
        {
            Card?[] dealtCardsWithRank = _knownDealtCards.Where(card => card != null).ToArray();

            if (_knownDealtCards.Contains(card))
            {
                return 0;
            }
            else if (CardsInDeck == 0)
            {
                return 0;
            }
            else
            {
                double chanceToDraw = 1.0 / CardsInDeck;
                int unknownCardCount = _knownDealtCards.Count(card => card == null);

                if (unknownCardCount == 0)
                {
                    return chanceToDraw;
                }
                else
                {
                    double chanceDealt = unknownCardCount / TotalCards;
                    double chanceNotDealt = (CardsInDeck + _knownDealtCards.Count(card => card != null)) / TotalCards;
                    return chanceNotDealt * chanceToDraw;
                }
            }
        }

    }
}

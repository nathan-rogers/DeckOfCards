using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Console.WriteLine(deck.DeckOfCards.Count());
            foreach (Card card in deck.DeckOfCards)
            {
                Console.WriteLine(card.CardRank.ToString());
            }
            deck.Shuffle();
            foreach (Card card in deck.DeckOfCards)
            {
                Console.WriteLine(card.CardRank.ToString());
            }
            Console.ReadKey();

        }
    }


    // When a new deck is created, you’ll create a card of each rank for each suit and add them to the deck of cards, 
    //      which in this case will be a List of Card objects.
    //
    // A deck can perform the following actions:
    //     void Shuffle() -- Merges the discarded pile with the deck and shuffles the cards
    //     List<card> Deal(int numberOfCards) - returns a number of cards from the top of the deck
    //     void Discard(Card card) / void Discard(List<Card> cards) - returns a card from a player to the 
    //         discard pile	
    // 
    // A deck knows the following information about itself:
    //     int CardsRemaining -- number of cards left in the deck
    //     List<Card> DeckOfCards -- card waiting to be dealt
    //     List<Card> DiscardedCards -- cards that have been played
    class Deck
    {
        Random rng = new Random();

        public List<Card> DeckOfCards { get; set; }
        public List<Card> DiscardedCards { get; set; }

        public int CardsRemaining
        {
            get
            {
                return DeckOfCards.Count();
            }
        }

        public Deck()
        {
            this.DeckOfCards = new List<Card>();
            this.DiscardedCards = new List<Card>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j < 15; j++)
                {
                    DeckOfCards.Add(new Card((Rank)j, (Suit)i));
                }
            }
        }

        public List<Card> Deal (int numOfCards)
        {
            List<Card> dealtCards = new List<Card>();
            for (int i = 0; i < numOfCards ; i++)
            {
                Card tempCard = DeckOfCards[0];
                dealtCards.Add(tempCard);
                DeckOfCards.Remove(tempCard);
            }
            return dealtCards;
        }
        public void Discard(Card card)
        {
            DiscardedCards.Add(card);
            DeckOfCards.Remove(card);
        }
        public void Discard(List<Card> cards)
        {
            foreach(Card card in cards)
            {

                DiscardedCards.Add(card);
                DeckOfCards.Remove(card); 
  
            }
        }
        public void Shuffle()
        {
            List<Card> shuffleList = new List<Card>();

            shuffleList.Clear();
            int deckSize = DeckOfCards.Count();
            for (int i = 0; i < deckSize; i++)
            {

                Card tempCard = DeckOfCards.ElementAt(rng.Next(0, DeckOfCards.Count()));
                shuffleList.Add(tempCard);
                DeckOfCards.Remove(tempCard);
            }
            DeckOfCards = shuffleList;
        }

    }


    // What makes a card?
    //     A card is comprised of it’s suit and its rank.  Both of which are enumerations.
    //     These enumerations should be "Suit" and "Rank"
    public enum Rank
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
    public enum Suit
    {
        Club,
        Diamond,
        Heart,
        Spade
    }
    class Card
    {


        public Rank CardRank { get; set; }
        public Suit CardSuit { get; set; }

        public Card(Rank rank, Suit suit)
        {
            this.CardRank = rank;
            this.CardSuit = suit;
        }

    }
}

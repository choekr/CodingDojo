using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Card
    {
        public string value; //A,2,3,4,5,6,7,8,9,10,J,Q,K
        // public enum value {Ace=1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, J, Q, K};
        public string Suit; //Clubs, Spades, Hearts, Diamonds
        // public enum Suit {Clubs, Spades, Hearts, Diamonds};
        public int numerical_value; //1-13 as integers
        // public enum numerical_value {1,2,3,4,5,6,7,8,9,10,11,12,13};
        public Card(string val, string suit1, int num) {
            value = val;
            Suit = suit1;
            numerical_value = num;
        }

    }
    public class Deck
    {
        // initialize
        // public enum Suit {Hearts, Diamonds, Spades, Clubs};
        // public enum Value {Ace=1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, J, Q, K};
        // public class Card {
        //     public Card(Suit suit1, Value value1){
        //         Suit = suit1;
        //         Value = value1;
        //     }
        //     public Suit Suit {get; set;}
        //     public Value Value {get; set;}
        // }

        List<Card> cards;
        public void Init() {
            cards = new List<Card>();
            string[] value = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
            string[] Suit = {"Hearts", "Diamonds", "Spades", "Clubs"};
            for (int i = 0; i<value.Length; i++) {
                for (int j=0; j<Suit.Length; j++) {
                    cards.Add(new Card(value[i], Suit[j], (i+1)));
                }
            }
        }

        public Card Deal() {
            Card topMostCard = cards[cards.Count-1];
            cards.RemoveAt(cards.Count-1);
            return topMostCard;
        }

        public void Reset() {
            Init();
        }

        public void Shuffle() {
            Random random = new Random();
            for (int i=0; i<52; i++) {
                Card temp = cards[i];
                int cut = random.Next(i, cards.Count);
                cards[i] = cards[cut];
                cards[cut] = temp;
            }
        }
    }
    public class Player
    {
        public string name;
        public List<Card> hand; 
        public Player (string name1) {
            name = name1; 
            hand = new List<Card>();
        }
        public Card Draw(Deck cards) {
            Card card = cards.Deal();
            hand.Add(card);
            return card;
        }
        public bool Discard(Card hand1) {
            for (int idx=0; idx<hand.Count; idx++) {
                if(hand[idx] == hand1) {
                    hand.RemoveAt(idx);
                    return true;
                }
            }
            return false;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Deck deck1 = new Deck();
            deck1.Init();
            deck1.Shuffle();
            Player self = new Player("Mike");
            Card card = self.Draw(deck1);
            Console.WriteLine(card.value + " of " + card.Suit + ", " + card.numerical_value);
            Console.WriteLine(self.hand.Count);
            bool discarded = self.Discard(card);
            Console.WriteLine("Has {0} of {1} been discarded? {2}",card.value, card.Suit, discarded);
        }
    }
}
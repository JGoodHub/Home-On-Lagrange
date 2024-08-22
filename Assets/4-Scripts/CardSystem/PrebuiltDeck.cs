using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace CardSystem
{
    [CreateAssetMenu(fileName = "Deck", menuName = "Card System/New Deck")]
    public class PrebuiltDeck : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private List<Card> _cards = new List<Card>();

        public Deck GetChangeableDeck()
        {
            return new Deck(_name, _cards);
        }
    }

    public class Deck
    {
        private readonly string _name;
        private List<Card> _cards;

        public string Name => _name;

        public int Count => _cards.Count;

        public Deck()
        {
            _name = string.Empty;
            _cards = new List<Card>();
        }

        public Deck(string name, List<Card> cards)
        {
            _name = name;
            _cards = cards;
        }
        
        public void Shuffle(Random random = null)
        {
            if (_cards.Count == 0)
                return;

            random ??= new Random(DateTime.Now.GetHashCode());

            for (int i = 0; i < _cards.Count * 5; i++)
            {
                int indexA = random.Next(_cards.Count);
                int indexB = random.Next(_cards.Count);

                (_cards[indexA], _cards[indexB]) = (_cards[indexB], _cards[indexA]);
            }
        }

        public Card Peak()
        {
            if (_cards.Count == 0)
                throw new Exception("Peaked an empty deck, check IsEmpty first.");

            return _cards[0];
        }

        public List<Card> Peak(int amount)
        {
            if (_cards.Count == 0)
                throw new Exception("Peaked an empty deck, check IsEmpty first.");

            List<Card> peakedCards = new List<Card>();

            for (int i = 0; i < amount || i < _cards.Count; i++)
            {
                peakedCards.Add(_cards[i]);
            }

            return peakedCards;
        }

        public Card Draw()
        {
            if (_cards.Count == 0)
                throw new Exception("Drawn on an empty deck, check IsEmpty first.");

            Card topCard = _cards[0];
            _cards.RemoveAt(0);

            return topCard;
        }

        public List<Card> Draw(int amount)
        {
            if (_cards.Count == 0)
                throw new Exception("Drawn on an empty deck, check IsEmpty first.");

            List<Card> drawnCards = new List<Card>();

            for (int i = 0; i < amount || i < _cards.Count; i++)
            {
                drawnCards.Add(Draw());
            }

            return drawnCards;
        }

        public void Reorder()
        {
            throw new NotImplementedException();
        }

        public void Return(Card card)
        {
            _cards.Add(card);
        }

        public void Return(List<Card> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                Return(cards[i]);
            }
        }

        public bool Contains(Card card)
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                if (_cards[i].ID == card.ID)
                    return true;
            }

            return false;
        }

        public Card FindAndRemoveFirst(Predicate<Card> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Card> FindAndRemoveAll(Predicate<Card> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
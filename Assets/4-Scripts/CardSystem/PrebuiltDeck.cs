using System;
using System.Collections.Generic;
using UnityEngine;

namespace CardSystem
{
    [CreateAssetMenu(fileName = "Deck", menuName = "Card System/New Deck")]
    public class PrebuiltDeck : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private List<CardData> _cards = new List<CardData>();

        public Deck GetChangeableDeck()
        {
            return new Deck(_name, _cards);
        }
    }

    public class Deck
    {
        private readonly string _name;
        private List<CardData> _cards;

        public string Name => _name;

        public int Count => _cards.Count;

        public Deck()
        {
            _name = string.Empty;
            _cards = new List<CardData>();
        }

        public Deck(string name, List<CardData> cards)
        {
            _name = name;
            _cards = cards;
        }
    }
}
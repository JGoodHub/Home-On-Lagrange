using System;
using System.Collections.Generic;
using CardSystem;
using GoodHub.Core.Runtime;
using UnityEngine;

public class DecksManager : SceneSingleton<DecksManager>
{
    [SerializeField] private List<PrebuiltDeck> _scriptableDecks = new List<PrebuiltDeck>();

    private Dictionary<string, Deck> _decksLookup = new Dictionary<string, Deck>();

    private void Awake()
    {
        foreach (PrebuiltDeck scriptableDeck in _scriptableDecks)
        {
            Deck deck = scriptableDeck.GetChangeableDeck();

            if (_decksLookup.TryAdd(deck.Name, deck) == false)
                throw new Exception("Deck names must be unique");
        }
    }

    public Deck GetDeck(string deckName)
    {
        if (_decksLookup.ContainsKey(deckName) == false)
            return null;

        return _decksLookup[deckName];
    }
}

[Serializable]
public class ScriptableDeckEntry
{
    public string Name;
    public PrebuiltDeck Deck;
}
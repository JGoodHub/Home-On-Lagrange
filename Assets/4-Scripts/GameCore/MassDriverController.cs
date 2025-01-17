using System;
using System.Collections;
using System.Collections.Generic;
using CardSystem;
using UnityEngine;

public class MassDriverController : MonoBehaviour
{
    [SerializeField] private DeckView _moduleDeckView;
    [SerializeField] private DeckView _moduleDiscardDeckView;

    [SerializeField] private List<CardSlot> _cardSlots = new List<CardSlot>();

    private List<Card> _cards = new List<Card>();

    private void Start()
    {
        Restock();
    }

    private void Restock()
    {
        StartCoroutine(RestockSequence());
    }

    private IEnumerator RestockSequence()
    {
        // First time drawing into the mass driver
        if (_cards.Count == 0)
        {
            for (int i = 0; i < _cardSlots.Count; i++)
            {
                

                yield return new WaitForSeconds(1f);
            }
        }
    }
}
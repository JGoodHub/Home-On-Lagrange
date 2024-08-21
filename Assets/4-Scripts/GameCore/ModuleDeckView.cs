using System;
using System.Collections;
using System.Collections.Generic;
using CardSystem;
using UnityEngine;

public class ModuleDeckView : MonoBehaviour
{
    [SerializeField] private Transform _cardStackTransform;
    [SerializeField] private Transform _topCardTransform;
    [SerializeField] private float _cardThickness;

    [SerializeField] private string _mirrorDeckName;

    private Deck _mirrorDeck;

    private void Start()
    {
        _mirrorDeck = DecksManager.Singleton.GetDeck(_mirrorDeckName);

        RefreshDeckSize();
    }

    private void RefreshDeckSize()
    {
        int cardsRemaining = _mirrorDeck.Count;
        float deckThickness = cardsRemaining * _cardThickness;

        _topCardTransform.gameObject.SetActive(cardsRemaining > 0);
        _cardStackTransform.gameObject.SetActive(cardsRemaining > 1);

        _topCardTransform.transform.localPosition = new Vector3(0, 0, -deckThickness - 0.01f);
        _cardStackTransform.transform.localPosition = new Vector3(0, 0, -deckThickness / 2);
        
        _cardStackTransform.transform.localScale = new Vector3(
            _cardStackTransform.transform.localScale.x,
            _cardStackTransform.transform.localScale.y, 
            -deckThickness);
    }
}
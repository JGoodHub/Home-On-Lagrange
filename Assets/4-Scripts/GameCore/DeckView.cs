using System;
using System.Collections;
using System.Collections.Generic;
using CardSystem;
using UnityEngine;

public class DeckView : MonoBehaviour
{
    [SerializeField] private Transform _cardStackTransform;
    [SerializeField] private float _cardThickness;
    
    [SerializeField] private string _mirrorDeckName;

    private Deck _mirrorDeck;
    private CardView _topCardView;

    private void Start()
    {
        _mirrorDeck = DecksManager.Singleton.GetDeck(_mirrorDeckName);

        RefreshDeckSize();
    }

    private void RefreshDeckSize()
    {
        int cardsRemaining = _mirrorDeck.Count;
        float deckThickness = cardsRemaining * _cardThickness;

        if (cardsRemaining == 0)
        {
            _cardStackTransform.gameObject.SetActive(false);
            _topCardView.gameObject.SetActive(false);
            return;
        }

        _cardStackTransform.gameObject.SetActive(cardsRemaining > 1);
        _cardStackTransform.transform.localPosition = new Vector3(0, 0, -deckThickness / 2);
        _cardStackTransform.transform.localScale = new Vector3(
            _cardStackTransform.transform.localScale.x,
            _cardStackTransform.transform.localScale.y,
            -deckThickness);

        if (_topCardView == null)
        {
            Card topCard = _mirrorDeck.Peak();

            _topCardView = Instantiate(topCard.Prefab, transform).GetComponent<CardView>();
        }

        _topCardView.gameObject.SetActive(cardsRemaining > 0);
        _topCardView.transform.localPosition = new Vector3(0, 0, -deckThickness - 0.01f);
        _topCardView.transform.rotation = Quaternion.LookRotation(Vector3.down, Vector3.forward);
    }

    public CardView DrawAndReplaceTopCard()
    {
        CardView currentTopCard = _topCardView;


        return currentTopCard;
    }
}
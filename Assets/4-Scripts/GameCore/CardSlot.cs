using System.Collections;
using System.Collections.Generic;
using CardSystem;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
    private Card _card;

    public void SetCard(Card card)
    {
        _card = card;
    }

    public void Clear()
    {
        _card = null;
    }
}
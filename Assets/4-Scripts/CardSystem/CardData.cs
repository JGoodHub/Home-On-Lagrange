using System;
using System.Collections.Generic;
using UnityEngine;

namespace CardSystem
{
    public class CardData : ScriptableObject
    {
        [SerializeField] private int _id;

        public int ID => _id;
    }
}
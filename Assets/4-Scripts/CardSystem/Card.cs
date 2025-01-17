using System;
using System.Collections.Generic;
using UnityEngine;

namespace CardSystem
{
    public class Card : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private GameObject _prefab;

        public int ID => _id;

        public GameObject Prefab => _prefab;
    }
}
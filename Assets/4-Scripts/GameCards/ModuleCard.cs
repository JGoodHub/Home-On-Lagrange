using System;
using CardSystem;
using UnityEngine;

namespace GameCards
{
    [Serializable]
    public enum ModuleType
    {
        Accommodation,
        Defence,
        Education,
        Infrastructure,
        Recreation,
    }

    [CreateAssetMenu(fileName = "Module Card", menuName = "Card System/New Module Card")]
    public class ModuleCard : Card
    {
        [SerializeField] private string _name;
        [SerializeField] private ModuleType _moduleType;
        [SerializeField] private Sprite _graphic;
        [SerializeField] private int[] _costTiers;
    }
}
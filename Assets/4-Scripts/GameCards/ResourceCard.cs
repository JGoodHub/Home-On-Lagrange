using System;
using CardSystem;
using UnityEngine;

namespace GameCards
{
    [Serializable]
    public enum ResourceType
    {
        Black,
        White,
        AnyModule,
        Accommodation,
        Defence,
        Education,
        Infrastructure,
        Recreation,
    }

    [CreateAssetMenu(fileName = "Resource Card", menuName = "Card System/New Resource Card")]
    public class ResourceCard : CardData
    {
        [SerializeField] private string _name;
        [SerializeField] private ResourceType _resourceType;
        [SerializeField] private Sprite _graphic;
        [SerializeField] private int _value;
    }
}
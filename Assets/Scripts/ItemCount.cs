using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class ItemCount
    {
        public ItemType itemType;
        [Range(1, 99)]
        public int count;
    }
}
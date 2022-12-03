using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class SpriteContainer : ScriptableObject
    {
        public string spritesFolder = "Assets/Images";
        private readonly Dictionary<string, Sprite> _nameSpriteLink = new Dictionary<string, Sprite>();

        private void OnValidate()
        {
            FillData();
        }
        
        private void FillData()
        {
            _nameSpriteLink.Clear();
            string[] spriteAssets = AssetDatabase.FindAssets("t: sprite", new[] { spritesFolder });
            foreach (string spriteAsset in spriteAssets)
            {
                var spritePath    = AssetDatabase.GUIDToAssetPath(spriteAsset);
                var sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);
                _nameSpriteLink.Add(sprite.name, sprite);
            }
        }

        public bool TryGetSprite(string spriteName, out Sprite sprite)
        {
            return _nameSpriteLink.TryGetValue(spriteName.ToLowerInvariant(), out sprite);
        }
    }
}
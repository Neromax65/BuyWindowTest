using System;
using DefaultNamespace;
using DefaultNamespace.Utility;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyWindow : MonoBehaviour
{
    public string title;
    public string description;
    public ItemCount[] items = new ItemCount[3];
    public float price;
    [Range(0, 100)]
    public int discount;
    public string bigIconName;

    [SerializeField] private SpriteContainer spriteContainer;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Image bigIcon;
    [SerializeField] private PriceEvaluator priceEvaluator;
    [SerializeField] private ItemViewPool itemViewPool;

    private void OnValidate()
    {
        if (items.Length < 3)
            Array.Resize(ref items, 3);
        else if (items.Length > 6)
            Array.Resize(ref items, 6);
    }

    private void OnEnable()
    {
        itemViewPool.DeSpawnAll();
        UpdateFields();
        SpawnItems();
    }

    private void UpdateFields()
    {
        titleText.text = title;
        descriptionText.text = description;
        priceEvaluator.SetPrice(price, discount);
        if (spriteContainer.TryGetSprite(bigIconName, out Sprite bigIconSprite))
            bigIcon.sprite = bigIconSprite;
    }

    private void SpawnItems()
    {
        foreach (var item in items)
        {
            spriteContainer.TryGetSprite(Enum.GetName(typeof(ItemType), item.itemType), out Sprite sprite);
            itemViewPool.Spawn().Init(sprite, item.count);
        }
    }

    private void OnDisable()
    {
        itemViewPool.DeSpawnAll();
    }
}

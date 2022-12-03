using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class PriceEvaluator : MonoBehaviour
    {
        [SerializeField] private TMP_Text priceText;
        [SerializeField] private TMP_Text discountedPriceText;
        [SerializeField] private GameObject discountObject;
        [SerializeField] private TMP_Text discountText;

        public void SetPrice(float price, int discount = 0)
        {
            discount = Mathf.Clamp(discount, 0, 100);
            discountText.text = $"-{discount}%";
            discountedPriceText.text = $"${price:0.00}";
            discountObject.SetActive(discount > 0);
            discountedPriceText.gameObject.SetActive(discount > 0);
            float totalPrice = discount > 0 ? price - price * (discount / 100f) : price;
            priceText.text = totalPrice > 0 ? $"${totalPrice:0.00}" : "FREE";
        }
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text countText;

        public void Init(Sprite sprite, int count)
        {
            image.sprite = sprite;
            countText.text = $"{count}";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class WindowInitializer : MonoBehaviour
    {
        [SerializeField] private Button updateWindowButton;
        [SerializeField] private BuyWindow buyWindow;
        [SerializeField] private Button addEntryButton;
        [SerializeField] private WindowInitializerEntry windowInitializerEntryPrefab;
        [SerializeField] private Transform entriesTransform;
        
        private readonly List<WindowInitializerEntry> _windowInitializerEntries = new List<WindowInitializerEntry>(6);

        private void Awake()
        {
            updateWindowButton.onClick.AddListener(( () =>
            {
                List<ItemCount> itemCounts = new List<ItemCount>(6);
                foreach (var entry in _windowInitializerEntries)
                {
                    itemCounts.Add(new ItemCount
                    {
                        itemType = (ItemType)entry.itemTypeDropdown.value,
                        count = int.TryParse(entry.countInputField.text, out int parsedCount) ? parsedCount : default
                    });
                }
                buyWindow.items = itemCounts.ToArray();
                buyWindow.gameObject.SetActive(false);
                buyWindow.gameObject.SetActive(true);
            }));
            
            addEntryButton.onClick.AddListener(OnEntryAddButtonClicked);
        }

        private void OnEntryAddButtonClicked()
        {
            if (_windowInitializerEntries.Count < 6)
            {
                var entry = Instantiate(windowInitializerEntryPrefab, entriesTransform);
                _windowInitializerEntries.Add(entry);
                if (_windowInitializerEntries.Count > 1)
                    entry.removeButton.gameObject.SetActive(true);
                entry.removeButton.onClick.AddListener(() =>
                {
                    _windowInitializerEntries.Remove(entry);
                    Destroy(entry.gameObject);
                    addEntryButton.interactable = _windowInitializerEntries.Count < 6;
                });
            }

            addEntryButton.interactable = _windowInitializerEntries.Count < 6;
            addEntryButton.transform.SetAsLastSibling();
        }
    }
}
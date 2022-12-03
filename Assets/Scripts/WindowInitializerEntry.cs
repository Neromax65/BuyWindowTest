using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class WindowInitializerEntry : MonoBehaviour
    {
        public Button removeButton;
        public TMP_Dropdown itemTypeDropdown;
        public TMP_InputField countInputField;

        private void OnValidate()
        {
            UpdateItemTypes();
        }

        private void UpdateItemTypes()
        {
            itemTypeDropdown.options.Clear();
            itemTypeDropdown.AddOptions(Enum.GetNames(typeof(ItemType)).ToList());
        }
    }
}
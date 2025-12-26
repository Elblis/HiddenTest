using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace HiddenTest
{
    public class UITextItem : MonoBehaviour, IUIItem
    {
        public int? Id { get; private set; }

        private Text ItemText { get; set; }

        private void Awake()
        {
            GetComponent<Image>().enabled = false;

            ItemText = GetComponentInChildren<Text>();
            ItemText.enabled = true;
        }
        public void SetItem(int? newItemId, string name)
        {
           Id = newItemId;
           ItemText.text = name;
        }
    }
}

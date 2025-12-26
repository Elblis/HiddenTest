using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace HiddenTest
{
    [RequireComponent(typeof(Image))]
    public class UIImageItem : MonoBehaviour, IUIItem
    {
        public int? Id { get; private set; }
        private Image ItemImage {get; set;}

        private void Awake()
        {
            ItemImage = GetComponent<Image>();
            ItemImage.enabled = true;

            GetComponentInChildren<Text>().enabled = false;
        }
        public void SetItem(int? newItemId, string name)
        {
           Id = newItemId;
            ItemImage.sprite = SpriteManager.GetSprite(name);
            ItemImage.color = new Color(
                ItemImage.color.r,
                ItemImage.color.g,
                ItemImage.color.b,
                (ItemImage.sprite is null) ? 0f : 1f
                );
        }
    }
}

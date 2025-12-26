using System.Linq;
using UnityEngine;

namespace HiddenTest
{
    public static class SpriteManager
    {
        private static Sprite[] ItemUISprites { get; set; }

        static SpriteManager()
        {
            ItemUISprites = Resources.LoadAll<Sprite>($"Sprites\\Test Level UI");
        }

        public static Sprite GetSprite(string spriteName)
        {
            var sprite = ItemUISprites.FirstOrDefault(s => s.name == spriteName);
            if (sprite != null)
                Debug.Log($"Спрайт: {sprite.name}, {sprite.GetHashCode()}");
            
            return sprite;
        }
    }
}

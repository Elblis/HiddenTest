using System.Collections.Generic;
using UnityEngine;

namespace HiddenTest
{

    public class LevelSettings : MonoBehaviour
    {
        [SerializeField]
        public int TimerSeconds = 120;
        [SerializeField]
        public bool IsTimerEnabled  = true;

        [HideInInspector]
        public int SearchingItemsInTimeCount = 3;

        [SerializeField]
        public UIType InterfaceType = UIType.Text ;
        [SerializeField]
        // Префаб для объекта в интерфейсе (Image + Text)
        public GameObject ListItemPrefab;     

        [SerializeField]
        public List<SelectableItem> Items = new List<SelectableItem>();
    }

}
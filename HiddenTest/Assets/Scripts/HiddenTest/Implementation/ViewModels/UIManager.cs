using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace HiddenTest
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        private RectTransform _listContainer;
        private TimerManager _timer;

        public Transform _levelObject;
        public GameObject _winPanel;
        public GameObject _losePanel;

        /// <summary>
        /// Элементы панели для поиска
        /// </summary>
        List<IUIItem> UIItems { get; set; }


        void Awake()
        {
            _listContainer = GetComponentsInChildren<RectTransform>()[1];
            _timer = GetComponentInChildren<TimerManager>();

            float defaultResolutionRatio = 16f / 9f;
            float screenResolutionRatio = (float)Screen.currentResolution.width / (float)Screen.currentResolution.height;
            _levelObject.localScale = new Vector3(screenResolutionRatio / defaultResolutionRatio, _levelObject.localScale.y, _levelObject.localScale.z);

            UIItems = new List<IUIItem>();  

            Debug.Log("UImanager awakes");
        }

        public void SetItems(IEnumerable<SelectableItem> items, GameObject prefab)
        {
            foreach (Transform t in _listContainer)
                Destroy(t.gameObject);

            UIItems.Clear();

            foreach (SelectableItem i in items)
            {
                var go = Instantiate(prefab, _listContainer);
                
                IUIItem item = go.GetComponentInChildren<IUIItem>();
                item.SetItem(i.Id, i.Name);
                UIItems.Add(item);
            }
        }

        public void ChangeFoundItem(int itemId, SelectableItem newItem)
        {
            IUIItem item = UIItems.FirstOrDefault(i => i.Id == itemId);
            if (item is null)
                return;

            if (newItem is null)
                item.SetItem(null, null);
            else
                item.SetItem(newItem.Id, newItem.Name);
            
        }

        public void ShowWin()
        {
            _timer.enabled = false;
            if (_winPanel != null) 
                _winPanel.SetActive(true);
        }

        public void ShowLose()
        {
            _timer.enabled = false;
            if (_losePanel != null) 
                _losePanel.SetActive(true);

            if (_winPanel != null)
                _winPanel.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log(KeyCode.Escape);
                Application.Quit();
            }
        }
    }
}

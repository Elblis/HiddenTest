using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace HiddenTest
{
    public class GameController : IGameController, IInitializable
    {
        private LevelSettings Settings { get; set; }

        private List<SelectableItem> SearhingItems { get; set; }
        private IUIManager _uiManager;

        public GameController(IUIManager uiManager, LevelSettings settings)
        {
            _uiManager = uiManager;
            Settings = settings;

            SearhingItems = new List<SelectableItem>(settings.Items.Where(i => i.IsEnabled));
            SearhingItems
                .Skip(Settings.SearchingItemsInTimeCount)
                .ToList()
                .ForEach(i => i.IsEnabled = false);

            switch (Settings.InterfaceType)
            {
                case UIType.Image:
                    Settings.ListItemPrefab.AddComponent<UIImageItem>(); break;
                case UIType.Text:
                default:
                    Settings.ListItemPrefab.AddComponent<UITextItem>(); break;
            };
        }

        public void Initialize()
        {
            try
            { 
                _uiManager.SetItems(
                    SearhingItems.Take(Settings.SearchingItemsInTimeCount),
                    Settings.ListItemPrefab
                    );
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }

        }

        public bool CanPickItem(int itemId)
        {
            try
            {
                return SearhingItems.Exists(i => i.Id == itemId && i.IsEnabled);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
                return false;
            }
        }

        public void OnItemFound(int itemId)
        {
            try
            {
                SearhingItems.RemoveAll(i => i.Id == itemId);
                SelectableItem newItem = SearhingItems.ElementAtOrDefault(Settings.SearchingItemsInTimeCount - 1);
                if (newItem != null)
                    newItem.IsEnabled = true;   

                _uiManager.ChangeFoundItem(itemId, newItem);

                if (SearhingItems.Count == 0)
                    _uiManager.ShowWin();
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }

    }
}

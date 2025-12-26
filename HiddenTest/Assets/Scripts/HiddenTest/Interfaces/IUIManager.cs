using System.Collections.Generic;
using UnityEngine;

namespace HiddenTest
{
    /// <summary>
    /// Менеджер объектов UI
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// Размещение объектов для нахождения на UI
        /// </summary>
        /// <param name="names"></param>
        /// <param name="prefab"></param>
        void SetItems(IEnumerable<SelectableItem> items, GameObject prefab);
        /// <summary>
        /// Сменить найденный объект на UI
        /// </summary>
        /// <param name="itemId"></param>
        void ChangeFoundItem(int itemId, SelectableItem newItem);

        /// <summary>
        /// Показать выигрыш
        /// </summary>
        void ShowWin();
        /// <summary>
        /// Показать проигрыш
        /// </summary>
        void ShowLose();
    }
}

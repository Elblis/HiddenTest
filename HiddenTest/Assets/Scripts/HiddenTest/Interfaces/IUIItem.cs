
namespace HiddenTest
{
    /// <summary>
    /// Объект UI, соответствующий объекту поиска
    /// </summary>
    public interface IUIItem
    {
        int? Id { get; }

        /// <summary>
        /// Устанавливает новый элемент в UI
        /// </summary>
        /// <param name="newItemId"></param>
        /// <param name="name"></param>
        void SetItem(int? newItemId, string name);
    }
}

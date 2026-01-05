
namespace HiddenTest
{
    /// <summary>
    /// Менеджер интерфейса игры
    /// </summary>
    public interface IGameController
    {
        /// <summary>
        /// Проверка на взятие предмета
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        bool CanPickItem(int itemId);

        /// <summary>
        /// Событие при нахождении предмета
        /// </summary>
        /// <param name="itemId"></param>
        void OnItemFound(int itemId);

        /// <summary>
        /// Событие при истечении таймера
        /// </summary>
        void OnTimerElapsed();
    }
}

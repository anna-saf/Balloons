namespace Balloons.Features.GlobalGameEvents
{
    using System;

    /// <summary>
    /// Глобальные игровые ивенты
    /// </summary>
    public class GlobalGameEvents
    {
        /// <summary>
        /// Событие начала игры
        /// </summary>
        public event Action onStartGame = delegate { };

        /// <summary>
        /// Событие окончания игры
        /// </summary>
        public event Action onEndGame = delegate { };
        /// <summary>
        /// Событие перехода в меню
        /// </summary>
        public event Action onGoToMenu = delegate { };

        /// <summary>
        /// Начать игру
        /// </summary>
        public void StartGame() =>
            onStartGame();

        /// <summary>
        /// Закончить игру
        /// </summary>
        public void EndGame() =>
            onEndGame();

        /// <summary>
        /// Перейти в меню
        /// </summary>
        public void GoToMenu() =>
            onGoToMenu();
    }
}

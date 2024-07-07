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
        /// Событие продолжения игры
        /// </summary>
        public event Action onContinueGame = delegate { };

        /// <summary>
        /// Событие паузы игры
        /// </summary>
        public event Action onPauseGame = delegate { };

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
        /// Поставить игру на паузу
        /// </summary>
        public void PauseGame() =>
            onPauseGame();

        /// <summary>
        /// Возобновить игру
        /// </summary>
        public void ContinueGame() =>
            onContinueGame();

        /// <summary>
        /// Закончить игру
        /// </summary>
        public void EndGame() =>
            onEndGame();

        /// <summary>
        /// Перейти в меню
        /// </summary>
        public void GoToMenu() =>
            onEndGame();
    }
}

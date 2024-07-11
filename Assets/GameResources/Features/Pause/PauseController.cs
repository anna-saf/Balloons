namespace Balloons.Features.PauseController
{
    using UnityEngine;

    /// <summary>
    /// Контроллер паузы/продолжения игры
    /// </summary>
    public class PauseController
    {
        protected const int PAUSE_GAME = 0;
        protected const int CONTINUE_GAME = 1;

        public void PauseGame() =>
            Time.timeScale = PAUSE_GAME;

        public void ContinueGame() =>
            Time.timeScale = CONTINUE_GAME;
    }
}

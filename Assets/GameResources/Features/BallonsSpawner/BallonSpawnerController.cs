namespace Balloons.Features.BalloonSpawner
{
    using Ballons.Features.BallonsSpawner;
    using Balloons.Features.GlobalGameEvents;
    using System;

    /// <summary>
    /// Контроллер спавнера шаров в зависимости от состояния игры
    /// </summary>
    public class BallonSpawnerController: IDisposable
    {
        protected GlobalGameEvents globalGameEvents = default;
        protected BallonsSpawner ballonsSpawner = default;

        protected BallonSpawnerController(GlobalGameEvents globalGameEvents, BallonsSpawner ballonsSpawner)
        {
            this.globalGameEvents = globalGameEvents;
            this.ballonsSpawner = ballonsSpawner; 

            globalGameEvents.onStartGame += OnStartGame;
            globalGameEvents.onPauseGame += OnPauseGame;
            globalGameEvents.onContinueGame += OnContinueGame;
            globalGameEvents.onEndGame += OnEndGame;
            globalGameEvents.onGoToMenu += OnGoToMenu;
        }

        protected virtual void OnStartGame() =>
            ballonsSpawner.StartSpawn();

        protected virtual void OnPauseGame() => 
            ballonsSpawner.StopSpawn();

        protected virtual void OnContinueGame() =>
            ballonsSpawner.StartSpawn();

        protected virtual void OnEndGame() =>
            ballonsSpawner.StopSpawn();

        protected virtual void OnGoToMenu() =>
            ballonsSpawner.StopSpawn();

        public void Dispose()
        {
            if(globalGameEvents != null)
            {
                globalGameEvents.onStartGame -= OnStartGame;
                globalGameEvents.onPauseGame -= OnPauseGame;
                globalGameEvents.onContinueGame -= OnContinueGame;
                globalGameEvents.onEndGame -= OnEndGame;
                globalGameEvents.onGoToMenu -= OnGoToMenu;
            }
        }
    }
}

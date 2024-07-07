namespace Balloons.Features.BalloonSpawner
{
    using Ballons.Features.BallonsSpawner;
    using Balloons.Features.GlobalGameEvents;

    /// <summary>
    /// Контроллер спавнера шаров в зависимости от состояния игры
    /// </summary>
    public class BallonSpawnerController: GlobalGameEventsProvider
    {
        protected BallonsSpawner ballonsSpawner = default;

        protected BallonSpawnerController(GlobalGameEvents globalGameEvents, BallonsSpawner ballonsSpawner): base(globalGameEvents) =>
            this.ballonsSpawner = ballonsSpawner; 

        protected override void OnStartGame() =>
            ballonsSpawner.StartSpawn();

        protected override void OnPauseGame() => 
            ballonsSpawner.StopSpawn();

        protected override void OnContinueGame() =>
            ballonsSpawner.StartSpawn();

        protected override void OnEndGame() =>
            ballonsSpawner.StopSpawn();

        protected override void OnGoToMenu() =>
            ballonsSpawner.StopSpawn();
    }
}

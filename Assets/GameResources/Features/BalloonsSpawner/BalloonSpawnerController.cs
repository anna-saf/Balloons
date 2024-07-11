namespace Balloons.Features.BalloonSpawner
{
    using Balloons.Features.BallonsSpawner;
    using Balloons.Features.GlobalGameEvents;

    /// <summary>
    /// Контроллер спавнера шаров в зависимости от состояния игры
    /// </summary>
    public class BalloonSpawnerController: GlobalGameEventsProvider
    {
        protected BalloonsSpawner ballonsSpawner = default;

        protected BalloonSpawnerController(GlobalGameEvents globalGameEvents, BalloonsSpawner ballonsSpawner): base(globalGameEvents) =>
            this.ballonsSpawner = ballonsSpawner; 

        protected override void OnStartGame() =>
            ballonsSpawner.StartSpawn();

        protected override void OnEndGame() =>
            ballonsSpawner.StopSpawn();

        protected override void OnGoToMenu() =>
            ballonsSpawner.StopSpawn();
    }
}

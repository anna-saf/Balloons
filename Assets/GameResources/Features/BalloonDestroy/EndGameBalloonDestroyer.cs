namespace Balloons.Features.BalloonDestroy
{
    using Balloons.Features.BallonsSpawner;
    using Balloons.Features.Utilities;
    using Balloons.Features.GlobalGameEvents;

    /// <summary>
    /// Уничтожить оставшиеся шары в конце игры
    /// </summary>
    public class EndGameBalloonDestroyer : GlobalGameEventsProvider
    {
        protected GenericEventList<BalloonFacade> activeBallons = default;

        protected EndGameBalloonDestroyer(GlobalGameEvents globalGameEvents, GenericEventList<BalloonFacade> activeBalloons) : base(globalGameEvents) =>
            this.activeBallons = activeBalloons;

        protected override void OnEndGame() =>
            activeBallons.ClearList();

        protected override void OnGoToMenu() =>
            activeBallons.ClearList();
    }
}
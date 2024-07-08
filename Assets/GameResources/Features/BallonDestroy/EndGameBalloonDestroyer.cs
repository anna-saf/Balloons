namespace Balloons.Features.BalloonDestroy
{
    using Ballons.Features.BallonsSpawner;
    using Ballons.Features.Utilities;
    using Balloons.Features.GlobalGameEvents;

    /// <summary>
    /// Уничтожить оставшиеся шары в конце игры
    /// </summary>
    public class EndGameBalloonDestroyer : GlobalGameEventsProvider
    {
        protected GenericEventList<BallonFacade> activeBallons = default;

        protected EndGameBalloonDestroyer(GlobalGameEvents globalGameEvents, GenericEventList<BallonFacade> activeBalloons) : base(globalGameEvents) =>
            this.activeBallons = activeBalloons;

        protected override void OnEndGame() =>
            activeBallons.ClearList();
    }
}
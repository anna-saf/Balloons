namespace Balloons.Features.BalloonDestroy
{
    using Balloons.Features.GlobalGameEvents;

    /// <summary>
    /// Контроллер запуска и остановки проверки позиции шаров
    /// </summary>
    public class BehindScreenDestroyerController : GlobalGameEventsProvider
    {
        protected BehindScreenBalloonsDestroyer behindScreenBalloonDestroyer = default;

        protected BehindScreenDestroyerController(GlobalGameEvents globalGameEvents, BehindScreenBalloonsDestroyer behindScreenBalloonDestroyer) : base(globalGameEvents) =>
            this.behindScreenBalloonDestroyer = behindScreenBalloonDestroyer;

        protected override void OnStartGame() =>
            behindScreenBalloonDestroyer.StartCheckPosition();

        protected override void OnPauseGame() =>
            behindScreenBalloonDestroyer.StopCheckPosition();

        protected override void OnContinueGame() =>
            behindScreenBalloonDestroyer.StartCheckPosition();

        protected override void OnEndGame() =>
            behindScreenBalloonDestroyer.StopCheckPosition();

        protected override void OnGoToMenu() =>
            behindScreenBalloonDestroyer.StopCheckPosition();

    }
}

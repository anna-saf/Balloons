namespace Balloons.Features.EndGame
{
    using Balloons.Features.GlobalGameEvents;
    using Balloons.Features.Utilities;

    /// <summary>
    /// Открыть окно при завершении игры
    /// </summary>
    public class OpenWindowOnGameEnd : GlobalGameEventsProvider
    {
        protected WindowType window = default;
        protected bool needClose = false;

        protected WindowAgregator windowAgregator = default;

        protected OpenWindowOnGameEnd(GlobalGameEvents globalGameEvents,
                                      WindowAgregator windowAgregator,
                                      WindowType window,
                                      bool needClose) : base(globalGameEvents)
        {
            this.window = window;
            this.needClose = needClose;
            this.windowAgregator = windowAgregator;
        }

        protected override void OnEndGame() =>
            windowAgregator.SetWindowActive(window, needClose);
    }
}

namespace Balloons.Features.Utilities
{
    using Balloons.Features.GlobalGameEvents;

    /// <summary>
    /// Кнопка старта игры
    /// </summary>
    public class ButtonStart : GlobalGameEventsButton
    {
        protected override void Action() =>
            globalGameEvents.StartGame();
    }
}

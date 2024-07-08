namespace Balloons.Features.GlobalGameEvents
{
    /// <summary>
    /// Кнопка паузы игры
    /// </summary>
    public class ButtonPause : GlobalGameEventsButton
    {
        protected override void Action() =>
            globalGameEvents.PauseGame();
    }
}

namespace Balloons.Features.GlobalGameEvents
{
    /// <summary>
    /// Кнопка перехода в меню
    /// </summary>
    public class ButtonGoToMenu : GlobalGameEventsButton
    {
        protected override void Action() =>
            globalGameEvents.GoToMenu();
    }
}

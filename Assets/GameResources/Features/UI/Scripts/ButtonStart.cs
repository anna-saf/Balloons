namespace Balloons.Features.Utilities
{
    using Balloons.Features.GlobalGameEvents;
    using Zenject;

    /// <summary>
    /// Кнопка старта игры
    /// </summary>
    public class ButtonStart : AbstractButtonView
    {
        protected GlobalGameEvents globalGameEvents = default;

        [Inject]
        protected virtual void Construct(GlobalGameEvents globalGameEvents) =>
            this.globalGameEvents = globalGameEvents;

        protected override void Action() =>
            globalGameEvents.StartGame();
    }
}

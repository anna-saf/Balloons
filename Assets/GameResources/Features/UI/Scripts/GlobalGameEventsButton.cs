namespace Balloons.Features.GlobalGameEvents
{
    using Balloons.Features.Utilities;
    using Zenject;

    /// <summary>
    /// Абстрактный класс кнопки, которая переключает глобальный ивент
    /// </summary>
    public abstract class GlobalGameEventsButton : AbstractButtonView
    {
        protected GlobalGameEvents globalGameEvents = default;

        [Inject]
        protected virtual void Construct(GlobalGameEvents globalGameEvents) =>
            this.globalGameEvents = globalGameEvents;
    }
}

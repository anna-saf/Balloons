namespace Balloons.Features.GlobalGameEvents
{
    using Balloons.Features.Utilities;

    /// <summary>
    /// Сбросить значение при заходе в меню
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResetValueOnMenu<T> : GlobalGameEventsProvider
    {
        protected GenericEventValue<T> genericEventValue = default;

        protected ResetValueOnMenu(GlobalGameEvents globalGameEvents,
                                  GenericEventValue<T> genericEventValue) : base(globalGameEvents) =>
            this.genericEventValue = genericEventValue;

        protected override void OnGoToMenu() =>
            genericEventValue.SetDefaultValue();
    }
}

namespace Balloons.Features.Utilities
{
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Кнопка открытия окна 
    /// </summary>
    public class ButtonOpenWindow : AbstractButtonView
    {
        [SerializeField]
        protected WindowType targetWindow = default;
        [SerializeField]
        protected bool needClose = true;

        protected WindowAgregator windowAgregator = default;

        [Inject]
        protected virtual void Construct(WindowAgregator windowAgregator) =>
            this.windowAgregator = windowAgregator;

        protected override void Action() =>
            windowAgregator.SetWindowActive(targetWindow, needClose);
    }
}

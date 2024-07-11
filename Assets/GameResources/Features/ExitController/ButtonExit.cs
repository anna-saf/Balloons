namespace Balloons.Features.Exit
{
    using Balloons.Features.Utilities;
    using Zenject;

    /// <summary>
    /// Кнопка выхода из приложения
    /// </summary>
    public sealed class ButtonExit : AbstractButtonView
    {
        private ExitController _exitController = default;

        [Inject]
        private void Construct(ExitController exitController) =>
            this._exitController = exitController;   

        protected override void Action() =>
            _exitController.Exit();
    }
}

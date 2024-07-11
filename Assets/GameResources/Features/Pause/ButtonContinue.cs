namespace Balloons.Features.PauseController
{
    using Balloons.Features.Utilities;
    using Zenject;

    /// <summary>
    /// Кнопка продолжения игры
    /// </summary>
    public sealed class ButtonContinue : AbstractButtonView
    {
        private PauseController _pauseController = default;

        [Inject]
        private void Construct(PauseController pauseController) =>
            _pauseController = pauseController;

        protected override void Action() =>
            _pauseController.ContinueGame();
    }
}

namespace Balloons.Features.PauseController
{
    using Balloons.Features.Utilities;
    using Zenject;

    /// <summary>
    /// Кнопка паузы
    /// </summary>
    public class ButtonPause : AbstractButtonView
    {
        private PauseController _pauseController = default;

        [Inject]
        private void Construct(PauseController pauseController) =>
            _pauseController = pauseController;

        protected override void Action() =>
            _pauseController.PauseGame();
    }
}


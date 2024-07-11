namespace Balloons.Features.BallonsMovement
{
    using Zenject;

    /// <summary>
    /// Инсталлер настроек движения
    /// </summary>
    public class MovementInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            BindMovementController();

        private void BindMovementController() =>
            Container.Bind<IMovement>().To<VerticalMovementController>().AsTransient();
    }
}

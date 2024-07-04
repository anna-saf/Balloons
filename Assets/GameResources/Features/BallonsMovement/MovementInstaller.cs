namespace Ballons.Features.BallonsMovement
{
    using Zenject;

    /// <summary>
    /// Инсталлер настроек движения
    /// </summary>
    public class MovementInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMovement>().To<VerticalMovementController>().AsTransient();
        }
    }
}

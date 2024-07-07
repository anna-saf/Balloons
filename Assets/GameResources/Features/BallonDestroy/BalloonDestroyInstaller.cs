namespace Balloons.Features.BalloonDestroy
{
    using Zenject;

    /// <summary>
    /// Инсталлер модуля по уничтожению шаров 
    /// </summary>
    public class BalloonDestroyInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            BindBalloonDestroyController();

        private void BindBalloonDestroyController() =>
            Container.Bind<BalloonClickDestroyer>().AsSingle().NonLazy();
    }
}

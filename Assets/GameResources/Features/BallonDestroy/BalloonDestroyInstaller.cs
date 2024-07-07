namespace Balloons.Features.BalloonDestroy
{
    using Zenject;

    /// <summary>
    /// Инсталлер модуля по уничтожению шаров 
    /// </summary>
    public class BalloonDestroyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBalloonDestroyController();
            BindBalloonClickScoreIncreaser();
        }

        private void BindBalloonDestroyController() =>
            Container.Bind<BalloonClickDestroyer>().AsSingle().NonLazy();

        private void BindBalloonClickScoreIncreaser() =>
            Container.Bind<BalloonClickScoreIncreaser>().AsSingle().NonLazy();
    }
}

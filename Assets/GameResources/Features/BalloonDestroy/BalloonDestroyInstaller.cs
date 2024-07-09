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
            BindEndGameBalloonDestroyer();
        }

        private void BindBalloonDestroyController() =>
            Container.Bind<BalloonClickDestroyer>().AsSingle().NonLazy();

        private void BindBalloonClickScoreIncreaser() =>
            Container.Bind<BalloonClickScoreIncreaser>().AsSingle().NonLazy();

        private void BindEndGameBalloonDestroyer() =>
            Container.Bind<EndGameBalloonDestroyer>().AsSingle().NonLazy();
    }
}

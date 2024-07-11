namespace Balloons.Features.ActiveBalloons
{
    using Balloons.Features.BallonsSpawner;
    using Balloons.Features.Utilities;
    using Zenject;

    /// <summary>
    /// Инсталлер списка активных шаров с ивентами
    /// </summary>
    public class ActiveBalloonsInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            BindBallonsPool();

        private void BindBallonsPool() =>
            Container.Bind<GenericEventList<BalloonFacade>>().To<ActiveBalloons>().AsSingle();
    }
}

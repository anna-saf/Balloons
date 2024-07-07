namespace Balloons.Features.ActiveBalloons
{
    using Ballons.Features.BallonsSpawner;
    using Ballons.Features.Utilities;
    using Zenject;

    /// <summary>
    /// Инсталлер списка активных шаров с ивентами
    /// </summary>
    public class ActiveBalloonsInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            BindBallonsPool();

        private void BindBallonsPool() =>
            Container.Bind<GenericEventList<BallonFacade>>().To<ActiveBalloons>().AsSingle();
    }
}

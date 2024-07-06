namespace Balloons.Features.ActiveBalloons
{
    using Zenject;

    /// <summary>
    /// Инсталлер списка активных шаров с ивентами
    /// </summary>
    public class ActiveBalloonsInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            Container.Bind<ActiveBalloons>().AsSingle();
    }
}

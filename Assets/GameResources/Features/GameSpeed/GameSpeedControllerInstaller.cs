namespace Balloons.Features.GameSpeed
{
    using Zenject;

    /// <summary>
    /// Инсталлер контроллера скорости игры
    /// </summary>
    public sealed class GameSpeedControllerInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            BindGameSpeedController();

        private void BindGameSpeedController() =>
            Container.Bind<GameSpeedController>().FromNew().AsSingle().NonLazy();
    }
}
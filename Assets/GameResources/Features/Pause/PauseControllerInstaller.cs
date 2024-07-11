namespace Balloons.Features.PauseController
{
    using Zenject;

    /// <summary>
    /// Инсталлер контроллера паузы
    /// </summary>
    public sealed class PauseControllerInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            BindPauseController();

        private void BindPauseController() =>
            Container.Bind<PauseController>().FromNew().AsSingle();
    }
}

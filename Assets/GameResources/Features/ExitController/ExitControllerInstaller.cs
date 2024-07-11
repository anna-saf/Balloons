namespace Balloons.Features.Exit
{
    using Zenject;

    /// <summary>
    /// Инсталлер контроллера выхода из приложения
    /// </summary>
    public sealed class ExitControllerInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            BindExitController();

        private void BindExitController() =>
            Container.Bind<ExitController>().FromNew().AsSingle();
    }
}

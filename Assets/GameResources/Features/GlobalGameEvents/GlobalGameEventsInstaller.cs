namespace Balloons.Features.GlobalGameEvents
{
    using Zenject;

    /// <summary>
    /// Инсталлер глобальных ивентов игры
    /// </summary>
    public class GlobalGameEventsInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            BindGlobalGameEvents();

        private void BindGlobalGameEvents() =>
            Container.Bind<GlobalGameEvents>().AsSingle();
    }
}

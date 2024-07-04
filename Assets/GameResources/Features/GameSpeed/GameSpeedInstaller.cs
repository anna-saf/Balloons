namespace Ballons.Features.GameSpeed
{
    using Zenject;

    /// <summary>
    /// Инсталлер контроллера скорости игры
    /// </summary>
    public class GameSpeedInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameSpeedController>().AsSingle();
        }
    }
}

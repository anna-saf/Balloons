namespace Balloons.Features.EndGame
{
    using Balloons.Features.Utilities;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Инсталлер контроллеров конца игры
    /// </summary>
    public class EndGameControllersInstaller : MonoInstaller
    {
        [SerializeField]
        protected WindowType endGameWindow = default;
        [SerializeField]
        protected bool needClose = default;

        public override void InstallBindings()
        {
            BindEndGameOnLifeEnd();
            BindOpenWindowOnGameEnd();
        }

        private void BindEndGameOnLifeEnd() =>
            Container.Bind<EndGameOnLifesEnd>().AsSingle().NonLazy();

        private void BindOpenWindowOnGameEnd() =>
            Container.Bind<OpenWindowOnGameEnd>().AsSingle().WithArguments(endGameWindow, needClose).NonLazy();
    }
}

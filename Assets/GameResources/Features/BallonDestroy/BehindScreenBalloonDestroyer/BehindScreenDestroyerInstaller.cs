namespace Balloons.Features.BalloonDestroy
{
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Инсталлер для модуля удаления шаров за границами экрана
    /// </summary>
    public class BehindScreenDestroyerInstaller : MonoInstaller
    {
        [SerializeField]
        protected BehindScreenBalloonsDestroyer behindScreenBalloonsDestroyer = default;

        public override void InstallBindings()
        {
            BindBehindScreenBalloonsDestroyer(); 
            BindBehindScreenDestroyerController();
        }
        private void BindBehindScreenBalloonsDestroyer() =>
            Container.BindInstance(behindScreenBalloonsDestroyer).AsSingle();

        private void BindBehindScreenDestroyerController() =>
            Container.Bind<BehindScreenDestroyerController>().AsSingle().NonLazy();
    }
}

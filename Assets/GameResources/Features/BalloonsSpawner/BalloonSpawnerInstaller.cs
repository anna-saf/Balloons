namespace Balloons.Features.BallonsSpawner
{
    using Balloons.Features.BalloonDestroy;
    using Balloons.Features.BalloonSpawner;
    using Balloons.Features.Utilities;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Инсталлер для модуля спавна шаров
    /// </summary>
    public class BalloonSpawnerInstaller : MonoInstaller
    {
        [SerializeField]
        private BalloonsPool _ballonsPool = default;
        [SerializeField]
        private BalloonsSpawner _ballonSpawner = default;

        public override void InstallBindings()
        {
            BindSpritePositionSetter();
            BindBallonsPool();
            BindBallonFactory();
            BindBallonsSpawner(); 
            BindReleaseBalloons();
            BindBalloonSpawnerController();
        }

        private void BindSpritePositionSetter()
        {
            SetOutsideScreenPosition setOutsideScreenPosition = new SetOutsideScreenPosition(ScreenSide.Bottom);
            Container.Bind<ISpritePositionSetter>().FromInstance(setOutsideScreenPosition).AsSingle();
        }

        private void BindBallonsPool() =>
            Container.Bind<GenericComponentPool<BalloonFacade>>().To<BalloonsPool>().FromInstance(_ballonsPool).AsSingle();

        private void BindBallonFactory() =>
            Container.Bind<IBalloonFactory>().To<BalloonPoolFactory>().AsSingle();

        private void BindBallonsSpawner() =>
            Container.Bind<BalloonsSpawner>().FromInstance(_ballonSpawner).AsSingle();

        private void BindReleaseBalloons() =>
            Container.Bind<ReleaseBalloons>().AsSingle().NonLazy();

        private void BindBalloonSpawnerController() =>
            Container.Bind<BalloonSpawnerController>().AsSingle().NonLazy();
    }
}

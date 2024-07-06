namespace Ballons.Features.BallonsSpawner
{
    using Ballons.Features.Utilities;
    using Balloons.Features.BalloonDestroy;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Инсталлер для модуля спавна шаров
    /// </summary>
    public class BallonSpawnerInstaller : MonoInstaller
    {
        [SerializeField]
        private BallonsPool _ballonsPool = default;
        [SerializeField]
        private BallonsSpawner _ballonSpawner = default;

        public override void InstallBindings()
        {
            BindSpritePositionSetter();
            BindBallonsPool();
            BindBallonFactory();
            BindBallonsSpawner(); 
            BindReleaseBalloons();
        }

        private void BindSpritePositionSetter()
        {
            SetOutsideScreenPosition setOutsideScreenPosition = new SetOutsideScreenPosition(ScreenSide.Bottom);
            Container.Bind<ISpritePositionSetter>().FromInstance(setOutsideScreenPosition).AsSingle();
        }

        private void BindBallonsPool() =>
            Container.Bind<GenericComponentPool<BallonFacade>>().To<BallonsPool>().FromInstance(_ballonsPool).AsSingle();

        private void BindBallonFactory() =>
            Container.Bind<IBallonFactory>().To<BallonPoolFactory>().AsSingle();

        private void BindBallonsSpawner() =>
            Container.Bind<BallonsSpawner>().FromInstance(_ballonSpawner).AsSingle();

        private void BindReleaseBalloons() =>
            Container.Bind<ReleaseBalloons>().AsSingle().NonLazy();
    }
}

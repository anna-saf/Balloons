namespace Balloons.Features.GameLifes
{
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Исталлер модуля игровых жизней
    /// </summary>
    public class GameLifeInstaller : MonoInstaller
    {
        [SerializeField]
        protected LifesFactory lifesFactory = default;
        [SerializeField]
        protected AbstractLifeSpawner lifesSpawner = default;

        public override void InstallBindings()
        {
            BindLifesFactory(); 
            BindLifesSpawner(); 
            BindChangeLostLifeView();
        }

        private void BindLifesFactory() =>
            Container.Bind<ILifesFactory>().To<LifesFactory>().FromInstance(lifesFactory).AsSingle();

        private void BindLifesSpawner() =>
            Container.BindInstance(lifesSpawner).AsSingle().NonLazy();

        private void BindChangeLostLifeView() =>
            Container.Bind<ChangeLostLifeView>().AsSingle().NonLazy();
    }
}

namespace Ballons.Features.BallonsSpawner
{
    using Ballons.Features.Utilities;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Фабрика шаров через пул
    /// </summary>
    public class BallonPoolFactory : IBallonFactory
    {
        protected GenericComponentPool<BallonFacade> ballonPool = default;
        protected DiContainer diContainer = default;

        public BallonPoolFactory(GenericComponentPool<BallonFacade> ballonPool) =>
            this.ballonPool = ballonPool;

        public virtual BallonFacade CreateObject() =>
            ballonPool.Pool.Get();
    }
}

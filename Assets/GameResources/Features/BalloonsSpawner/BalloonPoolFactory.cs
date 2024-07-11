namespace Balloons.Features.BallonsSpawner
{
    using Balloons.Features.Utilities;
    using Zenject;

    /// <summary>
    /// Фабрика шаров через пул
    /// </summary>
    public class BalloonPoolFactory : IBalloonFactory
    {
        protected GenericComponentPool<BalloonFacade> ballonPool = default;
        protected DiContainer diContainer = default;

        public BalloonPoolFactory(GenericComponentPool<BalloonFacade> ballonPool) =>
            this.ballonPool = ballonPool;

        public virtual BalloonFacade CreateObject() =>
            ballonPool.Pool.Get();
    }
}

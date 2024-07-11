namespace Balloons.Features.BalloonDestroy
{
    using Balloons.Features.BallonsSpawner;
    using Balloons.Features.Utilities;
    using Balloons.Features.ActiveBalloons;

    /// <summary>
    /// Зарелизить шар, который стал неактивным
    /// </summary>
    public class ReleaseBalloons : ActiveBalloonsProvider
    {
        protected GenericComponentPool<BalloonFacade> ballonsPool = default;

        public ReleaseBalloons(GenericComponentPool<BalloonFacade> ballonsPool, GenericEventList<BalloonFacade> activeBalloons): base(activeBalloons) 
        {
            this.ballonsPool = ballonsPool;
            Subscribe();
        }

        protected override void BeforeRemovedFromList(BalloonFacade ballon)=>
            ballonsPool.Pool.Release(ballon);
    }
}

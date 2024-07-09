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

        public ReleaseBalloons(GenericComponentPool<BalloonFacade> ballonsPool, GenericEventList<BalloonFacade> activeBalloons)
        {
            this.ballonsPool = ballonsPool;
            genericEventList = activeBalloons;
            Subscribe();
        }

        protected override void OnRemovedFromList(BalloonFacade ballon)=>
            ballonsPool.Pool.Release(ballon);

        protected override void OnClearedList() =>
            ballonsPool.Pool.Clear();
    }
}

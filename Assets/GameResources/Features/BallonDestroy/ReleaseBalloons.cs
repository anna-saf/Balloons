namespace Balloons.Features.BalloonDestroy
{
    using Ballons.Features.BallonsSpawner;
    using Ballons.Features.Utilities;
    using Balloons.Features.ActiveBalloons;
    using UnityEngine;

    /// <summary>
    /// Зарелизить шар, который стал неактивным
    /// </summary>
    public class ReleaseBalloons : ActiveBalloonsProvider
    {
        protected GenericComponentPool<BallonFacade> ballonsPool = default;

        public ReleaseBalloons(GenericComponentPool<BallonFacade> ballonsPool, GenericEventList<BallonFacade> activeBalloons)
        {
            this.ballonsPool = ballonsPool;
            genericEventList = activeBalloons;
            Subscribe();
        }

        protected override void OnRemovedFromList(BallonFacade ballon)=>
            ballonsPool.Pool.Release(ballon);
    }
}

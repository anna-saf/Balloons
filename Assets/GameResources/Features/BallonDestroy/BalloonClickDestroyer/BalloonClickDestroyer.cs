namespace Balloons.Features.BalloonDestroy
{
    using Ballons.Features.BallonsSpawner;
    using Ballons.Features.Utilities;
    using Balloons.Features.ActiveBalloons;
    using UnityEngine;

    /// <summary>
    /// Удаляет шар из списка активных, если произошел клик на шар
    /// </summary>
    public class BalloonClickDestroyer : ActiveBalloonsProvider
    {
        public BalloonClickDestroyer(GenericEventList<BallonFacade> activeBalloons)
        {
            genericEventList = activeBalloons;      
            Subscribe();
        }

        protected override void OnAddedToList(BallonFacade ballon) =>
            ballon.onBalloonClicked += OnBalloonClicked;

        protected override void OnRemovedFromList(BallonFacade ballon)
        {
            if (ballon != null)
            {
                ballon.onBalloonClicked -= OnBalloonClicked;
            }
        }

        protected virtual void OnBalloonClicked(BallonFacade balloon) =>
            genericEventList.RemoveFromList(balloon);
    }
}

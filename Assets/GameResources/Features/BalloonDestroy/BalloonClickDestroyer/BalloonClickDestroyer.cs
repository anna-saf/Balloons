namespace Balloons.Features.BalloonDestroy
{
    using Balloons.Features.BallonsSpawner;
    using Balloons.Features.Utilities;
    using Balloons.Features.ActiveBalloons;
    using System;
    using UnityEngine;

    /// <summary>
    /// Удаляет шар из списка активных, если произошел клик на шар
    /// </summary>
    public class BalloonClickDestroyer : ActiveBalloonsProvider
    {
        public event Action onBalloonDestroyed = delegate { };  
        
        public BalloonClickDestroyer(GenericEventList<BalloonFacade> activeBalloons) : base(activeBalloons) =>  
            Subscribe();

        protected override void OnAddedToList(BalloonFacade ballon) =>
            ballon.onBalloonClicked += OnBalloonClicked;

        protected override void BeforeRemovedFromList(BalloonFacade ballon)
        {
            if (ballon != null)
            {
                ballon.onBalloonClicked -= OnBalloonClicked;
            }
        }

        protected virtual void OnBalloonClicked(BalloonFacade balloon)
        {
            genericEventList.RemoveFromList(balloon);
            onBalloonDestroyed();
        }
    }
}

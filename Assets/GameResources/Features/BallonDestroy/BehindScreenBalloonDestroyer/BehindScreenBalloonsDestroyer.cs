namespace Balloons.Features.BalloonDestroy
{
    using Ballons.Features.BallonsSpawner;
    using Ballons.Features.Utilities;
    using Balloons.Features.ActiveBalloons;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Удаляет активные шары, которые ушли за границы экрана
    /// </summary>
    public class BehindScreenBalloonsDestroyer : MonoBehaviour
    {
        public event Action onBehindScreenBalloon = delegate { };

        protected GenericEventList<BallonFacade> activeBalloons = default;
        protected Coroutine checkBallonsPositionCoroutine = default;

        [Inject]
        protected virtual void Construct(GenericEventList<BallonFacade> activeBalloons) =>
            this.activeBalloons = activeBalloons;

        public void StartCheckPosition() =>
            checkBallonsPositionCoroutine = StartCoroutine(CheckBallonsPositionCoroutine());

        public void StopCheckPosition() =>
            StopCoroutine();

        protected void StopCoroutine()
        {
            if(checkBallonsPositionCoroutine != null)
            {
                StopCoroutine(checkBallonsPositionCoroutine);
                checkBallonsPositionCoroutine = null;
            }
        }

        protected IEnumerator CheckBallonsPositionCoroutine()
        {
            while (isActiveAndEnabled)
            {
                yield return new WaitForFixedUpdate();
                CheckBalloonsPosition();
            }
        }

        protected void CheckBalloonsPosition()
        {
            List<BallonFacade> ballons = new List<BallonFacade>(activeBalloons.GenericList);

            foreach(BallonFacade balloon in ballons)
            {
                if (!balloon.BallonSpriteRenderer.isVisible)
                {
                    activeBalloons.RemoveFromList(balloon);
                    onBehindScreenBalloon();
                }
            }
        }

        protected virtual void OnDisable() =>
            StopCoroutine();
    }
}

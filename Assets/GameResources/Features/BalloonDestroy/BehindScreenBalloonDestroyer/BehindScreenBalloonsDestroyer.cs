namespace Balloons.Features.BalloonDestroy
{
    using Balloons.Features.BallonsSpawner;
    using Balloons.Features.Utilities;
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

        protected GenericEventList<BalloonFacade> activeBalloons = default;
        protected Coroutine checkBallonsPositionCoroutine = default;

        [Inject]
        protected virtual void Construct(GenericEventList<BalloonFacade> activeBalloons) =>
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
            List<BalloonFacade> ballons = new List<BalloonFacade>(activeBalloons.GenericList);

            foreach(BalloonFacade balloon in ballons)
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

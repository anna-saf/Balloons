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
        protected const int HALF_VALUE_DECREASER = 2;

        /// <summary>
        /// Событие того, что шар вышел за пределы экрана
        /// </summary>
        public event Action onBehindScreenBalloon = delegate { };

        protected GenericEventList<BalloonFacade> activeBalloons = default;
        protected Coroutine checkBallonsPositionCoroutine = default;

        protected Vector3 minScreenCoord = default;
        protected Vector3 maxScreenCoord = default;


        [Inject]
        protected virtual void Construct(GenericEventList<BalloonFacade> activeBalloons)
        {
            this.activeBalloons = activeBalloons;
            minScreenCoord = Camera.main.ViewportToWorldPoint(Vector3.zero);
            maxScreenCoord = Camera.main.ViewportToWorldPoint(Vector3.one);
        }

        public void StartCheckPosition() =>
            checkBallonsPositionCoroutine = StartCoroutine(CheckBallonsPositionCoroutine());

        public void StopCheckPosition() =>
            StopCheckPositionCoroutine();

        protected void StopCheckPositionCoroutine()
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
                yield return null;
                CheckBalloonsPosition();
            }
        }

        protected void CheckBalloonsPosition()
        {
            List<BalloonFacade> ballons = new List<BalloonFacade>(activeBalloons.GenericList);

            foreach(BalloonFacade balloon in ballons)
            {
                if (IsBehindScreen(balloon.BallonSpriteRenderer))
                {
                    activeBalloons.RemoveFromList(balloon);
                    onBehindScreenBalloon();
                }
            }
        }

        protected bool IsBehindScreen(SpriteRenderer balloonSprite)
        {
            Transform balloonTransform = balloonSprite.transform;

            float spriteHalfWidth = balloonSprite.bounds.size.x / HALF_VALUE_DECREASER;
            float spriteHalfHeight = balloonSprite.bounds.size.y / HALF_VALUE_DECREASER;

            if(minScreenCoord.x - spriteHalfWidth >= balloonTransform.position.x ||
               maxScreenCoord.x + spriteHalfWidth <= balloonTransform.position.x ||
               minScreenCoord.y - spriteHalfHeight >= balloonTransform.position.y || 
               maxScreenCoord.y + spriteHalfHeight <= balloonTransform.position.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual void OnDisable() =>
            StopCheckPositionCoroutine();
    }
}

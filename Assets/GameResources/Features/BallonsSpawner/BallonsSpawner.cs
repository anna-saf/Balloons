namespace Ballons.Features.BallonsSpawner
{
    using Ballons.Features.GameSettings;
    using Ballons.Features.GameSpeed;
    using Ballons.Features.Utilities;
    using System.Collections;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Контроллер спавна шаров
    /// </summary>
    public class BallonsSpawner : MonoBehaviour
    {
        protected IBallonFactory ballonsFactory = default;
        protected ISpritePositionSetter positionSetter = default;
        protected float spawnSpeed = default;
        protected GenericEventList<BallonFacade> activeBalloons = default;

        protected Coroutine spawnCoroutine = default;

        [Inject]
        protected virtual void Construct(IBallonFactory ballonsFactory, 
                                         ISpritePositionSetter positionSetter, 
                                         GameSpeedController gameSpeedController, 
                                         BallonSpawnSettings ballonSpawnSettings,
                                         GenericEventList<BallonFacade> activeBalloons)
        {
            this.ballonsFactory = ballonsFactory;
            this.positionSetter = positionSetter;
            this.activeBalloons = activeBalloons;
            spawnSpeed = ballonSpawnSettings.SpawnInterval * gameSpeedController.CurrentSpeed;
        }

        /// <summary>
        /// Запустить спавн шаров
        /// </summary>
        public virtual void StartSpawn() =>
            spawnCoroutine = StartCoroutine(SpawnBallons());

        /// <summary>
        /// Остановить спавн шаров
        /// </summary>
        public virtual void StopSpawn() 
        {
            if(spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
                spawnCoroutine = null;
            }
        }

        protected virtual IEnumerator SpawnBallons()
        {
            while (isActiveAndEnabled)
            {
                BallonFacade ballon = ballonsFactory.CreateObject();
                positionSetter.SetPosition(ballon.transform,ballon.BallonSpriteRenderer);
                activeBalloons.AddToList(ballon);
                yield return new WaitForSeconds(spawnSpeed);
            }
        }

        protected virtual void OnDisable() =>
            StopSpawn();
    }
}

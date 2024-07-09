namespace Balloons.Features.BallonsSpawner
{
    using Balloons.Features.GameSettings;
    using Balloons.Features.GlobalGameValues;
    using Balloons.Features.Utilities;
    using System.Collections;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Контроллер спавна шаров
    /// </summary>
    public class BalloonsSpawner : MonoBehaviour
    {
        protected IBalloonFactory ballonsFactory = default;
        protected ISpritePositionSetter positionSetter = default;
        protected GenericEventList<BalloonFacade> activeBalloons = default;

        protected float spawnInterval = default;
        protected GenericEventValue<float> gameSpeed = default;

        protected float spawnSpeed = default;

        protected Coroutine spawnCoroutine = default;

        [Inject]
        protected virtual void Construct(IBalloonFactory ballonsFactory, 
                                         ISpritePositionSetter positionSetter, 
                                         [Inject(Id = GlobalGameValueType.Speed)]GenericEventValue<float> gameSpeed, 
                                         BalloonSpawnSettings ballonSpawnSettings,
                                         GenericEventList<BalloonFacade> activeBalloons)
        {
            this.ballonsFactory = ballonsFactory;
            this.positionSetter = positionSetter;
            this.activeBalloons = activeBalloons;
            this.gameSpeed = gameSpeed;
            spawnInterval = ballonSpawnSettings.SpawnInterval;
        }

        protected virtual void OnEnable()
        {
            OnGameSpeedChanged();
            gameSpeed.onValueChanged += OnGameSpeedChanged;
        }

        protected virtual void OnDisable()
        {
            gameSpeed.onValueChanged -= OnGameSpeedChanged;
            StopSpawn();
        }

        protected void OnGameSpeedChanged() =>
            spawnSpeed = (float)spawnInterval / gameSpeed.Value;

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
                BalloonFacade ballon = ballonsFactory.CreateObject();
                positionSetter.SetPosition(ballon.transform,ballon.BallonSpriteRenderer);
                activeBalloons.AddToList(ballon);
                yield return new WaitForSeconds(spawnSpeed);
            }
        }
    }
}

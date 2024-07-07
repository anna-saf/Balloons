namespace Balloons.Features.GameLifes
{
    using Balloons.Features.GlobalGameValues;
    using Balloons.Features.Utilities;
    using System.Collections.Generic;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Абстрактный спавнер жизней
    /// </summary>
    public abstract class AbstractLifeSpawner : MonoBehaviour
    {
        /// <summary>
        /// Получение списка заспавненных вью жизней
        /// </summary>
        public List<LifeFacade> OrderedSpawnedLifes => orderedSpawnedLifes;
        [SerializeField]
        protected Transform lifesParentTransform = default;

        protected ILifesFactory lifesFactory = default;
        protected GenericEventValue<int> lifesCount = default;

        protected List<LifeFacade> orderedSpawnedLifes = new List<LifeFacade>();

        [Inject]
        protected virtual void Construct(ILifesFactory lifesFactory, [Inject(Id = GlobalGameValueType.Lifes)] GenericEventValue<int> lifesCount)
        {
            this.lifesFactory = lifesFactory;
            this.lifesCount = lifesCount;
        }

        protected virtual void StartSpawn()
        {
            for (int i = 0; i < lifesCount.Value; i++)
            {
                LifeFacade lifeFacade = lifesFactory.CreateLife();
                lifeFacade.transform.SetParent(lifesParentTransform);
                orderedSpawnedLifes.Add(lifeFacade);
            }
        }
    }
}

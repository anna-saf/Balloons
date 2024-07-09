namespace Balloons.Features.Utilities
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Pool;

    /// <summary>
    /// Дженерик пул компонентов
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericComponentPool<T> : MonoBehaviour where T : Component
    {
        /// <summary>
        /// Получить пул
        /// </summary>
        public IObjectPool<T> Pool
        {
            get
            {
                if (pool == null)
                {
                    if (poolType == PoolType.Stack)
                        pool = new ObjectPool<T>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, maxPoolSize);
                    else
                        pool = new LinkedPool<T>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, maxPoolSize);
                }
                return pool;
            }
        }

        [SerializeField]
        protected PoolType poolType = default;
        [SerializeField]
        protected bool collectionChecks = true;
        [SerializeField]
        protected int maxPoolSize = 20;
        [SerializeField]
        protected T templateItemPool = default;

        protected IObjectPool<T> pool = default;
        protected List<T> activeObjectsInPool = new List<T>();

        protected virtual T CreatePooledItem()
        {
            GameObject spawnedGO = SpawnPooledItem();
            if (spawnedGO)
            {
                if (spawnedGO.TryGetComponent(out T component))
                {
                    AddToActiveObjectsList(component);
                    return component;
                }
                else
                {
                    Debug.Log("В заспавненном объекте не найден компонент типа " + nameof(T));
                    Destroy(spawnedGO);
                    return null;
                }
            }
            else
            {
                Debug.Log("Не удалось заспавнить компонент");
                return null;
            }
        }

        protected virtual GameObject SpawnPooledItem() =>
            Instantiate(templateItemPool.gameObject);

        protected virtual void OnReturnedToPool(T itemPool)
        {
            RemoveFromActiveObjectsList(itemPool);
            itemPool.gameObject.SetActive(false);
        }

        protected virtual void OnTakeFromPool(T itemPool)
        {
            AddToActiveObjectsList(itemPool);
            itemPool.gameObject.SetActive(true);
        }

        protected virtual void OnDestroyPoolObject(T itemPool)
        {
            RemoveFromActiveObjectsList(itemPool);
            itemPool.gameObject.SetActive(false);
        }

        protected virtual void RemoveFromActiveObjectsList(T itemPool)
        {
            if (activeObjectsInPool.Contains(itemPool))
            {
                activeObjectsInPool.Remove(itemPool);
            }
        }

        protected virtual void AddToActiveObjectsList(T itemPool)
        {
            if (!activeObjectsInPool.Contains(itemPool))
            {
                activeObjectsInPool.Add(itemPool);
            }
        }
    }
}

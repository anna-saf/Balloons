namespace Balloons.Features.GameLifes
{
    using UnityEngine;

    /// <summary>
    /// Фабрика жизней
    /// </summary>
    public class LifesFactory : MonoBehaviour, ILifesFactory
    {
        [SerializeField]
        protected LifeFacade lifePrefab = default;

        public LifeFacade CreateLife() =>
            Instantiate(lifePrefab);
    }
}

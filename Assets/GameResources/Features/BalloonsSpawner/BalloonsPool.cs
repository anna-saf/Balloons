namespace Balloons.Features.BallonsSpawner
{
    using Balloons.Features.Utilities;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Пул для шаров
    /// </summary>
    public class BalloonsPool : GenericComponentPool<BalloonFacade>
    {
        protected DiContainer diContainer = default;

        [Inject]
        protected virtual void Construct(DiContainer diContainer) =>
            this.diContainer = diContainer;

        protected override GameObject SpawnPooledItem() =>
            diContainer.InstantiatePrefab(templateItemPool);
    }
}

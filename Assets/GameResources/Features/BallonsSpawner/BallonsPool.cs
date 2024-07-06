namespace Ballons.Features.BallonsSpawner
{
    using Ballons.Features.Utilities;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Пул для шаров
    /// </summary>
    public class BallonsPool : GenericComponentPool<BallonFacade>
    {
        protected DiContainer diContainer = default;

        [Inject]
        protected virtual void Construct(DiContainer diContainer) =>
            this.diContainer = diContainer;

        protected override GameObject SpawnPooledItem() =>
            diContainer.InstantiatePrefab(templateItemPool);
    }
}

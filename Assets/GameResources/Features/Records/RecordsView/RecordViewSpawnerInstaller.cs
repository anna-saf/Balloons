namespace Balloons.Features.Records
{
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Инсталлер спавнера рекордов
    /// </summary>
    public class RecordViewSpawnerInstaller : MonoInstaller
    {
        [SerializeField]
        protected RecordViewSpawner recordViewSpawner = default;

        public override void InstallBindings() =>
            BindRecordViewSpawner();

        protected void BindRecordViewSpawner() =>
            Container.BindInstance(recordViewSpawner);
    }
}

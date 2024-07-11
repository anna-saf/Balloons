namespace Balloons.Features.Records
{
    using Balloons.Features.Utilities;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Инсталлер модуля рекордов
    /// </summary>
    public sealed class RecordsDataInstaller : MonoInstaller
    {
        private const string RECORDS_FILE_NAME = "Records";

        public override void InstallBindings()
        {
            BindRecordsEventList();
            BindRecordDataSaveLoad();
            BindReadRecords();
            BindUpdateRecords();
        }

        private void BindRecordDataSaveLoad()
        {
            TextSaveLoad textSaveLoad = new TextSaveLoad(Application.persistentDataPath);
            GenericJSONSerializer<RecordsData> genericJSONSerializer = new RecordsJSONSerializer();
            Container.Bind<IRecordsDataSaveLoad>().To<RecordsDataSaveLoad>().AsSingle().WithArguments(textSaveLoad, genericJSONSerializer, RECORDS_FILE_NAME);
        }

        private void BindRecordsEventList() =>
            Container.Bind<GenericEventList<RecordNameData>>().FromNew().AsSingle();

        private void BindReadRecords() =>
            Container.Bind<ReadRecords>().FromNew().AsSingle().NonLazy();

        private void BindUpdateRecords() =>
            Container.Bind<UpdateRecords>().FromNew().AsSingle().NonLazy();
    }
}

namespace Balloons.Features.Records
{
    using Balloons.Features.Utilities;

    /// <summary>
    /// Обновить таблицу рекордов
    /// </summary>
    public class UpdateRecords : GenericEventListProvider<RecordNameData>
    {
        protected IRecordsDataSaveLoad recordsDataSaveLoad = default;

        public UpdateRecords(GenericEventList<RecordNameData> recordsData, IRecordsDataSaveLoad recordsDataSaveLoad) : base(recordsData)
        {
            this.recordsDataSaveLoad = recordsDataSaveLoad;
            Subscribe();
        }

        protected override void OnAddedToList(RecordNameData obj) =>
            SaveRecords();

        protected override void OnRemovedFromList(RecordNameData obj) =>
            SaveRecords();

        protected override void OnClearedList() =>
            SaveRecords();

        protected void SaveRecords()
        {
            RecordsData recordsSaveData = new RecordsData();

            if (genericEventList.GenericList != null)
            {
                foreach (RecordNameData recordNameData in genericEventList.GenericList)
                {
                    recordsSaveData.recordsList.Add(recordNameData);
                }
                recordsDataSaveLoad.Save(recordsSaveData);
            }
        }
    }
}

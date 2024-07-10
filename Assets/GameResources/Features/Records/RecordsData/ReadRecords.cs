namespace Balloons.Features.Records
{
    using Balloons.Features.Utilities;
    using UnityEngine;

    /// <summary>
    /// Прочитать сохраненные рекорды и занести их в GenericEventList
    /// </summary>
    public class ReadRecords
    {
        public ReadRecords(GenericEventList<RecordNameData> recordsData, IRecordsDataSaveLoad recordsDataSaveLoad) =>
            LoadRecords(recordsDataSaveLoad, recordsData);

        protected void LoadRecords(IRecordsDataSaveLoad recordsDataSaveLoad,
                                   GenericEventList<RecordNameData> recordsData)
        {
            RecordsData recordsSaveData = recordsDataSaveLoad.Load();

            if (recordsSaveData != null)
            {
                foreach (RecordNameData recordNameData in recordsSaveData.recordsList)
                {
                    recordsData.AddToList(recordNameData);
                }
            }
        }
    }
}

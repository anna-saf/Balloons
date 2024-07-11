namespace Balloons.Features.Records
{
    using Balloons.Features.Utilities;
    using UnityEngine;

    /// <summary>
    /// Контроллер чтения и сохранения даты рекордов
    /// </summary>
    public class RecordsDataSaveLoad : IRecordsDataSaveLoad
    {
        protected string fileName = default;
        protected TextSaveLoad textSaveLoad = default;
        protected GenericJSONSerializer<RecordsData> recordsJSONSerializer = default;

        public RecordsDataSaveLoad(TextSaveLoad textSaveLoad, GenericJSONSerializer<RecordsData> recordsJSONSerializer, string fileName)
        {
            this.textSaveLoad = textSaveLoad;
            this.recordsJSONSerializer = recordsJSONSerializer;
            this.fileName = fileName;
        }

        public void Save(RecordsData recordsData)
        {
            if (recordsData != null)
            {
                string data = recordsJSONSerializer.SerializeData(recordsData);
                if (data != null)
                {
                    textSaveLoad.Save(data, fileName);
                }
            }
        }

        public RecordsData Load()
        {
            string data = textSaveLoad.Load(fileName);
            if (data != null)
            {
                return recordsJSONSerializer.DeserializeData(data);
            }
            else
            {
                return null;
            }
        }
    }
}

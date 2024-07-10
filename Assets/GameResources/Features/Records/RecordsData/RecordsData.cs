namespace Balloons.Features.Records
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Вся дата рекордов
    /// </summary>
    [Serializable]
    public class RecordsData
    {
        public List<RecordNameData> recordsList = new List<RecordNameData>();
    }
}

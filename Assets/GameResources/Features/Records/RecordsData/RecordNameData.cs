namespace Balloons.Features.Records
{
    using System;

    /// <summary>
    /// Связь имени и рекорда
    /// </summary>
    [Serializable]
    public class RecordNameData
    {
        public string Name = default;
        public int Score = default;
    }
}

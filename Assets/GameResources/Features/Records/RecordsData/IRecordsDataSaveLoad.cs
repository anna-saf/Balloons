namespace Balloons.Features.Records
{
    /// <summary>
    /// Интерфейс контроллера чтения и сохранения рекордов
    /// </summary>
    public interface IRecordsDataSaveLoad
    {
        /// <summary>
        /// Сохранение даты рекордов
        /// </summary>
        /// <param name="recordsData"></param>
        public void Save(RecordsData recordsData);

        /// <summary>
        /// Загрузка даты рекордов
        /// </summary>
        /// <returns></returns>
        public RecordsData Load();
    }
}

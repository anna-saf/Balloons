namespace Balloons.Features.Utilities
{
    using System.IO;
    using UnityEngine;

    /// <summary>
    /// Сохранение и загрузка текстовой даты
    /// </summary>
    public class TextSaveLoad : AbstractSaveLoad<string>
    {
        public TextSaveLoad(string savePath, string fileExtension = EMPTY_STRING) : base(savePath, fileExtension) { }

        public override void Save(string data, string fileName) =>
            File.WriteAllText(Path.Combine(TryCreateDirectory(), fileName, fileExtension), data);

        public override string Load(string fileName)
        {
            string path = Path.Combine(savePath, fileName, fileExtension);

            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else
            {
                Debug.Log("Пути " + path + " не существует");
                return string.Empty;
            }
        }
    }
}

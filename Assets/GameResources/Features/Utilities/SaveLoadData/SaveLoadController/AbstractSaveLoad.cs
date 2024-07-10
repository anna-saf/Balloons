namespace Balloons.Features.Utilities
{
    using System.IO;
    using UnityEngine;

    /// <summary>
    /// Абстрактный дженерик для сохранения и загрузки даты
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractSaveLoad<T>
    {
        protected const string EMPTY_STRING = "";

        protected string savePath = default;
        protected string fileExtension = default;

        public AbstractSaveLoad(string savePath, string fileExtension = EMPTY_STRING)
        {
            this.savePath = savePath;
            this.fileExtension = fileExtension;
        }

        public abstract void Save(T data, string fileName);
        public abstract T Load(string fileName);

        protected string TryCreateDirectory()
        {
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            return savePath;
        }
    }
}

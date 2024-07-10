namespace Balloons.Features.Utilities
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;

    /// <summary>
    /// Преобразователь данных из json в T и обратно
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericJSONSerializer<T>
    {
        /// <summary>
        /// Сериализовать данные
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string SerializeData(T data) =>
            JsonConvert.SerializeObject(data);

        /// <summary>
        /// Десериализовать данные
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public T DeserializeData(string data)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(data);
            }
            catch(Exception e)
            {
                Debug.Log("Ошибка десериализации данных " + e.Message + e.StackTrace);
                return default;
            }
        }
    }
}

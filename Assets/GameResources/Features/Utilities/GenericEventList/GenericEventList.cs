namespace Balloons.Features.Utilities
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Дженерик лист с событиями добавления и удаления элемента
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericEventList<T>
    {
        /// <summary>
        /// Вызывается при добавлении элемента в лист
        /// </summary>
        public event Action<T> onAddedToList = delegate { };
        /// <summary>
        /// Вызывается до удаления элемента из листа (для совершения отписок)
        /// </summary>
        public event Action<T> beforeRemovedFromList = delegate { };
        /// <summary>
        /// Вызывается при удалении элемента из листа
        /// </summary>
        public event Action<T> onRemovedFromList = delegate { };
        /// <summary>
        /// Вызывается при очищении листа
        /// </summary>
        public event Action onClearedList = delegate { };

        /// <summary>
        /// Получение листа элементов
        /// </summary>
        public IReadOnlyList<T> GenericList => genericList;

        protected List<T> genericList = new List<T>();

        /// <summary>
        /// Добавить элемент в лист
        /// </summary>
        /// <param name="itemList"></param>
        public void AddToList(T itemList)
        {
            if (!genericList.Contains(itemList))
            {
                genericList.Add(itemList);
                onAddedToList(itemList);
            }
            else
            {
                Debug.Log("Не удалось добавить элемент в лист - он уже существует в нем");
            }
        }

        /// <summary>
        /// Удалить элемент из листа
        /// </summary>
        /// <param name="itemList"></param>
        public void RemoveFromList(T itemList)
        {
            if (genericList.Contains(itemList))
            {
                beforeRemovedFromList(itemList);
                genericList.Remove(itemList);
                onRemovedFromList(itemList);
            }
            else
            {
                Debug.Log("Не удалось удалить элемент из листа - его там не существует");
            }
        }

        /// <summary>
        /// Очистить лист
        /// </summary>
        public void ClearList()
        {
            foreach (T itemList in genericList)
            { 
                beforeRemovedFromList(itemList);
            }
            genericList.Clear();
            onClearedList();
        }
    }
}

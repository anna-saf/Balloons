namespace Ballons.Features.Utilities
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Дженерик провайдер листа объектов с ивентами
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericEventListProvider<T> : IDisposable
    {
        protected GenericEventList<T> genericEventList = default;

        protected virtual void Subscribe()
        {
            genericEventList.onAddedToList += OnAddedToList;
            genericEventList.onRemovedFromList += OnRemovedFromList;
            genericEventList.onClearedList += OnClearedList;
        }

        protected virtual void Unsubscribe()
        {
            if (genericEventList != null)
            {
                genericEventList.onAddedToList -= OnAddedToList;
                genericEventList.onRemovedFromList -= OnAddedToList;
                genericEventList.onClearedList -= OnClearedList;
            }
        }

        protected virtual void OnAddedToList(T obj)
        {
            ///При необходимости реализовать в наследниках
        }

        protected virtual void OnRemovedFromList(T obj)
        {
            ///При необходимости реализовать в наследниках
        }

        protected virtual void OnClearedList()
        {
            ///При необходимости реализовать в наследниках
        }

        public void Dispose() =>
            Unsubscribe();
    }
}

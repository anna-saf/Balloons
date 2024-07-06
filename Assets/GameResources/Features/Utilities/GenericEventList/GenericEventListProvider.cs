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
            genericEventList.beforeRemoveFromList += BeforeRemovedFromList;
            genericEventList.onRemovedFromList += OnRemovedFromList; 
        }

        protected virtual void Unsubscribe()
        {
            if (genericEventList != null)
            {
                genericEventList.onAddedToList -= OnAddedToList;
                genericEventList.beforeRemoveFromList -= BeforeRemovedFromList;
                genericEventList.onRemovedFromList -= OnAddedToList;
            }
        }

        protected virtual void OnAddedToList(T obj)
        {
            ///При необходимости реализовать в наследниках
        }

        protected virtual void BeforeRemovedFromList(T obj)
        {
            ///При необходимости реализовать в наследниках
        }

        protected virtual void OnRemovedFromList(T obj)
        {
            ///При необходимости реализовать в наследниках
        }

        public void Dispose() =>
            Unsubscribe();
    }
}

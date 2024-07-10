namespace Balloons.Features.Utilities
{
    using System;

    /// <summary>
    /// Дженерик провайдер листа объектов с ивентами
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericEventListProvider<T> : IDisposable
    {
        protected GenericEventList<T> genericEventList = default;

        protected GenericEventListProvider(GenericEventList<T> genericEventList) =>
            this.genericEventList = genericEventList;   

        protected virtual void Subscribe()
        {
            genericEventList.onAddedToList += OnAddedToList;
            genericEventList.beforeRemovedFromList += BeforeRemovedFromList;
            genericEventList.onRemovedFromList += OnRemovedFromList;
            genericEventList.onClearedList += OnClearedList;
        }

        protected virtual void Unsubscribe()
        {
            if (genericEventList != null)
            {
                genericEventList.onAddedToList -= OnAddedToList;
                genericEventList.beforeRemovedFromList -= BeforeRemovedFromList;
                genericEventList.onRemovedFromList -= OnAddedToList;
                genericEventList.onClearedList -= OnClearedList;
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

        protected virtual void OnClearedList()
        {
            ///При необходимости реализовать в наследниках
        }

        public void Dispose() =>
            Unsubscribe();
    }
}

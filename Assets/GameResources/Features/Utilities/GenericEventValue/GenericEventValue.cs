namespace Balloons.Features.Utilities
{
    using System;

    /// <summary>
    /// Джененик значение со свойством на изменение
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericEventValue<T> 
    {
        /// <summary>
        /// Вызывается при изменении значения
        /// </summary>
        public event Action onValueChanged = delegate { };

        ///Получение и изменение значения
        public T Value
        {
            get => value;
            set
            {
                if (!value.Equals(this.value))
                {
                    this.value = value;
                    onValueChanged();
                }
            }
        }
        protected T value = default;
    }
}

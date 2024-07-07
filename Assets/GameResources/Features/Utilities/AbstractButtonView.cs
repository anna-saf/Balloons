namespace Balloons.Features.Utilities
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Абстрактная кнопка
    /// </summary>
    [RequireComponent(typeof(Button))]
    public abstract class AbstractButtonView : MonoBehaviour
    {
        protected Button button = default;

        protected virtual void Awake() =>
            button = GetComponent<Button>();

        protected virtual void OnEnable() =>
            button.onClick.AddListener(Action);

        protected virtual void OnDisable() =>
            button.onClick.RemoveListener(Action);

        /// <summary>
        /// Вызывается при клике на кнопку
        /// </summary>
        protected abstract void Action();
    }
}

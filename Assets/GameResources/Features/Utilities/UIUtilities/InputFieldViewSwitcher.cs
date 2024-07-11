namespace Balloons.Features.Records
{
    using Balloons.Features.UIUtilities;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Переключает вью, если в InputField определенное количество символов
    /// </summary>
    public class InputFieldViewSwitcher : BaseObjectSwitcher
    {
        [SerializeField, Min(0)]
        protected int symbolsCount = 0;
        [SerializeField]
        protected InputField inputField = default;

        protected virtual void OnEnable()
        {
            OnInputFieldChanged(inputField.text);
            inputField.onValueChanged.AddListener(OnInputFieldChanged);
        }

        protected virtual void OnDisable() =>
            inputField.onValueChanged.RemoveListener(OnInputFieldChanged);

        protected virtual void OnInputFieldChanged(string value) =>
            SetStatus(value.Length > 0);
    }
}

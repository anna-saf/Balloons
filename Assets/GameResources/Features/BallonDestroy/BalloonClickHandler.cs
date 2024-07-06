namespace Balloons.Features.BalloonDestroy
{
    using System;
    using UnityEngine;
    using UnityEngine.EventSystems;

    /// <summary>
    /// Определяет клик по шару
    /// </summary>
    public class BalloonClickHandler : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Вызывается, когда на шар кликнули
        /// </summary>
        public event Action onBallonClicked = default;

        public void OnPointerClick(PointerEventData eventData) =>
            onBallonClicked();
    }
}

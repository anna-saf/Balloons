namespace Balloons.Features.Utilities
{
    using UnityEngine;

    /// <summary>
    /// Интерфейс для перемещения спрайта
    /// </summary>
    public interface ISpritePositionSetter
    {
        /// <summary>
        /// Задать позицию спрайта
        /// </summary>
        /// <param name="targetObject"></param>
        public void SetPosition(Transform targetObjectTransform, SpriteRenderer targetObjectSprite);
    }
}
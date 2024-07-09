namespace Balloons.Features.BallonsMovement
{
    using UnityEngine;

    /// <summary>
    /// Интерфейс контроллера передвижения
    /// </summary>
    public interface IMovement
    {
        /// <summary>
        /// Метод передвижения объекта
        /// </summary>
        /// <param name="movementObject"></param>
        public void Move(Transform movementObject);
    }
}

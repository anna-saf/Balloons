namespace Ballons.Features.BallonsMovement
{
    using Ballons.Features.GameSpeed;
    using UnityEngine;

    /// <summary>
    /// Контроллер вертикального передвижения
    /// </summary>
    public class VerticalMovementController : IMovement
    {
        protected float speed = default;
        protected Vector3 startPosition = default;

        public VerticalMovementController(GameSpeedController gameSpeedController)
        {
            speed = gameSpeedController.CurrentSpeed;
        }

        /// <summary>
        /// Переместить объект по вертикали
        /// </summary>
        /// <param name="movementObject"></param>
        public virtual void Move(Transform movementObject)
        {
            startPosition = movementObject.transform.position;
            movementObject.transform.position = new Vector3(startPosition.x, startPosition.y + speed, startPosition.z);
        }
    }
}

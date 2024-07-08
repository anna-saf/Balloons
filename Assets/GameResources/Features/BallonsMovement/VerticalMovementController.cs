namespace Ballons.Features.BallonsMovement
{
    using Ballons.Features.GameSettings;
    using Balloons.Features.GlobalGameValues;
    using Balloons.Features.Utilities;
    using System;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Контроллер вертикального передвижения
    /// </summary>
    public class VerticalMovementController : IMovement, IDisposable
    {
        protected GenericEventValue<float> gameSpeed = default;
        protected float movementSpeed = default;


        protected float currentSpeed = default;
        protected Vector3 startPosition = default;

        public VerticalMovementController([Inject(Id = GlobalGameValueType.Speed)]GenericEventValue<float> speed, MovementSettings movementSettings)
        {
            movementSpeed = movementSettings.MovementSpeed;

            this.gameSpeed = speed;
            OnSpeedChanged();
            gameSpeed.onValueChanged += OnSpeedChanged;
        }

        private void OnSpeedChanged() =>
            currentSpeed = movementSpeed * gameSpeed.Value;

        /// <summary>
        /// Переместить объект по вертикали
        /// </summary>
        /// <param name="movementObject"></param>
        public virtual void Move(Transform movementObject)
        {
            startPosition = movementObject.transform.position;
            movementObject.transform.position = new Vector3(startPosition.x, startPosition.y + currentSpeed, startPosition.z);
        }

        public void Dispose() =>
            gameSpeed.onValueChanged -= OnSpeedChanged;
    }
}

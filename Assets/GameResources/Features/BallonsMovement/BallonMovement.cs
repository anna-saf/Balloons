namespace Ballons.Features.BallonsMovement
{ 
    using System.Collections;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Передвижение шара
    /// </summary>
    public class BallonMovement : MonoBehaviour
    {
        [SerializeField]
        protected GameObject movementObject = default;

        protected Coroutine movementCoroutine = default;
        protected IMovement movementController = default;

        [Inject]
        protected virtual void Construct(IMovement movementController)
        {
            this.movementController = movementController;
        }

        protected virtual void OnEnable() =>
            StartMovement();
        protected virtual void OnDisable() =>
            StopMovement();

        protected virtual void StartMovement()
        {
            movementCoroutine = StartCoroutine(StartMovementCoroutine());
        }

        protected virtual IEnumerator StartMovementCoroutine()
        {
            while (isActiveAndEnabled)
            {
                movementController.Move(movementObject.transform);
                yield return new WaitForFixedUpdate();
            }
        }

        protected virtual void StopMovement()
        {
            if (movementCoroutine != null)
            {
                StopCoroutine(movementCoroutine);
                movementCoroutine = null;
            }
        }
    }
}

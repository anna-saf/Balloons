namespace Ballons.Features.BallonsSpawner
{
    using UnityEngine;

    /// <summary>
    /// Фасад объекта шара
    /// </summary>
    public class BallonFacade : MonoBehaviour
    {
        ///Получить SpriteRenderer шара
        public SpriteRenderer BallonSpriteRenderer => ballonSpriteRenderer;

        [SerializeField]
        protected SpriteRenderer ballonSpriteRenderer = default;
    }
}

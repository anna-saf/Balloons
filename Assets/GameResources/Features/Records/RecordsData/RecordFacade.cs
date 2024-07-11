namespace Balloons.Features.Records
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Фасад вью рекорда
    /// </summary>
    public class RecordFacade : MonoBehaviour
    {
        /// <summary>
        /// Получение компонента text для имени
        /// </summary>
        public Text NameText => nameText;
        /// <summary>
        /// Получение компонента text для рекорда
        /// </summary>
        public Text ScoreText => scoreText;

        [SerializeField]
        protected Text nameText = default;

        [SerializeField]
        protected Text scoreText = default;
    }
}

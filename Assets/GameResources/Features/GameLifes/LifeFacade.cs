namespace Balloons.Features.GameLifes
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Фасад префаба изображения жизни
    /// </summary>
    public class LifeFacade : MonoBehaviour
    {
        ///Получение компонента Image
        public Image LifesIcon => lifesIcon;

        [SerializeField]
        protected Image lifesIcon = default;
    }
}

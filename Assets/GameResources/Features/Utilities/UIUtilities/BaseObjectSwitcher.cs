namespace Balloons.Features.UIUtilities
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Свитчер объектов
    /// </summary>
    public class BaseObjectSwitcher : MonoBehaviour
    {
        [SerializeField]
        protected List<GameObject> enabledObjects = new List<GameObject>();
        [SerializeField]
        protected List<GameObject> disabledObject = new List<GameObject>();

        /// <summary>
        /// Поменять статус объектов в списках
        /// </summary>
        /// <param name="isOn"></param>
        public virtual void SetStatus(bool isOn)
        {
            SetListStatus(enabledObjects, isOn);
            SetListStatus(disabledObject, !isOn);
        }

        private void SetListStatus(List<GameObject> targetList, bool isOn)
        {
            foreach (GameObject listObject in targetList)
            {
                listObject.SetActive(isOn);
            }
        }
    }
}

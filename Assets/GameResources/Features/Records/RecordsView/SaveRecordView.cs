namespace Balloons.Features.Records
{
    using Balloons.Features.GlobalGameValues;
    using Balloons.Features.Utilities;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    /// <summary>
    /// Сохраняет рекорд
    /// </summary>
    public sealed class SaveRecordView : MonoBehaviour
    {
        [SerializeField]
        private InputField nameInputField = default;
        [SerializeField]
        private Button buttonSave = default;

        private GenericEventList<RecordNameData> recordsData = default;
        private GenericEventValue<int> score = default;

        [Inject]
        private void Construct(GenericEventList<RecordNameData> recordsData, [Inject(Id = GlobalGameValueType.Score)] GenericEventValue<int> score)
        {
            this.recordsData = recordsData;
            this.score = score;
        }

        private void OnEnable() =>
            buttonSave.onClick.AddListener(SaveRecord);

        private void OnDisable() =>
            buttonSave.onClick.RemoveListener(SaveRecord);

        private void SaveRecord() =>
            recordsData.AddToList(new RecordNameData() { Name = nameInputField.text, Score = score.Value });
    }
}

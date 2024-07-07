namespace Balloons.Features.Score
{
    using Balloons.Features.GlobalGameValues;
    using Balloons.Features.Utilities;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    /// <summary>
    /// Текстовое поле со счетом
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class ScoreTextView : MonoBehaviour
    {
        protected Text textView = default;    
        protected GenericEventValue<int> score = default;

        [Inject]
        protected virtual void Construct([Inject(Id = GlobalGameValueType.Score)] GenericEventValue<int> score) =>
            this.score = score;

        protected virtual void Awake() =>
            textView = GetComponent<Text>();

        protected virtual void OnEnable()
        {
            OnScoreChanged();
            score.onValueChanged += OnScoreChanged;
        }

        protected virtual void OnDisable() =>
            score.onValueChanged -= OnScoreChanged;

        private void OnScoreChanged() =>
            textView.text = score.Value.ToString();
    }
}

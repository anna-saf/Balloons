namespace Balloons.Features.Records
{
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Инсталлер вью сохранения рекорда
    /// </summary>
    public sealed class SaveRecordViewInstaller : MonoInstaller
    {
        [SerializeField]
        private SaveRecordView _saveRecordView = default;

        public override void InstallBindings() =>
            BindSaveRecordView();

        private void BindSaveRecordView() =>
            Container.BindInstance(_saveRecordView);
    }
}

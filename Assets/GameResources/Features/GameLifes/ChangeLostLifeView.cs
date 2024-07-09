namespace Balloons.Features.GameLifes
{
    using Balloons.Features.GlobalGameValues;
    using Balloons.Features.Utilities;
    using Balloons.Features.GlobalGameEvents;
    using Zenject;

    /// <summary>
    /// Меняет вью потерянной жизни
    /// </summary>
    public class ChangeLostLifeView: GlobalGameEventsProvider
    {
        protected const float ALPHA_VIEW_VALUE = 0.25f;

        protected AbstractLifeSpawner lifesSpawner = default;
        protected GenericEventValue<int> lifesCount= default;

        public ChangeLostLifeView(AbstractLifeSpawner lifesSpawner, [Inject(Id = GlobalGameValueType.Lifes)] GenericEventValue<int> lifesCount, GlobalGameEvents globalGameEvents) : base(globalGameEvents)
        {
            this.lifesSpawner= lifesSpawner;
            this.lifesCount= lifesCount;
        }

        protected override void OnStartGame() =>
            lifesCount.onValueChanged += OnLifesCountChanged;

        protected override void OnEndGame() =>
            lifesCount.onValueChanged -= OnLifesCountChanged;

        public override void Dispose()
        {
            base.Dispose();
            OnEndGame();
        }

        protected virtual void OnLifesCountChanged()
        {
            if (lifesSpawner.SpawnedLifes.Count > lifesCount.Value && lifesCount.Value >=0)
            {
                LifeFacade lifeFacade = lifesSpawner.SpawnedLifes[lifesCount.Value];
                if (lifeFacade)
                {
                    lifeFacade.LifesIcon.gameObject.SetActive(false);
                    lifeFacade.transform.SetAsLastSibling();
                }
            }
        }
    }
}

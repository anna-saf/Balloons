namespace Balloons.Features.ActiveBalloons
{
    using Balloons.Features.BallonsSpawner;
    using Balloons.Features.Utilities;

    /// <summary>
    /// Провайдер листа шаров с ивентами
    /// </summary>
    public abstract class ActiveBalloonsProvider : GenericEventListProvider<BalloonFacade>
    {
        protected ActiveBalloonsProvider(GenericEventList<BalloonFacade> genericEventList) : base(genericEventList) { }
    }
}

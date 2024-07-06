namespace Balloons.Features.ActiveBalloons
{
    using Ballons.Features.BallonsSpawner;
    using Ballons.Features.Utilities;

    /// <summary>
    /// Провайдер листа шаров с ивентами
    /// </summary>
    public abstract class ActiveBalloonsProvider: GenericEventListProvider<BallonFacade>
    {
    }
}

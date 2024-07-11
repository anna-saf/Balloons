namespace Balloons.Features.ActiveBalloons
{
    using Balloons.Features.BallonsSpawner;
    using Balloons.Features.Utilities;

    /// <summary>
    /// Лист шаров, которые в данный момент активны
    /// </summary>
    public class ActiveBalloons : GenericEventList<BalloonFacade> { }
}

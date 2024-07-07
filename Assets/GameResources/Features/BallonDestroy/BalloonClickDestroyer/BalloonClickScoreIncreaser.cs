using Balloons.Features.BalloonDestroy;
using Balloons.Features.GlobalGameValues;
using Balloons.Features.Utilities;
using Zenject;

/// <summary>
/// ����������� ����, ���� ��������� ���� �� ���
/// </summary>
public class BalloonClickScoreIncreaser
{
    protected GenericEventValue<int> score = default;
    protected BalloonClickDestroyer balloonClickDestroyer = default;

    public BalloonClickScoreIncreaser([Inject(Id = GlobalGameValueType.Score)] GenericEventValue<int> score, BalloonClickDestroyer balloonClickDestroyer)
    {
        this.score = score;
        this.balloonClickDestroyer = balloonClickDestroyer;
        balloonClickDestroyer.onBalloonDestroyed += OnBalloonClickDestroyed;
    }

    protected void OnBalloonClickDestroyed() =>
        score.Value++;
}

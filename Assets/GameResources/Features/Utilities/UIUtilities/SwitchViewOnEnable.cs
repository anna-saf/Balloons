namespace Balloons.Features.UIUtilities
{
    /// <summary>
    /// Переключить вью на OnEnable
    /// </summary>
    public class SwitchViewOnEnable : BaseObjectSwitcher
    {
        protected virtual void OnEnable() =>
            SetStatus(true);
    }
}

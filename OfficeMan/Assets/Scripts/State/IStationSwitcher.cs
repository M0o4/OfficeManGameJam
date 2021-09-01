namespace State
{
    public interface IStationSwitcher
    {
        void SwitchState<T>() where T : BaseState;
    }
}

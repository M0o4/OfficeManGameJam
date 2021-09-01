namespace State
{
    public abstract class BaseState
    {
        protected readonly PlayerStats.PlayerStats _playerStats;
        protected readonly IStationSwitcher _stateSwitcher;

        protected BaseState(PlayerStats.PlayerStats playerStats, IStationSwitcher stateSwitcher)
        {
            _playerStats = playerStats;
            _stateSwitcher = stateSwitcher;
        }

        public abstract void Start();
        public abstract void Stop();
        
        public virtual void Work(){}
        public virtual void Rest(){}
        public virtual void Charging(){}
    }
}

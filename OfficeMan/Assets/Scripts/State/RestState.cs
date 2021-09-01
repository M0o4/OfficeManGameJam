using Character;

namespace State
{
    public class RestState : BaseState
    {
        public RestState(PlayerStats.PlayerStats playerStats, IStationSwitcher stateSwitcher) : base(playerStats, stateSwitcher)
        {
        }

        public override void Start()
        {
            Rest();
        }

        public override void Stop()
        {
            _playerStats.StopRest();
        }

        public override void Rest()
        {
            _playerStats.StartRest();
        }
    }
}

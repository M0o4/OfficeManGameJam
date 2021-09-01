using Character;

namespace State
{
    public class StopTimerState : BaseState
    {
        private readonly Timer _timer;
        public StopTimerState(PlayerStats.PlayerStats playerStats, IStationSwitcher stateSwitcher, Timer timer) : base(playerStats, stateSwitcher)
        {
            _timer = timer;
        }

        public override void Start()
        {
            _timer.StopTimer();
        }

        public override void Stop()
        {
          _timer.StartTimer();  
        }
    }
}

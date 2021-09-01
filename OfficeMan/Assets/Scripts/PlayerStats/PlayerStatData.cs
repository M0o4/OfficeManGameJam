using UnityEngine;

namespace PlayerStats
{
    [CreateAssetMenu(fileName = "PlayerStatData", menuName = "Character/PlayerStatData")]
    public class PlayerStatData : ScriptableObject
    {
        public WaitForSeconds WaitForSeconds => _waitForSeconds;
        
        public float time;
        private WaitForSeconds _waitForSeconds;

        public float workChange;
        public float energyChange;
        public float stressChange;

        public void Init()
        {
            _waitForSeconds = new WaitForSeconds(time);
        }
    }
}

using System.Collections;
using UnityEngine;

namespace PlayerStats
{
    public class PlayerStats : MonoBehaviour
    {
        public StressStat Stress => _stress;

        [Header("Player Stat Data")]
        [SerializeField] private PlayerStatData _workData;
        [SerializeField] private PlayerStatData _energyData;
        [SerializeField] private PlayerStatData _restData;
        [SerializeField] private PlayerStatData _idleData;
        
        [Header("Stats")]
        [SerializeField] private WorkStat _work;
        [SerializeField] private EnergyStat _energy;
        [SerializeField] private StressStat _stress;
        
        private SpriteRenderer _renderer;

        private void Awake()
        {
            _workData.Init();
            _energyData.Init();
            _restData.Init();
            _idleData.Init();
        }

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void StartWork()
        {
            StartCoroutine(WorkCoroutine());
        }
        

        public void StartRest()
        {
            _renderer.enabled = false;
            StartCoroutine(RestCoroutine());
        }

        public void StopRest()
        {
            _renderer.enabled = true;
            StopAllCoroutines();
        }

        public void StartRecharging()
        {
            StartCoroutine(RechargingCoroutine());
        }
        
        public void StartIdle()
        {
            StartCoroutine(IdleCoroutine());
        }
        
        
        private IEnumerator WorkCoroutine()
        {
            while (true)
            {
                yield return _workData.WaitForSeconds;
                ChangeStats(_workData);
            }
        }
        
        private IEnumerator RechargingCoroutine()
        {
            while (true)
            {
                yield return _energyData.WaitForSeconds;
                ChangeStats(_energyData);
            }
        }

        private IEnumerator RestCoroutine()
        {
            while (true)
            {
                yield return _restData.WaitForSeconds;
                ChangeStats(_restData);
            }
        }

        private IEnumerator IdleCoroutine()
        {
            while (true)
            {
                yield return _idleData.WaitForSeconds;
                ChangeStats(_idleData);
            }
        }

        private void ChangeStats(PlayerStatData statData)
        {
            _work.SetValue(statData.workChange);
            _energy.SetValue(statData.energyChange);
            _stress.SetValue(statData.stressChange);
        }
    }
}

using UnityEngine;

namespace PlayerStats
{
    public abstract class PlayerStat : MonoBehaviour
    {
        public float Value => _value;
        protected float _value;

        public abstract void SetValue(float value);
    }
}

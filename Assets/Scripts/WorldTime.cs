using System;
using System.Collections; 
using UnityEngine;

namespace WorldTime
{
    public class WorldTime : MonoBehaviour
    {
        public event EventHandler<TimeSpan> WorldTimeChanged;

        [SerializeField]
        private float _dayLength;

        private TimeSpan _currentTime = TimeSpan.Zero;
        private float _minuteLength => _dayLength / WorldTimeConstants.MinutesInDay;

        private void Start()
        {
            StartCoroutine(AddMinute());
        }

        private IEnumerator AddMinute()
        {
            while (true)
            {
                _currentTime += TimeSpan.FromMinutes(1);
                WorldTimeChanged?.Invoke(this, _currentTime);
                yield return new WaitForSeconds(_minuteLength);
            }
        }

        public TimeSpan GetCurrentTime()
        {
            return _currentTime;
        }
    }
}
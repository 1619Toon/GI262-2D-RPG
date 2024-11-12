using System;
using TMPro;
using UnityEngine;

namespace WorldTime
{
    [RequireComponent(typeof(TMP_Text))]
    public class WorldTimeDisplay : MonoBehaviour
    {
        [SerializeField]
        private WorldTime _worldTime;

        private TMP_Text _text;

        // Event function
        private void Awake()
        {
            _text = GetComponent<TMP_Text>();

            if (_worldTime != null)
            {
                _worldTime.WorldTimeChanged += OnWorldTimeChanged;
            }
        }

        private void OnDestroy()
        {
            if (_worldTime != null)
            {
                _worldTime.WorldTimeChanged -= OnWorldTimeChanged;
            }
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            _text.SetText(newTime.ToString(@"hh\:mm"));
        }
    }
}
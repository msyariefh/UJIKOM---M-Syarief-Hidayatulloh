
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz.Gameplay
{
    public class CountdownController : MonoBehaviour
    {
        [SerializeField] private long _remaining;
        [SerializeField] private Slider _timeSlider;
        [SerializeField] private TMP_Text _timerText;
        private Coroutine _countdownCoroutine;
        public Action onFinishCountdown;
        private long _initTime;

        private void Start()
        {
            _timeSlider.maxValue = _remaining;
            _timerText.text = $"{_remaining}s";
            _initTime = _remaining;
            StartCountdown();
            
        }
        private IEnumerator Countdown()
        {
            while(_remaining > 0)
            {
                _timeSlider.value = _remaining;
                _timerText.text = $"{_remaining}s";
                yield return new WaitForSeconds(1);
                _remaining--;
            }
            FinishCountdown();
            
        }  

        public void StartCountdown()
        {
            _remaining = _initTime;
            _countdownCoroutine = StartCoroutine(Countdown());
        }

        public void StopCountdown()
        {
            StopCoroutine(_countdownCoroutine);
        }

        public void FinishCountdown()
        {
            onFinishCountdown?.Invoke();
        }
    }

}

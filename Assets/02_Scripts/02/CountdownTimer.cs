using System.Collections;
using System.Collections.Generic;
using Chapter.EventBus;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

namespace Chapter.EventBus
{
    public class CountdownTimer : MonoBehaviour
    {
        private float _currentTime;
        private float duration = 3.0f;

        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, StartTimer);
        }

        void OnDisable()
        {
            RaceEventBus.UnSubscribe(RaceEventType.COUNTDOWN, StartTimer);
        }

        private void StartTimer()
        {
            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            _currentTime = duration;

            while(_currentTime > 0)
            {
                yield return new WaitForSeconds(1f);
                _currentTime--;
            }

            RaceEventBus.Publish(RaceEventType.START);
        }

        void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(125, 0, 300, 60), "Countdown : " + _currentTime);
        }
    }
}

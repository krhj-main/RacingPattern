using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.EventBus
{
    public class ClientEventBus : MonoBehaviour
    {
        private bool _isButtonEnabled;

        void Start()
        {
            gameObject.AddComponent<HUDController>();
            gameObject.AddComponent<CountdownTimer>();
            gameObject.AddComponent<BikeControllerEvent>();

            _isButtonEnabled = true;
        }

        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.STOP, Restart);
        }

        void OnDisable()
        {
            RaceEventBus.UnSubscribe(RaceEventType.STOP, Restart);
        }

        void Restart()
        {   
            _isButtonEnabled = true;
        }

        void OnGUI()
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 40;
            if(_isButtonEnabled)
            {
                if(GUILayout.Button("Start Countdown",style))
                {
                    _isButtonEnabled = false;
                    RaceEventBus.Publish(RaceEventType.COUNTDOWN);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Chapter.EventBus;
using UnityEngine;

namespace Chapter.EventBus
{
    public class BikeControllerEvent : MonoBehaviour
    {

        private string _status;
        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.START, StartBike);

            RaceEventBus.Subscribe(RaceEventType.STOP, StopBike);
        }
        void OnDisable()
        {
            RaceEventBus.UnSubscribe(RaceEventType.START, StartBike);

            RaceEventBus.UnSubscribe(RaceEventType.STOP, StopBike);
        }

        private void StartBike()
        {
            _status = "Started";
        }
        private void StopBike()
        {
            _status = "Stopped";
        }
        
        void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(10, 60, 200, 20), "BIKE STATUS : "+ _status);
        }
    }
}

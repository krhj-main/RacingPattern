using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Facade
{
    public class CoolingSystem : MonoBehaviour
    {
        public BikeEngine enigne;
        public IEnumerator coolEngine;
        public bool _isPaused;

        public void PauseCooling()
        {

        }
        public void ResetTemperature()
        {
            
        }

        public IEnumerator CoolEngine()
        {
            while(true)
            {
                yield return new WaitForSeconds(1f);

                if(!_isPaused)
                {
                    if(enigne.currentTemp > enigne.minTemp)
                    enigne.currentTemp -= enigne.tempRate;
                    if(enigne.currentTemp < enigne.minTemp)
                    enigne.currentTemp += enigne.tempRate;
                }
                else
                {
                    enigne.currentTemp += enigne.tempRate;
                }
                if(enigne.currentTemp > enigne.maxTemp)
                enigne.TurnOff();
            }
        }

        void OnGUI()
        {

        }
    }
}

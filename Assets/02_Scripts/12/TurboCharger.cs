using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Facade
{
    public class TurboCharger : MonoBehaviour
    {
        public BikeEngine engine;

        private bool _isTurboOn;
        public IEnumerator turboCharger;
        private CoolingSystem _coolingSystem;

        void Start()
        {
            turboCharger = TurboCharge();
        }

        public void ToggleTurbo(CoolingSystem coolingSystem)
        {
            _coolingSystem = coolingSystem;
            if(!_isTurboOn)
            StartCoroutine(TurboCharge());
        }

        IEnumerator TurboCharge()
        {
            _isTurboOn = true;
            _coolingSystem.PauseCooling();

            yield return new WaitForSeconds(engine.turboDuration);

            _isTurboOn = false;
            _coolingSystem.PauseCooling();
        }

        void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(10,60,500,20), "Turbo Acitvated: "+_isTurboOn);
        }

    }
}

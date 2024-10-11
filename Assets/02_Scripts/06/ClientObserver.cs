using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Chapter.Observer
{
    public class ClientObserver : MonoBehaviour
    {
        private BikeController _bikeController;

        void Start()
        {
            _bikeController = (BikeController)FindObjectOfType(typeof(BikeController));
        }

        void OnGUI()
        {
            if(GUILayout.Button("Take Damage Bike"))
            {
                if(_bikeController)
                    _bikeController.TakeDamage(15.0f);
            }
            if(GUILayout.Button("Toggle Turbo"))
            {
                if(_bikeController)
                    _bikeController.ToggleTurbo();
            }
        }
    }
}

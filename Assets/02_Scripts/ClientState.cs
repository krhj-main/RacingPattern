using System.Collections;
using System.Collections.Generic;
using Chapter.State;
using UnityEngine;

namespace Chpater.State
{
    public class ClientState : MonoBehaviour
    {
        private BikeController _bikeController;

        void Start()
        {
            _bikeController = (BikeController)FindObjectOfType(typeof(BikeController));
        }

        void OnGUI()
        {
            if(GUILayout.Button("Start Bike"))  _bikeController.StartBike();

            if(GUILayout.Button("Turn Left"))   _bikeController.TurnBike(Direction.Left);

            if(GUILayout.Button("Turn Right"))   _bikeController.TurnBike(Direction.Right);

            if(GUILayout.Button("Stop Bike"))   _bikeController.StopBike();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using Chapter.State;
using Chpater.State;
using UnityEngine;


namespace Chapter.State
{
    public class BikeTurnState : MonoBehaviour, IBikeState
    {
        private BikeController _bikeController;
        private Vector3 _turnDirection;
        public void Handle(BikeController bikecontroller)
        {
            if(!_bikeController)
            {
                _bikeController = bikecontroller;            
            }
            _turnDirection.x = (float) _bikeController.CurrentTurnDirection;

            if(_bikeController.CurrentSpeed > 0)
            {
                transform.Translate(_turnDirection * _bikeController.turnDistance);
            }
        }
    }
}

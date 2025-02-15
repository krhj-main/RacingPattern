using System.Collections;
using System.Collections.Generic;
using Chapter.State;
using Chpater.State;
using UnityEngine;

namespace Chapter.State
{
    public class BikeStartState : MonoBehaviour, IBikeState
    {
        private BikeController _bikeController;
        public void Handle(BikeController bikecontroller)
        {
            if(!_bikeController)
            {
                _bikeController = bikecontroller;
            }
            _bikeController.CurrentSpeed = _bikeController.maxSpeed;
        }
        void Update()
        {
            if(_bikeController)
            {
                if(_bikeController.CurrentSpeed > 0)
                {
                    _bikeController.transform.Translate(Vector3.forward * _bikeController.CurrentSpeed * Time.deltaTime);
                }
            }
        }
    }
}

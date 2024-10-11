using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Context 클래스는 호출, 응답간의 환경정보를 구현할 클래스
namespace Chpater.State
{
    public class BikeStateContext : MonoBehaviour
    {
        public IBikeState CurrentState
        {
            get; set;
        }

        private readonly Chapter.State.BikeController _bikeController;

        public BikeStateContext(Chapter.State.BikeController bikeController)
        {
            _bikeController = bikeController;
        }

        public void Transition()
        {
            CurrentState.Handle(_bikeController);
        }

        public void Transition(IBikeState state)
        {
            CurrentState = state;
            CurrentState.Handle(_bikeController);
        }
    }
}

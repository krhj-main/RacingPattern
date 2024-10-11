using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Command
{
    public class BikeController04 : MonoBehaviour
    {
        private bool _isTurboOn;
        private float _distance = 1.0f;
        
        public void ToggleTurbo()
        {
            _isTurboOn = !_isTurboOn;
        }
        public void ResetPosition()
        {
            // 디버깅 및 테스트 목적 메서드
            transform.position = new Vector3(0,0,0);
        }
        public void Turn(Direction direction)
        {
            if(direction == Direction.Left)
                transform.Translate(Vector3.left * _distance);
            
            if(direction == Direction.Right)
                transform.Translate(Vector3.right * _distance);
        }


    }
}

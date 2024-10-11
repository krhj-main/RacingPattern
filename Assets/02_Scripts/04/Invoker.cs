using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Chapter.Command
{
    public class Invoker : MonoBehaviour
    {
        private bool _isRecording;
        private bool _isReplaying;
        private float _replayTime;
        private float _recordingTime;

        // SortedList : Key 의 오름차순으로 키-값 쌍으로 저장
        private SortedList<float, Command> _recordedCommands = new SortedList<float, Command>();

        public void ExecuteCommand(Command command)
        {
            command.Execute();

            if(_isRecording)
            {
                _recordedCommands.Add(_recordingTime, command);
            }

            Debug.Log("Recorded Time : " + _recordingTime);
            Debug.Log("Recorded Command : " + command);
        }

        public void Record()
        {
            _recordingTime = 0f;
            _isRecording = true;
        }

        public void Replay()
        {
            _replayTime = 0f;
            _isReplaying = true;

            if(_recordedCommands.Count < 0 )
            {
                Debug.LogError("No Commands to replay!");
            }

            _recordedCommands.Reverse();
        }

        void FixedUpdate()
        {
            if(_isRecording)
            {
                _recordingTime += Time.fixedDeltaTime; // FixedUpdate 라서 fixedDeltaTime사용 
            }
            if(_isReplaying)
            {
                // 수량자 작업 : 시퀀스에서 조건을 충족하는 요소가 일부인지 전체인지를 나타내는것을 참-거짓으로 반환
                _replayTime += Time.fixedDeltaTime;

                //수량자 작업  Any메서드 : 시퀀스의 임의의 요소가 조건을 만족하는지를 확인
                if(_recordedCommands.Any())
                {
                    if(Mathf.Approximately(_replayTime, _recordedCommands.Keys[0])) // Approximately 근사값 
                    {
                        Debug.Log("Replay Time : " + _replayTime);
                        Debug.Log("Replay Command : " + _recordedCommands.Values[0]);

                        _recordedCommands.Values[0].Execute();
                        _recordedCommands.RemoveAt(0);
                    }
                }
                else
                {
                    _isReplaying = false;
                }
                
            }
        }
    }
}

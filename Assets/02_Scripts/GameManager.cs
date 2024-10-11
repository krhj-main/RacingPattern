using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Chapter.Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        private DateTime _sessionStartTime;
        private DateTime _sessionEndTime;

        void Start()
        {
            _sessionStartTime = DateTime.Now;
            Debug.Log("Game Session start @: " + DateTime.Now);
        }

        void OnApplicationQuit()
        {
            _sessionEndTime = DateTime.Now;
            // TImeSpan 특정 시간이 아닌, 몇일 몇시간 몇분 몇초와 같은 시간의 크기를 나타냄
            // 기본값은 00:00:00

            TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);
            //Subtract(TimeSpan)    이 인스턴스 값에서 지정된 기간을 뺀 새 DateTime을 반환
            //Subtract(DateTime)    이 인스턴스의 값에서 지정된 날짜와 시간을 뺀 새 TimeSpan을 반환

            Debug.Log("Game Session ended @: " + DateTime.Now);
            Debug.Log("Game Session lasted @: " + timeDifference);
        }

        void OnGUI()
        {
            if(GUILayout.Button("Next Scene"))
            {
                // 현재 진행중인 씬의 인덱스번호 값 => buildIndex
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            }
        }
    }
}

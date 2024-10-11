using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Chapter.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;
        public static T Instance
        {
            get{
                if(_instance == null)            
                {
                    _instance = FindObjectOfType<T>();
                    if(_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        _instance = obj.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }

        //싱글톤 클래스의 마지막 부분 구현
        // 파생 클래스에서 다시 정의할 수 있다는 의미인 virtual로 지정한 awake
        // 해당 함수를 호출 했을때 싱글톤 컴포넌트는 메모리에 초기화된 자신의 인스턴스가 이미 있는지 확인
        // 인스턴스가 없다면 싱글톤 컴포넌트는 자신이 현재 인스턴스가 되고
        // 있다면 복제를 막기위해 스스로를 제거
        // 결과적으로 씬에는 하나으 특정한 싱글톤 인스턴스만 남는다.

        public virtual void Awake()
        {
            if(_instance == null)
            {
                _instance = this as T;
                
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

namespace Chapter.ObjectPool
{
    public class DroenObjectPool : MonoBehaviour
    {
        public int maxPoolSize = 10;        // 풀에 보관할 드론 인스턴스 최대수

        // 기본 스택 크기
        // 드론 인스턴스를 저장하는데 사용할 스택 데이터 구조체와 관련된 속성
        public int stackDefaultCapacity = 10;

        // 오브젝트 풀 초기화
        public IObjectPool<Drone> Pool
        {
            get
            {
                if(_pool == null)
                {
                    // ObjectPool(생성할 함수, Get, Release, Detroy, Max)
                    _pool = new ObjectPool<Drone>(CreatedPooledItem,
                                                    OnTakeFromPool,
                                                    OnReturnedToPool,
                                                    OnDestroyPoolObject,
                                                    true,
                                                    stackDefaultCapacity,
                                                    maxPoolSize);
                    
                }
                return _pool;
            }
        }
        private IObjectPool<Drone> _pool;

        // IObjectPool<T> 생성자에서 선언한 콜백을 구현
        // 드론 인스턴스를 초기화한다.
        Drone CreatedPooledItem()
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);        // 스크립트로 기본 오브젝트 만들기

            Drone drone = go.AddComponent<Drone>();

            go.name = "Drone";
            drone.Pool = Pool;

            return drone;
        }
        // 클라이언트가 드론 인스턴스를 요청할 때 호출된다. 인스턴스가 실제로 반환되는 것이 아니라 게임오브젝트가 비활성화되는것
        void OnTakeFromPool(Drone drone)
        {
            drone.gameObject.SetActive(true);
        }
        //드론 인스턴스 사라질 때 호출
        void OnReturnedToPool(Drone drone)
        {
            drone.gameObject.SetActive(false);
        }
        // 반드시 이해해야 하는 중요 메서드
        // 풀에 더이상 공간이 없을 때 호출됨
        // 반환된 인스턴스는 메모리를 확보하기 위해 파괴된다.
        void OnDestroyPoolObject(Drone drone)
        {
            Destroy(drone.gameObject);
        }
        public void Spawn()
        {
            var amount = Random.Range(1,10);

            for(int i=0; i<amount; ++i)
            {
                var drone = Pool.Get();     // 풀에서 인스턴스를 가져옴, 비어있으면 새 인스턴스 생성

                drone.transform.position = Random.insideUnitSphere * 10;
            }
        }
    }
}

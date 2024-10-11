using System.Collections;
using System.Collections.Generic;
using Chapter.EventBus;
using UnityEngine;
using UnityEngine.Events;

namespace Chapter.EventBus
{
    public class RaceEventBus
    {
        // 클래스의 인스턴스 생성
        private static readonly IDictionary<RaceEventType, UnityEvent> Events = new Dictionary<RaceEventType, UnityEvent>();

        // 클라이언트는 특정 이벤트 타입의 구독자로 자신을 추가하려면 public static 메서드인 Subscribe를 호출해야함
        // 두개의 파라미터 : 이벤트 종류, 콜백 함수
        // UnityAction이 델리게이트 타입이므로 인자로 메서드를 전달한다.
        // 특정 레이스 이벤트의 구독자는 클라이언트 오브젝트가 Publish()메서드를 호출할 때 등록한 콜백 메서드도 동시에 호출될 것이다.
        public static void Subscribe(RaceEventType eventType, UnityAction listener)
        {
            UnityEvent thisEvent;

            // TryGetValue 첫번째 인자로 받은 eventType 유효한 키 값인지 확인을 하고
            // out 키워드를 이용해 thiEvent UnityEvent를 반환
            if(Events.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Events.Add(eventType, thisEvent);
            }
        }

        //UnSubscribe() 특정 이벤트를 구독하는 오브젝트를 삭제
        // 오브젝트가 이벤트를 게시할 때 이벤트 버스가 삭제한 콜백 메서드는 호출하지 않음
        public static void UnSubscribe(RaceEventType type, UnityAction listener)
        {
            UnityEvent thisEvent;

            if(Events.TryGetValue(type, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        // 특정 레이스 이벤트의 구독자는 클라이언트의 오브젝트가 이 메서드를 호출할 때
        // 등록한 콜백 메서드도 동시에 호출할 수 있다.
        public static void Publish(RaceEventType type)
        {
            UnityEvent thisEvent;

            if(Events.TryGetValue(type, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }
}
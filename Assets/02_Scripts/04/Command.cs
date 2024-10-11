using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Chapter.Command
{
    public abstract class Command
    {
        // 추상 메서드 자식 클래스에서 override 키워드를 사용하여 재정의 하여 구현
        public abstract void Execute();   
    }
}

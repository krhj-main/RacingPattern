using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chpater.State
{
    public interface IBikeState
    {
        // 스크립트(클래스) 를 인자값으로 받음
        void Handle(Chapter.State.BikeController controller);
    }
}

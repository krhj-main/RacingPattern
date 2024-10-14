using System.Collections;
using System.Collections.Generic;
using Chapter.ObjectPool;
using UnityEngine;
using Chapter.Strategy;

namespace Chapter.Strategy
{
    public interface IManeuverBehaviour
    {
        void Maneuver(Drone drone);
    }
}

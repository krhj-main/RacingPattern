using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace Chapter.Observer
{
    public abstract class Observer : MonoBehaviour
    {
        public abstract void Notify(Subject subject);
    }
}

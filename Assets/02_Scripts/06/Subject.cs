using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Chapter.Observer
{
    public abstract class Subject : MonoBehaviour
    {
        private readonly ArrayList _observer = new ArrayList();

        protected void Attach(Observer observer)
        {
            _observer.Add(observer);
        }

        protected void Detach(Observer observer)
        {
            _observer.Remove(observer);
        }
        protected void NotifyObservers()
        {
            foreach(Observer observer in _observer)
            {
                observer.Notify(this);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Chapter.ServiceLocator;
using UnityEngine;

namespace Chapter.ServiceLocator
{
    public class Logger : ILoggerService
    {
        public void Log(string message)
        {
            Debug.Log("Logged : " + message);
        }
    }
}

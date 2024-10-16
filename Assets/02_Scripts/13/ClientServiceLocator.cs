using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Analytics;

namespace Chapter.ServiceLocator
{
    public class ClientServiceLocator : MonoBehaviour
    {
        void Start()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            ILoggerService logger = new Logger();
            ServiceLocator.RegisterService(logger);

            IAnalyticsService analytics = new Analytics();
            ServiceLocator.RegisterService(analytics);

            IAdvertisement advertisement = new Advertisement();
            ServiceLocator.RegisterService(advertisement);
        }


        void OnGUI()
        {
            if(GUILayout.Button("Log Event"))
            {
                ILoggerService logger = ServiceLocator.GetService<ILoggerService>();

                logger.Log("Hello World");
            }

            if(GUILayout.Button("Send Analytics"))
            {
                IAnalyticsService analytics = ServiceLocator.GetService<IAnalyticsService>();

                analytics.SendEvent("Hello World");
            }

            if(GUILayout.Button("Display Advertisement"))
            {
                IAdvertisement advertisement= ServiceLocator.GetService<IAdvertisement>();

                advertisement.DisplayAd();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.ObjectPool
{
    public class ClientObjectPool : MonoBehaviour
    {
        private DroenObjectPool _pool;

        void Start()
        {
            _pool = gameObject.AddComponent<DroenObjectPool>();
        }

        void OnGUI()
        {
            if(GUILayout.Button("Spawn Drones"))
            _pool.Spawn();
        }
    }
}

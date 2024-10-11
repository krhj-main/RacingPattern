using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Pool;

namespace Chapter.ObjectPool
{
    public class Drone : MonoBehaviour
    {
        public IObjectPool<Drone> Pool {get; set;}
        public float _currentHealth;

        [SerializeField] private float maxHealth = 100.0f;
        [SerializeField] private float timeToSelfDestruct = 3.0f;

        void Start()
        {
            _currentHealth = maxHealth;
        }

        void OnEnable()
        {
            AttackPlayer();
            StartCoroutine(SelfDestruct());
        }

        void AttackPlayer()
        {
            Debug.Log("Attack Player!");
        }
        IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(timeToSelfDestruct);
            TakeDamage(maxHealth);
        }

        void OnDisable()
        {
            ResetDrone();
        }
        void ReturnToPool()
        {
            Pool.Release(this);
        }
        void ResetDrone()
        {
            _currentHealth = maxHealth;
        }
        void TakeDamage(float amount)
        {
            _currentHealth -= amount;

            if(_currentHealth <= 0f)
            {
                ReturnToPool();
            }
        }
    }
}

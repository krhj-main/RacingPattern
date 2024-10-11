using System.Collections;
using System.Collections.Generic;
using Chapter.Observer;
using UnityEngine;

namespace Chapter.Observer
{
    public class BikeController : Subject
    {
        public bool _isTurboOn
        {
            get; private set;
        }
        public float CurrentHealth
        {
            get { return health;}
        }

        private bool _isEngineOn;
        private HUDController _hudController;
        private CameraController _cameraController;

        [SerializeField] private float health = 100.0f;

        void Awake()
        {
            _hudController = gameObject.AddComponent<HUDController>();
            _cameraController = (CameraController)FindObjectOfType(typeof(CameraController));

        }

        void Start()
        {
            StartEngine();
        }
        void OnEnable()
        {
            if(_hudController)
                Attach(_hudController);

            if(_cameraController)
                Attach(_cameraController);
        }
        void OnDisable()
        {
            if(_hudController)
                Detach(_hudController);

            if(_cameraController)
                Detach(_cameraController);
        }

        private void StartEngine()
        {
            _isEngineOn = true;

            NotifyObservers();
        }
        public void ToggleTurbo()
        {
            if(_isEngineOn)
            {
                _isTurboOn =!_isTurboOn;
            }
            NotifyObservers();
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            _isTurboOn = false;

            NotifyObservers();

            if(health<0)
                Destroy(gameObject);
        }
    }
}

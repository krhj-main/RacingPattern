using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Chapter.Command
{
    public class InputHandler : MonoBehaviour
    {
        private Invoker _invoker;
        private bool _isReplaying;
        private bool _isRecording;
        private BikeController04 _bikeController;
        private Command _buttonA, _buttonD, _buttonW;

        void Start()
        {
            _invoker = gameObject.AddComponent<Invoker>();
            _bikeController = FindObjectOfType<BikeController04>();

            _buttonA = new TurnLeft(_bikeController);
            _buttonD = new TurnRight(_bikeController);
            _buttonW = new ToggleTurbo(_bikeController);
        }

        void Update()
        {
            if(!_isReplaying && _isRecording)
            {
                if(Input.GetKeyUp(KeyCode.A))
                    _invoker.ExecuteCommand(_buttonA);

                if(Input.GetKeyUp(KeyCode.D))
                    _invoker.ExecuteCommand(_buttonD);

                if(Input.GetKeyUp(KeyCode.W))
                    _invoker.ExecuteCommand(_buttonW);
            }
        }

        void OnGUI()
        {
            if(GUILayout.Button("Start Recording"))
            {
                _bikeController.ResetPosition();
                _isReplaying = false;
                _isRecording = true;
                _invoker.Record();
            }
            if(GUILayout.Button("Stop Recording"))
            {
                _bikeController.ResetPosition();
                _isRecording = false;
            }

            if(!_isRecording)
            {
                if(GUILayout.Button("Start Replay"))
                {
                    _bikeController.ResetPosition();
                    _isRecording = false;   
                    _isReplaying = true;
                    _invoker.Replay();
                }
            }
        }
        ///<summary>
        ///
        ///</summary>
        /*
        
        [SerializeField] Controller _characterController;
        private Command _spaceButton;
        
        // Start is called before the first frame update
        void Start()
        {
            _spaceButton = new JumpCommand();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown("Space"))
            {
                _spaceButton.Execute(_characterController);
            }
        }*/
        
        
    }
}

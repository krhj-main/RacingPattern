using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chapter.Command;

namespace Chapter.Command
{
    public class TurnLeft : Command
    {
        private BikeController04 _controller;
        public TurnLeft(BikeController04 controller)
        {
            _controller = controller;
        }

        public override void Execute()
        {
            _controller.Turn(Direction.Left);
        }
    }
}


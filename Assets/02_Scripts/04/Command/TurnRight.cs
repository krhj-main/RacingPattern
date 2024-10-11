using System.Collections;
using System.Collections.Generic;
using Chapter.Command;
using UnityEngine;

namespace Chapter.Command
{
    public class TurnRight : Command
    {
        private BikeController04 _controller;

        public TurnRight(BikeController04 controller)
        {
            _controller = controller;
        }

        public override void Execute()
        {
            _controller.Turn(Direction.Right);
        }
    }
}

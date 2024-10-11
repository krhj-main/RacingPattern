using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Command
{
    public class ToggleTurbo : Command
    {
        private BikeController04 _controller;

        public ToggleTurbo(BikeController04 controller)
        {
            _controller = controller;
        }

        public override void Execute()
        {
            _controller.ToggleTurbo();
        }
    }
}

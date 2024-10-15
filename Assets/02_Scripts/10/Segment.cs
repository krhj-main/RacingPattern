using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Chapter.SpatialPartition;
using UnityEngine;

namespace Chapter.SpatialPartition
{
    public class Segment : MonoBehaviour
    {
        public TrackController trackController;

        private void OnDestory()
        {
            if(trackController)
                trackController.LoadNextSegment();
        }
    }
}

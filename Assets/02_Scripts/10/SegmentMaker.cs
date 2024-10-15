using System.Collections;
using System.Collections.Generic;
using Chapter.SpatialPartition;
using UnityEngine;


namespace Chapter.SpatialPartition
{
    public class SegmentMaker : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)   
        {
            if(other.GetComponent<BikeController>())
                Destroy(transform.parent.gameObject);
        }
    }
}

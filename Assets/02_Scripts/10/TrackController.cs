using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using System;

namespace Chapter.SpatialPartition
{
    public class TrackController : MonoBehaviour
    {
        private float _trackSpeed;
        private Transform _prevSeg;
        private GameObject _trackParent;
        private Transform _segParent;
        private List<GameObject> _segments;
        private Stack<GameObject> _segStack;
        // 스택은 후입 선출, 큐는 선입 선출 자료 구조임

        private Vector3 _currentPosition = Vector3.zero;

        [Tooltip("List of race Tracks")]
        [SerializeField] private Track track;

        [Tooltip("Initial amount of segment to load at start")]
        [SerializeField] private int initSegAmount;

        [Tooltip("Amount of incremental segments to load at run")]
        [SerializeField] private int incrSegAmount;

        [Tooltip("Dampen teh speed of the track")]
        [Range(0.0f, 100.0f)]
        [SerializeField] private float speedDampener;

        void Awake()
        {
            // Linq 에 존재하는 Reverse 메서드 : Enumerable 클래스에서 구현되며 IEnumerable<TSource> 타입으로 반환
            _segments = Enumerable.Reverse(track.segments).ToList();        // ToList() : Linq 결과를 List로 변환
        }

        void Start()
        {
            InitTrack();
        }

        void InitTrack()
        {
            Destroy(_trackParent);

            _trackParent = Instantiate(Resources.Load("Track",typeof(GameObject))) as GameObject; // as : 형 변환이 가능하면

            if(_trackParent)
            {
                _segParent = _trackParent.transform.Find("Segments");
            }

            _prevSeg = null;

            _segStack = new Stack<GameObject>(_segments);

            LoadSegment(initSegAmount);
        }

        private void LoadSegment(int amount)
        {
            for(int i=0; i< amount;i++)
            {
                if(_segStack.Count > 0)
                {
                    GameObject segment = Instantiate(_segStack.Pop(), _segParent.transform);

                    if(!_prevSeg)
                    {
                        _currentPosition.z = 0;
                    }

                    if(_prevSeg)
                    {
                        _currentPosition.z = _prevSeg.position.z + track.segmentLength;
                    }

                    segment.transform.position = _currentPosition;

                    segment.AddComponent<Segment>();

                    segment.GetComponent<Segment>().trackController = this;

                    _prevSeg = segment.transform;
                }

                
            }
        }

        public void LoadNextSegment()
        {
            LoadSegment(incrSegAmount);
        }

        void Update()
        {
            _segParent.transform.Translate(Vector3.back * (_trackSpeed * Time.deltaTime));
        }
    }
}

using System;
using System.Collections.Generic;
using Unity_Framework.Scripts.Import.Interface;
using Unity_Framework.Scripts.Path.PathManager.Path;
using UnityEngine;

namespace Unity_Framework.Scripts.Path.PathManager.PathAgent
{
    public class UF_AgentFollowCurve : MonoBehaviour, IIsValid
    {
        #region f/p

        public static event Action OnIsArrived = null;

        private event Action OnUpdate = null;

        //[SerializeField, Header("Path ID")]private string pathID;
        [SerializeField, Header("Speed Move"), Range(0, 100)]
        private float speedMove;

        [SerializeField, Header("Speed Rotation"), Range(0, 500)]
        private float speedRotation;

        private List<Vector3> pathPoints = new List<Vector3>();

        public UF_Path CurrentPath;
        private Vector3 currentPoint;
        private int currentIndex;

        public float SpeedMove
        {
            get => speedMove;
            set { speedMove = value; }
        }

        public float SpeedRotation
        {
            get => speedRotation;
            set { speedRotation = value; }
        }

        public int currentIndexPosition = 0;
        private Vector3 LastCurvePosition => pathPoints?[pathPoints.Count - 1] ?? Vector3.zero;

        private bool isAtEnd => currentPoint == LastCurvePosition;
        public bool IsValid => pathPoints != null && CurrentPath != null;

        #endregion

        #region unity methods

        void Awake()
        {
            UF_PathManager.OnInit += InitPath;
            OnUpdate += MoveTo;
            OnUpdate += RotateTo;
        }

        void Update()
        {
            if (pathPoints == null) return;

            OnUpdate?.Invoke();

            if (isAtEnd)
                OnIsArrived?.Invoke();
        }

        #endregion

        
        
        
        #region custom methods
        void RotateTo()
        {
            if (Vector3.Distance(transform.position, currentPoint) > 0)
            {
                Quaternion _lookRotate = Quaternion.LookRotation(currentPoint - transform.position, transform.up);
                transform.rotation =
                    Quaternion.RotateTowards(transform.rotation, _lookRotate, SpeedRotation * Time.deltaTime);
            }
        }

        void MoveTo()
        {
            FollowPath();
        }


        void InitPath()
        {
            pathPoints = CurrentPath.PathMode.Mode.PathPoints;
            if (!IsValid) return;

            //pathPoints = paths[CurveID];
            currentIndex = CurrentPath.PathMode.Mode.GetStartPercentIndex;
            currentPoint = CurrentPath.PathMode.Mode.StartPercentPosition;
            transform.position = currentPoint;
        }

        private void FollowPath()
        {
            // GetPathById(pathID);

            if (Vector3.Distance(transform.position, currentPoint) < 0.00001f)
                currentPoint = GetNextPoint();
            
            transform.position = Vector3.MoveTowards(transform.position, currentPoint, SpeedMove * Time.deltaTime);
        }

        private Vector3 GetNextPoint()
        {
            if (CurrentPath == null)
            {
                currentIndex = 0;
                return Vector3.zero;
            }

        
            if (isAtEnd) return currentPoint;

            if (currentIndex < pathPoints.Count)
            {
                currentIndex++;
                return pathPoints[currentIndex];
            }

          
            return CurrentPath.PathMode.Mode.StartPercentPosition;
        }
        
        // todo review
        /*
        private void ResetCurvePath()
        {
            //todo not fixed when point is deplaced
            currentIndex = currentCurve.GetStartAtPercent;
            currentPoint = currentCurve.StartPercentPosition;
            transform.position = currentPoint;
        }*/
        #endregion
        
        
        
    }
}
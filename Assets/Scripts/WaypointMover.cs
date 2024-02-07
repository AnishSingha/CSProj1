using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private SplineMovement _wayPoints;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _distanceThreshold = 0.1f;
    [Range(0f,10f)]
    [SerializeField] private float _rotateSpeed = 4f;

    private Transform _currenWaypoint;
    private Quaternion _rotationGoal;
    private Vector3 _directionToWayPoint;

    void Start()
    {
       // _currenWaypoint = _wayPoints.GetNextWaypoint(_currenWaypoint);
        transform.position = _currenWaypoint.position;
       // _currenWaypoint = _wayPoints.GetNextWaypoint(_currenWaypoint);
        transform.LookAt(_currenWaypoint);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currenWaypoint.position, _moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _currenWaypoint.position) < _distanceThreshold)
        {
         //   _currenWaypoint = _wayPoints.GetNextWaypoint(_currenWaypoint);

        }
        RotateTowardsWayPoint();
    }

    private void RotateTowardsWayPoint()
    {
        _directionToWayPoint = (_currenWaypoint.position - transform.position).normalized;
        _rotationGoal = Quaternion.LookRotation(_directionToWayPoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, _rotationGoal, _rotateSpeed * Time.deltaTime);
    }
}

using UnityEngine;

public class Path : MonoBehaviour
{   
    [SerializeField] private Transform[] _wayPoints;

    public Transform GetWaypointByIndex(int index) => _wayPoints[index];

    public Transform[] GetWaypoints() => _wayPoints;

    private void Awake() {
        _wayPoints = GetComponentsInChildren<Transform>();
    }
}

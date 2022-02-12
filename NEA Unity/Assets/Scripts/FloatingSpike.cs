using UnityEngine;

public class FloatingSpike : Enemy {
    [SerializeField] Transform[] _patrolPoints;
    [SerializeField] private float _stationaryTime; //how long it waits on a point
    private Vector3 _nextPoint;
    private int _counter = 0;
    private float _timer;

    [SerializeField] private float _spinSpeed;

    private void Start() {
        _nextPoint = _patrolPoints[1].position; //set the first point to be travelled to
    }

    private void Update() {
        Move();
        Spin();
    }

    protected override void Move() {
        if (transform.position == _nextPoint) { //if it has reached the next point
            _timer += Time.deltaTime;   //increase timer
            if (_timer > _stationaryTime) { //if timer has reached the end
                _timer = 0; //reset timer
                _counter++; //increase counter by 1
                if (_counter == _patrolPoints.Length) { //if the counter exceeded array indexes
                    _counter = 0;   //reset counter to first index
                }
                _nextPoint = _patrolPoints[_counter].position; //set the next point to travel to
            }
        }
        else { //if it has not reached the next point, move towards it
            transform.position = Vector3.MoveTowards(transform.position, _nextPoint, _speed * Time.deltaTime);
        }
    }

    float angle;
    private void Spin() { //spins the spike (no gameplay effect)
        angle += + _spinSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}

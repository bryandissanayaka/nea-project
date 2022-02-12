using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] private float _rotatingSpeed;
    float angle;
    private void Update() {
        angle += _rotatingSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}

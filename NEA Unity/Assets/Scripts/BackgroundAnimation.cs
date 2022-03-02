using UnityEngine;
using static UnityEngine.Mathf;

public class BackgroundAnimation : MonoBehaviour
{
	[SerializeField] private float _spinSpeed;
    float angle;

    [SerializeField] private float _bounceRange;

    private void Update() {
        Spin();
        SinCosMovement();
    }

	private void Spin() {
		angle += _spinSpeed * Time.deltaTime;
		transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void SinCosMovement() {
        float sin = Sin(Time.time);
        float cos = Cos(Time.time);
        transform.position = new Vector3(cos * _bounceRange, sin * _bounceRange, 0);
    }
}

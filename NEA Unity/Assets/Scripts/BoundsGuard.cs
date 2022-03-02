using UnityEngine;

public class BoundsGuard : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            GameManager.instance.FailLevel();
        }
    }
}

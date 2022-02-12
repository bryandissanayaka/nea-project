using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && GameManager.instance.IsKeyCollected()) {
            GameManager.instance.CompleteLevel();
        }
    }
}